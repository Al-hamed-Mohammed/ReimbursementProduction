using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EmployeeManager2.Data;
using EmployeeManager2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace EmployeeManager2.Controllers
{
    [Authorize(Roles = UtilityClass.SuperAdminRole)]
    public class AccountantController : Controller
    {
        private readonly IAccountantRepo repo;
        private readonly IInsertErrorLog log;

        public IConfiguration Configuration { get; }

        public AccountantController(IAccountantRepo repo, IConfiguration configuration, IInsertErrorLog log)
        {
            this.repo = repo;
            Configuration = configuration;
            this.log = log;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.ErrorMessage = "";
                var model = await repo.GetAccountants();
                return View(model);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ICRUDModel<Accountants> value)
        {
            try
            {
                //value is coming null. Need to check
                var accountant = value.value;
                await repo.Add(accountant);
                return (RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Accountants value)
        {
            try
            {
                var accountant = value;
                await repo.Add(accountant);
                return (RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ICRUDModel<Accountants> value)
        {
            try
            {
                var accountant = value.value;
                await repo.UpdateAccountant(accountant);
                return (RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] ICRUDModel<Accountants> value)
        {
            try
            {
                var id = int.Parse(value.key.ToString());
                await repo.DeleteAccountant(id);
                return (RedirectToAction("Index"));
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcelFile(IFormFile FormFile)
        {
            try
            {
                if (FormFile == null)
                {
                    return RedirectToAction("Index");
                }
                //get file name
                var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');

                //get path
                var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

                //create directory "Uploads" if it doesn't exists
                if (!Directory.Exists(MainPath))
                {
                    Directory.CreateDirectory(MainPath);
                }

                //get file path 
                var filePath = Path.Combine(MainPath, FormFile.FileName);
                using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    await FormFile.CopyToAsync(stream);
                }

                //get extension
                string extension = Path.GetExtension(filename);
                if (extension != ".xlsx")
                {
                    ViewBag.ErrorMessage = "Please upload excel with file extension xlsx only.";
                    var model = await repo.GetAccountants();
                    return View("Index", model);
                }

                //Create a new DataTable.
                DataTable dt = new DataTable();

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                {
                    //Read the first Sheet from Excel file.
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                    //Get the Worksheet instance.
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                    //Fetch all the rows present in the Worksheet.
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();



                    //Loop through the Worksheet rows.
                    foreach (Row row in rows)
                    {
                        //Use the first row to add columns to DataTable.
                        if (row.RowIndex.Value == 1)
                        {
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                dt.Columns.Add(GetValue(doc, cell));
                            }
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
                                i++;
                            }
                        }
                    }
                }

                if (dt.Columns.Contains("DebitCredit") && dt.Columns.Contains("Transaction") && dt.Columns.Contains("Date")
                 && dt.Columns.Contains("Description") && dt.Columns.Contains("Category"))
                {
                    dt.Columns.Add("Debit", typeof(decimal));
                    dt.Columns.Add("Credit", typeof(decimal));
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = dr.Field<dynamic>("DebitCredit");
                        if (m != null)
                        {
                            if (m <= 0)
                            {
                                dr["Debit"] = m;
                            }
                            else
                            {
                                dr["Credit"] = m;
                            }
                        }
                        else
                        {
                            dr["Debit"] = 0;
                            dr["Credit"] = 0;
                        }
                    }
                    dt.Columns.Remove("DebitCredit");

                    string connection = Configuration.GetConnectionString("EmployeeDBConnection");

                    using (var sqlCopy = new SqlBulkCopy(connection))
                    {
                        sqlCopy.DestinationTableName = "[Accountants]";
                        sqlCopy.ColumnMappings.Add("Category", "Category");
                        sqlCopy.ColumnMappings.Add("Credit", "Credit");
                        sqlCopy.ColumnMappings.Add("Date", "Date");
                        sqlCopy.ColumnMappings.Add("Debit", "Debit");
                        sqlCopy.ColumnMappings.Add("Description", "Description");
                        sqlCopy.ColumnMappings.Add("Transaction", "Transaction");
                        sqlCopy.BatchSize = 500;
                        sqlCopy.WriteToServer(dt);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Excel do not contain correct columns. \n Excel Should have these columns only 'Date' 'Transaction' 'Description' 'Category' 'DebitCredit'";
                    var model = await repo.GetAccountants();
                    return View("Index", model);
                }
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            ViewBag.ErrorMessage = "";
            return RedirectToAction("Index");
        }

        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }
        public List<Accountants> ConvertDataTable(DataTable tbl)
        {
            List<Accountants> results = new List<Accountants>();

            // iterate over your data table
            foreach (DataRow row in tbl.Rows)
            {
                Accountants convertedObject = ConvertRow(row);
                results.Add(convertedObject);
            }

            return results;
        }
        public Accountants ConvertRow(DataRow row)
        {
            Accountants result = new Accountants();
            result.Category = Convert.ToString(row["Category"]);
            result.Credit = (row["Credit"] == DBNull.Value) ? 0 : (decimal)row["Credit"];
            result.Date = (row["Date"] == DBNull.Value) ? default : DateTime.Parse(Convert.ToString(row["Date"]));
            result.Debit = (row["Debit"] == DBNull.Value) ? 0 : (decimal)row["Debit"];
            result.Description = Convert.ToString(row["Description"]);
            result.Transaction = Convert.ToString(row["Transaction"]);
            return result;
        }

        //public async Task<IActionResult> UrlDataSource([FromBody] DataManagerRequest dm)
        //{
        //    IEnumerable<Accountants> model = await repo.GetAccountants();
        //    DataOperations operation = new DataOperations();
        //    int count = model.Cast<Accountants>().Count();
        //    if (dm.Skip != 0)
        //    {
        //        model = operation.PerformSkip(model, dm.Skip);   //Paging
        //    }
        //    if (dm.Take != 0)
        //    {
        //        model = operation.PerformTake(model, dm.Take);
        //    }
        //    return dm.RequiresCounts ? Json(new { result = model, count = count }) : Json(model);
        //}
    }
}
