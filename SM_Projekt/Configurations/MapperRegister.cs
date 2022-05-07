using Application.Mappers;
using AutoMapper;

namespace SM_Projekt.Configurations
{
    public static class MapperRegister
    {
        public static void RegisterMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfig = new(mc =>
            {
                mc.AddProfile(new UserMappingProfile());
                mc.AddProfile(new AnswerMappingProfile());
                mc.AddProfile(new QuestionMappingProfile());
                mc.AddProfile(new PollMappingProfile());
                mc.AddProfile(new VoteMappingProfile());
                mc.AddProfile(new NotificationMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
