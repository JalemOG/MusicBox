using MusicBox.Core;
using MusicBox.Domain;
using MusicBox.Errors;
using Xunit;

namespace MusicBox.Tests;

public class ParserTests
{
    [Fact]
    public void Parse_ValidInput_CreatesEvents()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        var list = parser.Parse("(Do, negra), (Re, blanca), (La, corchea)");
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Parse_InvalidNote_Throws()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        Assert.Throws<ParseException>(() => parser.Parse("(Xx, negra)"));
    }

    [Fact]
    public void Parse_InvalidFigure_Throws()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        Assert.Throws<ParseException>(() => parser.Parse("(Do, triple)"));
    }

    [Fact]
    public void Parse_UnbalancedParentheses_Throws()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        Assert.Throws<ParseException>(() => parser.Parse("(Do, negra"));
    }
}
