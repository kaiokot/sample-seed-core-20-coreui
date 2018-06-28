using Seed.Domain.Entitys;
using Seed.Dto;

namespace Seed.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(Sample), typeof(SampleDto)).ReverseMap();
            CreateMap(typeof(Sample), typeof(SampleDtoSpecialized));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedResult));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedReport));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedDetails));
            CreateMap(typeof(SampleType), typeof(SampleTypeDto)).ReverseMap();
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecialized));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedResult));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedReport));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedDetails));
            CreateMap(typeof(SampleTag), typeof(SampleTagDto)).ReverseMap();
            CreateMap(typeof(SampleTag), typeof(SampleTagDtoSpecialized));
            CreateMap(typeof(SampleTag), typeof(SampleTagDtoSpecializedResult));
            CreateMap(typeof(SampleTag), typeof(SampleTagDtoSpecializedReport));
            CreateMap(typeof(SampleTag), typeof(SampleTagDtoSpecializedDetails));
            CreateMap(typeof(ManySampleType), typeof(ManySampleTypeDto)).ReverseMap();
            CreateMap(typeof(ManySampleType), typeof(ManySampleTypeDtoSpecialized));
            CreateMap(typeof(ManySampleType), typeof(ManySampleTypeDtoSpecializedResult));
            CreateMap(typeof(ManySampleType), typeof(ManySampleTypeDtoSpecializedReport));
            CreateMap(typeof(ManySampleType), typeof(ManySampleTypeDtoSpecializedDetails));

        }

    }
}
