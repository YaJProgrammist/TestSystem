using System;
using System.Net;

namespace TestSystem.Infrastructure
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.NotFound;

        public object Value { get; set; }
    }
}
