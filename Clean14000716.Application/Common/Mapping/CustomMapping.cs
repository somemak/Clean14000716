using System.Collections.Generic;
using AutoMapper;

namespace Clean14000716.Application.Common.Mapping
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile(IEnumerable<IHaveMapping> mappings)
        {
            foreach (var haveMapping in mappings)
                haveMapping.CreateMapping(this);
            
        }
    }
}