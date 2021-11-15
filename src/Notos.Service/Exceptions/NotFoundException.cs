using System;

namespace Notos.Service.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        protected NotFoundException() : base(new NotFoundMessage().ToString())
        {
        }
    }

    internal class NotFoundMessage
    {
        protected const string Title = "Not Found";
    }
}