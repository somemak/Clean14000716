// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/05/28 -- Time : 12:33 ب.ظ

using System;
using Clean14000716.Application.Common.Exceptions.Base;
using Clean14000716.Domain.Enums;

namespace Clean14000716.Application.Common.Exceptions
{
    public class NotFoundException : CustomApplicationException
    {
        public NotFoundException()
            : base(StatusCode.NotFound)
        {
        }

        public NotFoundException(string message)
            : base(StatusCode.NotFound, message)
        {
        }

        public NotFoundException(object additionalData)
            : base(StatusCode.NotFound, additionalData)
        {
        }

        public NotFoundException(string message, object additionalData)
            : base(StatusCode.NotFound, message, additionalData)
        {
        }

        public NotFoundException(string message, Exception exception)
            : base(StatusCode.NotFound, message, exception)
        {
        }

        public NotFoundException(string message, Exception exception, object additionalData)
            : base(StatusCode.NotFound, message, exception, additionalData)
        {
        }
    }
}