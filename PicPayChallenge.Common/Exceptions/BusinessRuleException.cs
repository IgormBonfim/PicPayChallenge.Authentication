using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Exceptions
{
    public class BusinessRuleException : HttpException
    {
        public BusinessRuleException() : base(HttpStatusCode.BadRequest)
        {

        }
        public BusinessRuleException(string? message) : base(message, HttpStatusCode.BadRequest)
        {
        }

        public BusinessRuleException(string? message, Exception? innerException) : base(message, innerException, HttpStatusCode.BadRequest)
        {
        }

        protected BusinessRuleException(SerializationInfo info, StreamingContext context) : base(info, context, HttpStatusCode.BadRequest)
        {
        }
    }
}
