
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2.Data
{
    public static class BlobConnectionClass
    {
        static string account = "reimbursmentstorage";
        static string key = "taOqpnL5gGFkrFES3cBQOlaH5ThJv/SGt8mEZDlNMFHRaCIAHkreI970FImjloDExfO2dcpeyf3v/SRHbkNGtg==";             
        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
