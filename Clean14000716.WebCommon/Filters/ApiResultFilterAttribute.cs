using System.Linq;
using Clean14000716.Domain.Enums;
using Clean14000716.WebCommon.ApiResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean14000716.WebCommon.Filters
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            switch (context.Result)
            {
                case OkObjectResult okObjectResult:
                    {
                        var apiResult = new ApiResult<object>(true, StatusCode.Success, okObjectResult.Value);
                        context.Result = new JsonResult(apiResult) { StatusCode = okObjectResult.StatusCode };
                        break;
                    }
                case OkResult okResult:
                    {
                        var apiResult = new ApiResult.ApiResult(true, StatusCode.Success);
                        context.Result = new JsonResult(apiResult) { StatusCode = okResult.StatusCode };
                        break;
                    }
                case BadRequestResult badRequestResult:
                    {
                        var apiResult = new ApiResult.ApiResult(false, StatusCode.BadRequest);
                        context.Result = new JsonResult(apiResult) { StatusCode = badRequestResult.StatusCode };
                        break;
                    }
                case BadRequestObjectResult badRequestObjectResult:
                    {

                        var message = badRequestObjectResult.Value.ToString();
                        if (badRequestObjectResult.Value is SerializableError errors)
                        {
                            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                            message = string.Join(" | ", errorMessages);
                        }

                        if (badRequestObjectResult.Value is ValidationProblemDetails problemDetails)
                        {
                            var errorMessages = problemDetails.Errors.SelectMany(p => (string[])p.Value).Distinct();
                            message = string.Join(" | ", errorMessages);
                        }
                        var apiResult = new ApiResult.ApiResult(false, StatusCode.BadRequest, message);
                        context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
                        break;
                    }
                case ContentResult contentResult:
                    {
                        var apiResult = new ApiResult.ApiResult(true, StatusCode.Success, contentResult.Content);
                        context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
                        break;
                    }
                case NotFoundResult notFoundResult:
                    {
                        var apiResult = new ApiResult.ApiResult(false, StatusCode.NotFound);
                        context.Result = new JsonResult(apiResult) { StatusCode = notFoundResult.StatusCode };
                        break;
                    }
                case NotFoundObjectResult notFoundObjectResult:
                    {
                        var apiResult = new ApiResult<object>(false, StatusCode.NotFound, notFoundObjectResult.Value);
                        context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
                        break;
                    }
                case ObjectResult { StatusCode: null, Value: not ApiResult.ApiResult } objectResult:
                    {
                        var apiResult = new ApiResult<object>(true, StatusCode.Success, objectResult.Value);
                        context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
                        break;
                    }
            }

            base.OnResultExecuting(context);
        }
    }
}