using System;
using System.Collections.Generic;

namespace MusicBox.Domain;

public sealed class NoteCatalog
{
    private readonly Dictionary<string, Note> _map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["do"] = Note.Do,
        ["re"] = Note.Re,
        ["mi"] = Note.Mi,
        ["fa"] = Note.Fa,
        ["sol"] = Note.Sol,
        ["la"] = Note.La,
        ["si"] = Note.Si,
    };

    public bool IsValid(string name) => _map.ContainsKey(Normalize(name));

    public Note FromString(string name) => _map[Normalize(name)];

    private static string Normalize(string s) => (s ?? "").Trim().ToLowerInvariant();
}
