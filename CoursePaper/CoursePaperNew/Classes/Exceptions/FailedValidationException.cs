using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaperNew.Classes.Exceptions
{
    public class FailedValidationException : Exception
    {
        public FailedValidationException()
        {
            
        }

        public FailedValidationException(string message)
            :base(message)
        {
            
        }

        public FailedValidationException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }

        protected FailedValidationException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            
        }
    }
}
