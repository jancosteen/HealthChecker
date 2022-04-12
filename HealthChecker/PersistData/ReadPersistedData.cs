
using HealthChecker.Data;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HealthChecker.PersistData
{
    public class ReadPersistedData
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private AppData _appData;
        const string FileName = "LastTimeUp.txt";

        public ReadPersistedData(IWebHostEnvironment hostingEnvironment, IConfiguration configuration, AppData appData)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _appData = appData;
        }

        public void WriteData()
        {
            var fileLocation = Path.Combine(_hostingEnvironment.ContentRootPath, FileName);
            Console.WriteLine(fileLocation);

            using (StreamWriter outputFile = File.CreateText(fileLocation))
            {
                foreach(Server server in _appData.servers)
                {
                    if(server.LastTimeUp != null)
                        outputFile.WriteLine(server.Id + ", " + server.LastTimeUp.Trim()+", "+server.Status.Trim());
                    else
                        outputFile.WriteLine(server.Id + ", " + "" + ", " + server.Status.Trim());
                }
            }            
            
        }

        public void ReadData()
        {
            var fileLocation = Path.Combine(_hostingEnvironment.ContentRootPath, FileName);
            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(fileLocation).ToList();

                Console.WriteLine(lines);
                foreach (string line in lines)
                {
                    string[] items = line.Split(',');
                    _appData.servers[Convert.ToInt32(items[0]) - 1].LastTimeUp = items[1].Trim();
                    _appData.servers[Convert.ToInt32(items[0]) - 1].Status = items[2].Trim();
                    Console.WriteLine(_appData.servers);
                }
            }
            catch
            {
                Console.WriteLine("Blank File");
            }

            

            //Console.ReadLine();
        }

    }
}


