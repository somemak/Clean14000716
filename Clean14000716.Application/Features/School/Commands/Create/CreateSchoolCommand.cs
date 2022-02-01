using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean14000716.Application.Common.Exceptions;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Application.Features.School.Models;
using Clean14000716.Application.Features.School.Queries;
using Clean14000716.Domain.Entities;
using Clean14000716.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Distributed;

namespace Clean14000716.Application.Features.School.Commands.Create
{
    public class CreateSchoolCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, int>
        {


            private readonly IDatabaseContext _context;
            private readonly IRedisManager _redisManager;
            public DbSet<Domain.Entities.School> Schools { get; }

            public CreateSchoolCommandHandler(IDatabaseContext context, IRedisManager redisManager)
            {
                _context = context;
                _redisManager = redisManager;
                Schools = _context.Set<Domain.Entities.School>();
            }

            public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
            {
                //List<Domain.Entities.School> schools = new List<Domain.Entities.School>();
                //for (int i = 0; i < 10000; i++)
                //{
                //    var school = new Domain.Entities.School() { Name = request.Name, Created = DateTime.Now, CreatedBy = "ali" };
                //    schools.Add(school);
                    
                //}
                //await _context.Set<Domain.Entities.School>().AddRangeAsync(schools, cancellationToken);
                //await _context.SaveChangesAsync(cancellationToken);


                var first = _context.Set<Domain.Entities.School>().Select(school => new SchoolDto()
                {
                    Name = school.Name,Created = school.Created
                }).ToList();



                await _redisManager.DeleteKeysForRequest(nameof(Domain.Entities.School) + "s");

                return 10;
            }
        }
    }
}