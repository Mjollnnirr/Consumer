using System;
namespace Exceptions.EntityExveptions
{
    public class EntityIsNullException : Exception
    {
        private static readonly string message = "Current enttiy is null";
        public EntityIsNullException() : this(message) {}
        public EntityIsNullException(string message) : base(message) {}
    }
}

