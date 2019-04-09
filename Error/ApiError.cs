using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.Error
{
    public class ApiError
    {
        public int StatusCode { get; private set; }
        public string Description { get; private set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiError(int statusCode, string description)
        {
            this.StatusCode = statusCode;
            this.Description = description;
        }

        public ApiError(int statusCode, string description, string message) : this(statusCode, description)
        {
            this.Message = message;
        }
    }
}
