using EmployeeManager2.Data;
using EmployeeManager2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    public class AccountantController : Controller
    {   
        private readonly IAccountantRepo repo;

        public AccountantController(IAccountantRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ErrorMessage = "";
            var model = await repo.GetAccountants();            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ICRUDModel<Accountants> value)
        {
            var accountant = value.value;
            await repo.UpdateAccountant(accountant);
            return (RedirectToAction("Index"));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] ICRUDModel<Accountants> value)
        {
            var id = int.Parse(value.key.ToString());
            await repo.DeleteAccountant(id);
            return (RedirectToAction("Index"));
        }

            [HttpPost]
        public async Task<IActionResult> ImportExcelFile(IFormFile FormFile)
        {
            if(FormFile == null)
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
            if(extension != ".xlsx")
            {
                ViewBag.ErrorMessage = "Please upload excel with file extension xlsx only.";                
                return View("Index");
            }

            string conString = string.Empty;

            switch (extension)
            {
                case ".xls": //Excel 97-03.
                    conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
                case ".xlsx": //Excel 07 and above.
                    conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
                case ".xltx": 
                    conString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                    break;
            }

            DataTable dt = new DataTable();
            conString = string.Format(conString, filePath);

            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;

                        //Get the name of First Sheet.
                        connExcel.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        connExcel.Close();

                        //Read Data from First Sheet.
                        connExcel.Open();
                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                        odaExcel.SelectCommand = cmdExcel;
                        odaExcel.Fill(dt);
                        connExcel.Close();
                    }
                }
            }
            if(dt.Columns.Contains("DebitCredit"))
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

                List<Accountants> accountants = ConvertDataTable(dt);
                if(accountants.Count>0)
                {                    
                    await repo.Add(accountants);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Excel do not contain the column with name DebitCredit. \n Excel Should have these columns in this order only 'Date' 'Transaction' 'Description' 'Category' 'DebitCredit'";
                return View("Index");
            }
            
            ViewBag.ErrorMessage = "";
            return RedirectToAction("Index");
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
