using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Common
{
    public class Response: IResponse
    {
        public Response(ResponseType responseType)
        {
            responseType = ResponseType;
        }

        public Response(ResponseType responseType, string message)
        {
            responseType = ResponseType;
            message = Message;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Succsess,
        ValidationError,
        NotFound
    }
}
