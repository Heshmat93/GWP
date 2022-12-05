namespace Infrastructure
{
    using Application.Common.Interfaces;
    using Application.Dummies;
    using Application.Users;
    using AutoMapper;
    using CleanArchitecture.Application.Common.Mappings;
    using GWPPlatform.Domain.Identity;
    using Infrastructure.Persistence;
    using Infrastructure.Persistence.Configuration;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class DependcyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            _ = services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            services.AddScoped<IDummySerivce, DummySerivce>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }
    }
}
