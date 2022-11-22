using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Common
{
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public List<CustomValidationError> Errors { get; set; }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            Errors = errors;
            Data = data;
        }
    }
}
