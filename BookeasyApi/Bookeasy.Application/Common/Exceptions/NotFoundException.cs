using System;

namespace Bookeasy.Application.Common.Exceptions
{
    /// <summary>
    /// Exception that thrown when a resource is not found
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
