
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HealthChecker.PersistData
{
    public class ReadPersistedData
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        const string FileLocation = "C:\\PROJECTS\\REPOS\\dotnet-master\\dotnet-master\\HealthChecker\\PersistedData\\LastTimeUp.txt";

        public ReadPersistedData(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public void WriteData(string serverId, string date)
        {
            //string contentRootPath = _hostingEnvironment.ContentRootPath;
            Console.WriteLine(FileLocation);
            //var logPath = contentRootPath + FileLocation;
            //Console.WriteLine(logPath);

            using (StreamWriter outputFile = System.IO.File.AppendText(FileLocation))
            {
                outputFile.WriteLine("Server Id: "+serverId + "; LastTimeUp: " + date);
            }
        }

    }
}


