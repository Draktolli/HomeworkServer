using Homework5.Consumers;
using Homework5.DB;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework5.Mapper;
using Homework5.Repository;
using Homework5Client.DTO;

namespace Homework5
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			using (DBContext dbContext = new DBContext())
			{
				dbContext.Database.Migrate();
			}
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddTransient<IDirectorRepository, DirectorRepository>();
			services.AddTransient<IGetDirectorMapper, GetDirectorMapper>();
			services.AddTransient<IPostDirectorMapper, PostDirectorMapper>();
			services.AddTransient<IUpdateDirectorMapper, UpdateDirectorMapper>();
			services.AddDbContext<DBContext>();

			services.AddMassTransit(mt =>
			{
				mt.AddConsumer<PostDirectorConsumer>();
				mt.AddConsumer<GetDirectorConsumer>();
				mt.AddConsumer<DeleteDirectorConsumer>();
				mt.AddConsumer<UpdateDirectorConsumer>();

				mt.UsingRabbitMq((context, config) =>
				{
					config.Host("localhost", "/", host =>
					{
						host.Username("guest");
						host.Password("guest");
					});
					config.ReceiveEndpoint("post", x => x.ConfigureConsumer<PostDirectorConsumer>(context));
					config.ReceiveEndpoint("get", x => x.ConfigureConsumer<GetDirectorConsumer>(context));
					config.ReceiveEndpoint("delete", x => x.ConfigureConsumer<DeleteDirectorConsumer>(context));
					config.ReceiveEndpoint("update", x => x.ConfigureConsumer<UpdateDirectorConsumer>(context));
				});
			});
			services.AddMassTransitHostedService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices
				.GetRequiredService<IServiceScopeFactory>()
				.CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<DBContext>();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
