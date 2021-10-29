// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/05/28 -- Time : 12:27 ب.ظ

using System;
using System.Net;
using Clean14000716.Domain.Enums;

namespace Clean14000716.Application.Common.Exceptions.Base
{
    public class CustomApplicationException : Exception
    {
        public StatusCode StatusCode { get; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object AdditionalData { get; set; }

        public CustomApplicationException()
              : this(StatusCode.ServerError)
        {
        }

        public CustomApplicationException(StatusCode statusCode)
            : this(statusCode, null)
        {
        }

        public CustomApplicationException(string message)
            : this(StatusCode.ServerError, message)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message)
            : this(statusCode, message, HttpStatusCode.InternalServerError)
        {
        }

        public CustomApplicationException(string message, object additionalData)
            : this(StatusCode.ServerError, message, additionalData)
        {
        }

        public CustomApplicationException(StatusCode statusCode, object additionalData)
            : this(statusCode, null, additionalData)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, HttpStatusCode httpStatusCode)
            : this(statusCode, message, httpStatusCode, null)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(statusCode, message, httpStatusCode, null, additionalData)
        {
        }

        public CustomApplicationException(string message, Exception exception)
            : this(StatusCode.ServerError, message, exception)
        {
        }

        public CustomApplicationException(string message, Exception exception, object additionalData)
            : this(StatusCode.ServerError, message, exception, additionalData)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, Exception exception)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, Exception exception, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception)
            : this(statusCode, message, httpStatusCode, exception, null)
        {
        }

        public CustomApplicationException(StatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            StatusCode = statusCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}