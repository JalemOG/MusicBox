using System;
using System.Collections.Generic;

namespace MusicBox.Domain;

public sealed class FigureCatalog
{
    private readonly Dictionary<string, Figure> _map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["redonda"] = Figure.Redonda,
        ["blanca"] = Figure.Blanca,
        ["negra"] = Figure.Negra,
        ["corchea"] = Figure.Corchea,
        ["semicorchea"] = Figure.Semicorchea,
    };

    public bool IsValid(string name) => _map.ContainsKey(Normalize(name));

    public Figure FromString(string name) => _map[Normalize(name)];

    private static string Normalize(string s) => (s ?? "").Trim().ToLowerInvariant();
}
