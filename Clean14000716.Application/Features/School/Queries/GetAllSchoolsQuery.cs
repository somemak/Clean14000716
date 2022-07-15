using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Clean14000716.Application.Common.Caching;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Application.Common.SqlGenerator;
using Clean14000716.Common.Utilities;
using Clean14000716.Domain.Entities.Base;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Clean14000716.Application.Features.School.Queries
{
    [Cached]
    public class GetAllSchoolsQuery : IRequest<List<Domain.Entities.School>>
    {
        public string Name { get; set; }
        public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, List<Domain.Entities.School>>
        {
            private readonly IDatabaseContext _context;
            private readonly IUnitOfWork _unitOfWork;

            public GetAllSchoolsQueryHandler(IDatabaseContext context, IUnitOfWork unitOfWork)
            {
                _context = context;
                _unitOfWork = unitOfWork;
            }
           
            public async Task<List<Domain.Entities.School>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
            {

                //var names = new Domain.Entities.School().CreateInsertCommand(request);

                //var watch = Stopwatch.StartNew();

                //var list1 = await _unitOfWork.SchoolRepository.GetAllListAsync();

                //var conStr = "Server=.;Database=library1000;Trusted_Connection=True;";
                //var query = @"SELECT [Id]
                //              ,[Name]
                //              ,[Created]
                //              ,[CreatedBy]
                //              ,[LastModified]
                //              ,[LastModifiedBy]
                //              ,[IsDeleted]
                //              ,[DeletedAt]
                //              ,[RowVersion]
                //               FROM [dbo].[Schools]";
                //using IDbConnection connection = new SqlConnection(conStr);
                //var res = await connection.QueryAsync<Domain.Entities.School>(query);


                var uuu = await _context.Set<Domain.Entities.School>().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

                //watch.Stop();
                //TimeSpan ts = watch.Elapsed;

                //// Format and display the TimeSpan value.
                //string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                //return list1;
                return uuu;





            }
        }

    }
}