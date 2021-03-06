using DAL.Interfaces;
using DAL.Services;
using BLL.Services;
using BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.HubTools;

namespace ReseauSocial.Asp
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
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "ReseauSociaSession.cookie";
                options.IdleTimeout = TimeSpan.FromHours(12);
            });

            services.AddSignalR();

            //injection SessionHelper
            services.AddScoped<ISessionHelpers, SessionHelpers>();

            //injection MessageHub
            services.AddScoped<IMessageHub, MessageHub>();

            //injection CommentHub
            services.AddScoped<ICommentHub, CommentHub>();

            //Injection des services user
            services.AddScoped<IUserDalService, UserDalService>();
            services.AddScoped<IUserBllService, UserBllService>();

            //Injection des services message
            services.AddScoped<IMessageDal, MessageDalService>();
            services.AddScoped<IMessageBll, MessageBllService>();

            //Injection des services article
            services.AddScoped<IArticleDal, ArticleDalService>();
            services.AddScoped<IArticleBll, ArticleBllService>();

            //Injection des services comenentaire
            services.AddScoped<ICommentDal, CommentDalService>();
            services.AddScoped<ICommentBll, CommentBllService>();

            //injection follower
            services.AddScoped<IFollowerDal, FollowerDalService>();
            services.AddScoped<IFollowerBll, FollowerBllService>();

            //injection blacklist
            services.AddScoped<IBlacklistDal, BlacklistDalService>();
            services.AddScoped<IBlacklistBll, BlacklistBllService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //je lui dit qu'on va utiliser les sessions
            app.UseSession();
            //on va utiliser des polices (des r?gles)
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<MessageHub>("/messageHub");
                endpoints.MapHub<CommentHub>("/commentHub");
            });
        }
    }
}
