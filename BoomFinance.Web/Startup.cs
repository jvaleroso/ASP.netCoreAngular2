using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BoomFinance.Core;
using BoomFinance.Core.Repository;
using BoomFinance.Data.Repository;
using BoomFinance.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BoomFinance
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<FinanceContext>(opt => opt.UseInMemoryDatabase());
			// Add framework services.
			services.AddMvc();

			services.Configure<Settings>(options =>
			{
				options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
				options.Database = Configuration.GetSection("MongoConnection:Database").Value;
			});

			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,
							  IHostingEnvironment env,
							  ILoggerFactory loggerFactory,
							  FinanceContext financeContext)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			AddDbContextTestData(financeContext);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

				routes.MapSpaFallbackRoute(
					name: "spa-fallback",
					defaults: new { controller = "Home", action = "Index" });
			});
		}

		void AddDbContextTestData(FinanceContext context)
		{
			context.Banks.Add(new Bank { Id = Guid.NewGuid().ToString(), Name = "DBS" });
			context.Banks.Add(new Bank { Id = Guid.NewGuid().ToString(), Name = "OCBC" });
			context.Banks.Add(new Bank { Id = Guid.NewGuid().ToString(), Name = "POSB" });
			context.Banks.Add(new Bank { Id = Guid.NewGuid().ToString(), Name = "CITI Bank" });
			context.SaveChangesAsync();
		}
	}
}
