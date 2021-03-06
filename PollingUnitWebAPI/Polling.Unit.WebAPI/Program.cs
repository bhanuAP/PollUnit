﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Polling.Unit.WebAPI
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                BuildWebHost()
                    .Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public static IWebHostBuilder BuildWebHost() =>
            new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
