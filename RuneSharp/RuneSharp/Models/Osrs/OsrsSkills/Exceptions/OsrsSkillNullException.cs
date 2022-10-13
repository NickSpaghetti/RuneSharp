namespace RuneSharp.Models.Osrs.Exceptions;

public class OsrsSkillNullException : Exception
{

    public OsrsSkillNullException() : base() { }
    public OsrsSkillNullException(string message, Exception? innerException) : base(message,innerException) { }
    public OsrsSkillNullException(string message) : base(message,null) { }
}