using System;

namespace MusicBox.Errors;

public sealed class InvalidTempoException : Exception
{
    public InvalidTempoException(string message) : base(message) { }
}
