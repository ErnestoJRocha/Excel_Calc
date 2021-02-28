using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db_teste.Auxiliar;
using Db_teste.Model;
using Db_teste.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Db_teste
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      //var connection = @"Server=SBS-ERNROC;Database=syfidb;Trusted_Connection=True; ";
      // var connection = @"Server=SBS-CARDIN;Database=syfidb;Trusted_Connection=True; ";
      var connection = @"Server=23.102.32.185;Database=Sybase_AppLife_Timesheets_Dev;user=timesheet_dev;password=timesheet_dev;Trusted_Connection=False;MultipleActiveResultSets=true; ";
      var cnxTimesheet = @"Server=23.102.32.185;Database=Sybase_Sybase_Timesheet_Dev;user=timesheet_dev;password=timesheet_dev;Trusted_Connection=False;MultipleActiveResultSets=true; ";
      //services.AddDbContext<timesheetDbContext>(options => options.UseSqlServer(connection));
      services.AddDbContext<syfidbContext>(options => options.UseSqlServer(connection));
      services.AddDbContext<Timesheet_DevDbContext>(options => options.UseSqlServer(cnxTimesheet));
            
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();



      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      /*app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
      });*/
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Areas}/{action=Index}/{id?}");
      });
      /*app.UseMvc(routes =>
      {
          routes.MapRoute(
              name: "default",
              template: "{controller=Areas}/{action=Index}/{id?}");
      });*/
    }
  }
}
