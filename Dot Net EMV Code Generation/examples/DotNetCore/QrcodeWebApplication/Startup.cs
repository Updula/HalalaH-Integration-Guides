using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using EmvQrCode;

namespace QrcodeWebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";

                Qrcode qr = new Qrcode();

                qr.Merchant_category_code = "5812";
                qr.Merchant_name = "Halalah Grocery";
                qr.Merchant_city = "Riyadh";
                qr.Postal_code = "12345";
                qr.Merchant_name_ar = "هللة";
                qr.Merchant_city_ar = "الرياض";
                qr.Amount = ".50";
                qr.Bill = "1233111";
                qr.Reference = "Unique_Order_ID";
                qr.Terminal = "HG00001";

                await context.Response.WriteAsync(qr.output());
            });
        }
    }
}
