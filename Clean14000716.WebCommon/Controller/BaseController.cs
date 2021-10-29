using System;
using System.Linq;
using System.Threading.Tasks;
using Clean14000716.Application.Common.Caching;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Common.Utilities;
using Clean14000716.WebCommon.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Clean14000716.WebCommon.Controller
{
    [ApiResultFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRedisManager _redisManager;

        public BaseController(IMediator mediator, IRedisManager redisManager)
        {
            _mediator = mediator;
            _redisManager = redisManager;
        }
 

        public async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request)
        {
            var cacheAttribute = (CachedAttribute)request.GetType().GetCustomAttributes(typeof(CachedAttribute), true).SingleOrDefault();
            if (cacheAttribute != null)
            {
                string key = CacheKeyManager.GetCacheKey(request.GetType().Name, JsonConvert.SerializeObject(request));
                var response = await _redisManager.Get<TResponse>(key);
                if (response == null)
                {
                    response = await _mediator.Send(request);
                    await _redisManager.Create(key, response);
                }
                return Ok(response);
            }

            return Ok(await _mediator.Send(request));
        }
       
    }
}