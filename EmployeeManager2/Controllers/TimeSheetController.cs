using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager2.Data;
using EmployeeManager2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager2.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IInsertErrorLog log;

        public TimeSheetController(AppDbContext context, IInsertErrorLog log)
        {
            _context = context;
            this.log = log;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void filldropdown()
        {
            try
            {


                var lastnameList = (from ts in _context.Timesheet
                                    select new SelectListItem()
                                    {
                                        Text = ts.LastName,
                                        Value = ts.LastName,
                                    }).Distinct().ToList();

                lastnameList.Insert(0, new SelectListItem()
                {
                    Text = "All Names",
                    Value = "All Names"
                });

                ViewBag.Listofnames = lastnameList;
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }

        }

        public IActionResult List()
        {
            try
            {
                filldropdown();
                var sum1 = _context.Timesheet.Sum(p => p.Hours);

                ViewBag.total = sum1.ToString();
                var ts = _context.Timesheet.ToList();
                return View(ts);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();
        }
        [HttpGet]
        //[Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Create(TimeSheet ts)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _context.Timesheet.Add(ts);
                _context.SaveChanges();

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();

        }

        [HttpGet]
        [Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Edit(int id)
        {
            try
            {

                var ts = _context.Timesheet.First(s => s.ID == id);
                return View(ts);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();

        }

        [HttpPost]
        [Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Edit(TimeSheet ts)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                _context.Timesheet.Attach(ts);
                _context.Entry(ts).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Delete(int id)
        {
            try
            {
                var ts = _context.Timesheet.First(s => s.ID == id);
                return View(ts);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UtilityClass.AdminUserRole)]
        public IActionResult Delete(TimeSheet ts)
        {
            try
            {

                _context.Timesheet.Remove(ts);
                _context.SaveChanges();

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var ts = _context.Timesheet.First(s => s.ID == id);
                return View(ts);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            return View();
        }

        public ActionResult Search()
        {
            try
            {
                string fromdate = HttpContext.Request.Query["from"].ToString();
                string todate = HttpContext.Request.Query["to"].ToString();
                string bylastname = HttpContext.Request.Query["bylastname"].ToString();
                string byfirstname = HttpContext.Request.Query["byfirstname"].ToString();

                ViewBag.name = byfirstname;
                ViewBag.fromdate = fromdate;
                ViewBag.todate = todate;

                IQueryable<string> TimesheetQuery = from m in _context.Timesheet
                                                    orderby m.LastName
                                                    select m.LastName;

                var timesheet = from m in _context.Timesheet
                                select m;
                if (!string.IsNullOrWhiteSpace(byfirstname) && !string.IsNullOrWhiteSpace(fromdate) && !string.IsNullOrWhiteSpace(todate))
                {
                    timesheet = timesheet.Where(s => s.Date >= Convert.ToDateTime(fromdate) && s.Date <= Convert.ToDateTime(todate) && s.FirstName.Contains(byfirstname));

                    var sum5 = timesheet.Where(s => s.Date >= Convert.ToDateTime(fromdate) && s.Date <= Convert.ToDateTime(todate) && s.FirstName.Contains(byfirstname)).Sum(a => a.Hours);

                    ViewBag.total = sum5.ToString();
                    filldropdown();
                    return View("List", timesheet);
                }

                if (!string.IsNullOrWhiteSpace(byfirstname))
                {
                    timesheet = timesheet.Where(s => s.FirstName.Contains(byfirstname));

                    var sum3 = timesheet.Where(s => s.FirstName.Contains(byfirstname)).Sum(a => a.Hours);

                    ViewBag.total = sum3.ToString();
                    filldropdown();
                    return View("List", timesheet);
                }

                if (bylastname != "All Names")
                {
                    timesheet = timesheet.Where(s => s.LastName.Contains(bylastname));

                    var sum3 = timesheet.Where(s => s.LastName.Contains(bylastname)).Sum(a => a.Hours);

                    ViewBag.total = sum3.ToString();
                    //filldropdown();
                    //return View("List", timesheet);
                }

                if (!string.IsNullOrWhiteSpace(todate))
                {
                    if (string.IsNullOrWhiteSpace(todate))
                    {
                        todate = DateTime.Today.ToString("yyyy-MM-dd");
                    }
                    if (!string.IsNullOrWhiteSpace(todate))
                    {
                        timesheet = timesheet.Where(s => s.Date >= Convert.ToDateTime(fromdate) && s.Date <= Convert.ToDateTime(todate));

                        var sum2 = timesheet.Where(s => s.Date >= Convert.ToDateTime(fromdate) && s.Date <= Convert.ToDateTime(todate)).Sum(p => p.Hours);

                        ViewBag.total = sum2.ToString();
                        //filldropdown();
                        //return View("List", timesheet);

                    }
                }
                filldropdown();
                return View("List", timesheet);
            }
            catch (Exception ex)
            {
                log.saveerror(ex);
            }
            //  return View();
            return RedirectToAction("List");
        }
    }
}