using System;
namespace Exceptions.ProgramExceptions;

public class DataMappingException : Exception
{
    private static readonly string _message;
    public DataMappingException() : this(_message) {}

    public DataMappingException(string message) : base (message) {}

    static DataMappingException() => _message = "Error happened while mapping data";
}

