using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaperNew.Classes.Exceptions
{
    class ConnectionFailedException : Exception
    {
        public ConnectionFailedException()
        {
            
        }

        public ConnectionFailedException(string message)
            :base(message)
        {
            
        }

        public ConnectionFailedException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }

        protected ConnectionFailedException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            
        }
    }
}
