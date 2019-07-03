using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    public class JourneyException : Exception
    {
        public JourneyException()
        {
        }

        public JourneyException(string message) : base(message)
        {
        }

        public JourneyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JourneyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
