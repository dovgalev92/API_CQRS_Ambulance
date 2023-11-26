using AutoMapper;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.IMapp
{
    public interface IMapping<T> 
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
