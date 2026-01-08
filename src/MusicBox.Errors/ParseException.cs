using System;

namespace MusicBox.Errors;

public sealed class ParseException : Exception
{
    public ParseException(string message) : base(message) { }
}
