using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using ResumeVault.Core.AutoMapperConfig;
using ResumeVault.Core.Services.Implementations;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Data.Repositories.Implementations;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVaultBE.Core.Context;

namespace ResumeVaultBE.Extension
{
    public static class StartUpExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResumeVaultDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Connection"));
            });

            services.AddAutoMapper(typeof(AutoMapperConfigProfile));

            //var cloudinarySettings = configuration.GetSection("Cloudinary");
            //var account = new Account(
            //    cloudinarySettings["CloudName"],
            //    cloudinarySettings["ApiKey"],
            //    cloudinarySettings["ApiSecret"]
            //    );
            //var cloudinary = new Cloudinary(account);
            //services.AddSingleton(cloudinary);


            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
