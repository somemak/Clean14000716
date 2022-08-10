using System;
using AutoMapper;

using Clean14000716.Application.Common.Mapping;

namespace Clean14000716.Application.Features.School.Models
{
    public class SchoolDto : BaseDto<SchoolDto, Domain.Entities.School>
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}