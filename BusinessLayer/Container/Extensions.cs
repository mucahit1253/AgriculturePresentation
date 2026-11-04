using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceManager>();
        services.AddScoped<IServiceDal, EfServiceDal>();
        services.AddScoped<ITeamService, TeamManager>();
        services.AddScoped<ITeamDal, EfTeamDal>();
        services.AddScoped<TeamValidator>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        services.AddScoped<IImageService, ImageManager>();
        services.AddScoped<IImageDal, EfImageDal>();
        services.AddScoped<ImageValidator>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<AddressValidator>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<IAdminService, AdminManager>();
        services.AddScoped<IAdminDal, EfAdminDal>();
    }
}