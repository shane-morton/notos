using System;
using System.Runtime.Serialization;

namespace Notos.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(new NotFoundMessage().ToString())
        {
        }
    }

    internal class NotFoundMessage
    {
        public const string Title = "Not Found";
    }
}