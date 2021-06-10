using EmployeeManager2.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2
{

    public class InsertErrorLog
    {
        private static readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public static void saveerror(Exception ex)
        {
            
             ErrorLogs errorLogsmodel = new ErrorLogs();
            string message = "";
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
            message += string.Format("StackTrace: {0}", trace.GetFrame(0).GetFileLineNumber());
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += string.Format("Error Url: {0}", ex.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            errorLogsmodel.ErrorMsg = message.ToString();
            errorLogsmodel.ErrorType = ex.GetType().Name.ToString();
            errorLogsmodel.CreatedOn = DateTime.Now;
            _context.ErrorLogs.Add(errorLogsmodel); 
            _context.SaveChanges();


        }
    }
}
