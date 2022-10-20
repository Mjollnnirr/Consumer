using System;
namespace Exceptions.EntityExveptions;

public class InvalidEntityException : Exception
{
    private static string _message;
    public InvalidEntityException(string entityName) : base(string.Concat(entityName, _message))
    {
    }

    static InvalidEntityException()
    {
        _message = " cannot be null";
    }
}

