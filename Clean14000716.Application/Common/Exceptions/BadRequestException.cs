using System;
using Clean14000716.Application.Common.Exceptions.Base;
using Clean14000716.Domain.Enums;

namespace Clean14000716.Application.Common.Exceptions
{
    public class BadRequestException : CustomApplicationException
    {
        public BadRequestException()
            : base(StatusCode.BadRequest)
        {
        }

        public BadRequestException(string message)
            : base(StatusCode.BadRequest, message)
        {
        }

        public BadRequestException(object additionalData)
            : base(StatusCode.BadRequest, additionalData)
        {
        }

        public BadRequestException(string message, object additionalData)
            : base(StatusCode.BadRequest, message, additionalData)
        {
        }

        public BadRequestException(string message, Exception exception)
            : base(StatusCode.BadRequest, message, exception)
        {
        }

        public BadRequestException(string message, Exception exception, object additionalData)
            : base(StatusCode.BadRequest, message, exception, additionalData)
        {
        }
    }
}