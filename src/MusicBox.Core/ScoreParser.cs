using System;
using System.Collections.Generic;
using MusicBox.Domain;
using MusicBox.Errors;
using MusicBox.Structures;

namespace MusicBox.Core;

public sealed class ScoreParser
{
    private readonly NoteCatalog _notes;
    private readonly FigureCatalog _figures;

    public ScoreParser(NoteCatalog notes, FigureCatalog figures)
    {
        _notes = notes;
        _figures = figures;
    }

    public DoublyLinkedList<MusicEvent> Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ParseException("Input is empty.");

        var list = new DoublyLinkedList<MusicEvent>();
        foreach (var tupleText in Tokenize(input))
        {
            var ev = ParseTuple(tupleText);
            list.Append(ev);
        }

        if (list.Count == 0)
            throw new ParseException("No valid tuples found.");

        return list;
    }

    private List<string> Tokenize(string input)
    {
        // We scan for (...) groups to avoid fragile splitting.
        var result = new List<string>();
        int i = 0;
        while (i < input.Length)
        {
            if (input[i] == '(')
            {
                int start = i;
                int depth = 1;
                i++;
                while (i < input.Length && depth > 0)
                {
                    if (input[i] == '(') depth++;
                    else if (input[i] == ')') depth--;
                    i++;
                }

                if (depth != 0)
                    throw new ParseException("Unbalanced parentheses in input.");

                int endExclusive = i; // includes ')'
                result.Add(input.Substring(start, endExclusive - start));
            }
            else
            {
                i++;
            }
        }

        return result;
    }

    private MusicEvent ParseTuple(string tupleText)
    {
        // tupleText like "(Do, negra)"
        var s = tupleText.Trim();
        if (!s.StartsWith('(') || !s.EndsWith(')'))
            throw new ParseException($"Invalid tuple format: {tupleText}");

        s = s[1..^1]; // remove parentheses

        var parts = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            throw new ParseException($"Tuple must have exactly 2 elements (Note, Figure): {tupleText}");

        var noteRaw = Normalize(parts[0]);
        var figRaw = Normalize(parts[1]);

        if (!_notes.IsValid(noteRaw))
            throw new ParseException($"Invalid note: '{parts[0].Trim()}'");

        if (!_figures.IsValid(figRaw))
            throw new ParseException($"Invalid figure: '{parts[1].Trim()}'");

        var note = _notes.FromString(noteRaw);
        var fig = _figures.FromString(figRaw);

        return new MusicEvent(note, fig);
    }

    private string Normalize(string s) => (s ?? "").Trim().ToLowerInvariant();
}
