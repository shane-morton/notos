using System;
using System.Runtime.Serialization;

namespace Notos.Service.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(new NotFoundMessage().ToString())
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class NotFoundMessage
    {
        protected string NotFoundException()
        {
            return Title;
        }
        protected const string Title = "Not Found";
    }
}