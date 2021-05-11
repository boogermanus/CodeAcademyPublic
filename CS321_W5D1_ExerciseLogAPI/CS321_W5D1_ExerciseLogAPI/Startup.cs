using System.Text;
using CS321_W5D1_ExerciseLogAPI.Core.Models;
using CS321_W5D1_ExerciseLogAPI.Core.Services;
using CS321_W5D1_ExerciseLogAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace CS321_W5D1_ExerciseLogAPI
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            services.AddScoped<IActivityTypeService, ActivityTypeService>();

            services.AddMvc();
        }

        // TODO: Class Project: Seed admin user
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            SeedAdminUser(userManager, roleManager);
        }

        private void SeedAdminUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var result = roleManager.CreateAsync(adminRole).Result;
            }

            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new User
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };

                var result = userManager.CreateAsync(user, "Passw0rd!").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
