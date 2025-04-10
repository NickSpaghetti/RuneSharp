namespace RuneSharp.Models.OsrsStandardAccount.Exceptions;

public class StandardAccountNotFoundException: Exception
{
    public StandardAccountNotFoundException() : base() { }
    public StandardAccountNotFoundException(string message, Exception? innerException) : base(message,innerException) { }
    public StandardAccountNotFoundException(string message) : base(message,null) { }
}