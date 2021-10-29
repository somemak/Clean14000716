using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Mapping;
using Clean14000716.Application.Features.School.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean14000716.Application.Features.School.Queries
{
    public class GetFirstSchoolQuery : IRequest<SchoolDto>
    {
        
        public class GetFirstSchoolQueryHandler : IRequestHandler<GetFirstSchoolQuery, SchoolDto>
        {
            
            private readonly IDatabaseContext _context;
            private readonly IMapper _mapper;

            public GetFirstSchoolQueryHandler(IDatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SchoolDto> Handle(GetFirstSchoolQuery request, CancellationToken cancellationToken)
            {

               


                var pp = SchoolDto.FromEntity(await _context.Set<Domain.Entities.School>().FirstOrDefaultAsync(cancellationToken));
 


                 return pp;
            }
        }

    }
}