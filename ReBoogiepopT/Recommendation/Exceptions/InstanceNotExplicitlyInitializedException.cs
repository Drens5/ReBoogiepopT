using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation.Exceptions
{
    [Serializable]
    public class InstanceNotExplicitlyInitializedException : Exception
    {
        public InstanceNotExplicitlyInitializedException()
        {

        }

        public InstanceNotExplicitlyInitializedException(string message)
            : base(message)
        {

        }

        public InstanceNotExplicitlyInitializedException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected InstanceNotExplicitlyInitializedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }
    }
}
