using AutoMapper;

namespace Shared.Mapper
{
    public class Mapper : IMapper
    {
        public Mapper()
        {
            var profiles = new List<Profile>
            {

            };
            Mapper.Initialize(config =>
            {
                foreach (var item in profiles)
                {
                    config.AddProfile(item);
                }
            });
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
