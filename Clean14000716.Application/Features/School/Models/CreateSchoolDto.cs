using AutoMapper;

using Clean14000716.Application.Common.Mapping;

namespace Clean14000716.Application.Features.School.Models
{
    public class CreateSchoolDto : BaseDto<CreateSchoolDto, Domain.Entities.School>
    {
        public string Name { get; set; }
    }
}