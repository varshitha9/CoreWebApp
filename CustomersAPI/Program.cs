// Licensed under the MIT license. See LICENSE file in the samples root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

namespace CustomersAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {


      var host = new WebHostBuilder()

          .UseKestrel()
          .ConfigureServices(serviceCollection =>
          {
            serviceCollection.AddSingleton(new ResourceManager("CustomersAPI.Resources.Controllers.CustomersController",
                                                 typeof(Startup).GetTypeInfo().Assembly));
          })
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseIISIntegration()
          .UseStartup<Startup>()
          .Build();

      host.Run();
    }

  }
}
