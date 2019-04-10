using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace React.Error
{
    public class InternalServerApiError : ApiError
    {
        public string ExceptionMessage { get; private set; }
        public string InnerExceptionMessage { get; private set; }
        public InternalServerApiError() : base(500, HttpStatusCode.InternalServerError.ToString())
        {

        }
        public InternalServerApiError(string message)
            : base(500, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }

        public InternalServerApiError(Exception ex) : base(500, HttpStatusCode.InternalServerError.ToString())
        {
            this.ExceptionMessage = ex.Message;
            this.InnerExceptionMessage = ex.InnerException.Message;
        }
    }
}
