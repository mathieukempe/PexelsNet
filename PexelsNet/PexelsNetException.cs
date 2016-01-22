using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PexelsNet
{
    [Serializable]
    public class PexelsNetException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public PexelsNetException()
        {
        }

        public PexelsNetException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
