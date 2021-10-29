using System.Collections.Generic;
using System.Threading.Tasks;
using Clean14000716.Application.Common.Caching;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Application.Features.School.Commands.Create;
using Clean14000716.Application.Features.School.Queries;
using Clean14000716.Domain.Entities;
using Clean14000716.Persistence.EFCore.Context.SqlServer;
using Clean14000716.WebCommon.ApiResult;
using Clean14000716.WebCommon.Controller;
using Clean14000716.WebCommon.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean14000716.Api.Controllers
{

    
    public class SchoolController : BaseController
    {
        public SchoolController(IMediator mediator, IRedisManager redisManager) : base(mediator, redisManager)
        {
            
        }

        /// <summary>
        /// sd.fskldjfslkdjfaskdjf;alsdkfja;lksdfj
        /// </summary>
        /// <param name="createSchoolCommand"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateSchoolCommand createSchoolCommand) => await Execute(createSchoolCommand);

        [HttpGet]
        public async Task<IActionResult> GetAll() => await Execute(new GetAllSchoolsQuery());

        //[HttpGet]
        //public async Task<IActionResult> GetFirstSchool() => await Execute(new GetFirstSchoolQuery());



    }
}