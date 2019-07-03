using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{    
    public class FareException : Exception
    {
        public FareException()
        {
        }

        public FareException(string message) : base(message)
        {
        }

        public FareException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FareException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
