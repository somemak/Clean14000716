using System.Collections.Generic;
using System.Threading.Tasks;
using Clean14000716.Application.Common.Caching;
using Clean14000716.Application.Common.Exceptions;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.EFCore;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Application.Features.School.Commands.Create;
using Clean14000716.Application.Features.School.Models;
using Clean14000716.Application.Features.School.Queries;
using Clean14000716.Domain.Entities;
using Clean14000716.Domain.Entities.Identity;
using Clean14000716.Persistence.EFCore.Context.SqlServer;
using Clean14000716.WebCommon.ApiResult;
using Clean14000716.WebCommon.Controller;
using Clean14000716.WebCommon.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean14000716.Api.Controllers
{

    
    /// <summary>
    /// asdfsdfsdfsdfsdfsdf
    /// </summary>
    public class SchoolController : BaseController
    {
        private readonly IDatabaseContext _context;
        private readonly IJwtServices _jwtServices;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="redisManager"></param>
        /// <param name="context"></param>
        /// <param name="jwtServices"></param>
        public SchoolController(IMediator mediator, IRedisManager redisManager, IDatabaseContext context, IJwtServices jwtServices) : base(mediator, redisManager)
        {
            _context = context;
            _jwtServices = jwtServices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createSchoolCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Create(CreateSchoolCommand createSchoolCommand) => await Execute(createSchoolCommand);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<ActionResult<List<SchoolDto>>> GetAll() => await Execute(new GetAllSchoolsQuery());


        /// <summary>
        /// helooooooooooooooooooooooooo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<string> GetToken(string name, string pass)
        {
            //var user = await _context.Set<User>()
            //    .FirstOrDefaultAsync(user1 => user1.Name == name && user1.Password == pass);
            //if (user == null)
            //{
            //    throw new BadRequestException();
            //}
            return "sdfsdf1";
            //return _jwtServices.GenerateToken(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public  string GetPic(string name, string pass) => "ali";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
     
        public async Task<ActionResult<SchoolDto>> GetFirstSchool() => await Execute(new GetFirstSchoolQuery());



    }
}