using MusicBox.Core;
using MusicBox.Domain;
using MusicBox.Errors;
using Xunit;

namespace MusicBox.Tests;

public class ParserEdgeCaseTests
{
    [Fact]
    public void Parse_EmptyInput_Throws()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        Assert.Throws<ParseException>(() => parser.Parse("   "));
    }

    [Fact]
    public void Parse_AllowsSpacesAndMixedCase()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        var list = parser.Parse("( Do , NEGRA ) , (re,Blanca),( Mi , corchea ) ,(FA,Semicorchea)");
        Assert.Equal(4, list.Count);
    }

    [Fact]
    public void Parse_TupleWithWrongArity_Throws()
    {
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        Assert.Throws<ParseException>(() => parser.Parse("(Do, negra, blanca)"));
    }
}
