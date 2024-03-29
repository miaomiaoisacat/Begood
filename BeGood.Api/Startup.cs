﻿using BeGood.Api.Filters;
using BeGood.Core.Interfaces;
using BeGood.Core.Interfaces.Repositories.Bases;
using BeGood.DataMySql;
using BeGood.DataMySql.Repositories.Bases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeGood.Api
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
            services.AddSingleton<IConFactory, ConFactoryMySql>(x =>
            {
                return new ConFactoryMySql() { ConStr = this.Configuration.GetSection("ConnectionString:MySql").Value };
            });

            services
                .AddScoped<IUnitOfWork, UnitOfWorkMySql>()
                .AddScoped<IMenuRepository, MenuRepository>()
                .AddScoped<IMenuActionRepository, MenuActionRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IRoleMenuActionRepository, RoleMenuActionRepository>()
                .AddScoped<IStoreRepository, StoreRepository>()
                .AddScoped<IStoreSysRepository, StoreSysRepository>()
                .AddScoped<ISysRepository, SysRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddMvc(x =>
            {
                x.Filters.Add<CusAuthorizeFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
