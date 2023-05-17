using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mappings(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
