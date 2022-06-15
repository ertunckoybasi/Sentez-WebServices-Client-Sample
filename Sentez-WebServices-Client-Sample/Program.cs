using Microsoft.Extensions.DependencyInjection;
using Sentez_WebServices_Client_Sample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentez_WebServices_Client_Sample
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmRestApi());
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var formRestApi = serviceProvider.GetRequiredService<frmRestApi>();
                Application.Run(formRestApi);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(1000);
            
            services.AddScoped<frmRestApi>();
            services.AddScoped<ISentezService, SentezService>();
            services.AddSingleton<HttpClient>(httpClient);
        }
    }
}
