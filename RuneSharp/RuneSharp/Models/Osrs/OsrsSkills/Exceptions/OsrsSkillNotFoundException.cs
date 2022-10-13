namespace RuneSharp.Models.Osrs.Exceptions;

public class OsrsSkillNotFoundException : Exception
{
    public OsrsSkillNotFoundException() : base() { }
    public OsrsSkillNotFoundException(string message, Exception? innerException) : base(message,innerException) { }
    public OsrsSkillNotFoundException(string message) : base(message,null) { }
}