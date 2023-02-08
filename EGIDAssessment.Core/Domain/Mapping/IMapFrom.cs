using AutoMapper;

namespace EGIDAssessment.Core.Domain.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}