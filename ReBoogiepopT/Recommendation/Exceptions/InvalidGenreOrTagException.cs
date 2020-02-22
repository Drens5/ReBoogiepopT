using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation.Exceptions
{
    [Serializable]
    public class InvalidGenreOrTagException : Exception
    {
        public InvalidGenreOrTagException()
        {

        }

        public InvalidGenreOrTagException(string message)
            : base(message)
        {

        }

        public InvalidGenreOrTagException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected InvalidGenreOrTagException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
