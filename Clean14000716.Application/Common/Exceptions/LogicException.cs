// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/05/28 -- Time : 12:34 ب.ظ

using System;
using Clean14000716.Application.Common.Exceptions.Base;
using Clean14000716.Domain.Enums;

namespace Clean14000716.Application.Common.Exceptions
{
    public class LogicException : CustomApplicationException
    {
        public LogicException()
            : base(StatusCode.LogicError)
        {
        }

        public LogicException(string message)
            : base(StatusCode.LogicError, message)
        {
        }

        public LogicException(object additionalData)
            : base(StatusCode.LogicError, additionalData)
        {
        }

        public LogicException(string message, object additionalData)
            : base(StatusCode.LogicError, message, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(StatusCode.LogicError, message, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(StatusCode.LogicError, message, exception, additionalData)
        {
        }
    }
}