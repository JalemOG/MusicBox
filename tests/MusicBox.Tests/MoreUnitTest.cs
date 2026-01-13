using System.Linq;
using MusicBox.Core;
using MusicBox.Domain;
using MusicBox.Errors;
using MusicBox.Structures;
using Xunit;

namespace MusicBox.Tests;

public class MoreUnitTests
{
    [Fact]
    public void Tempo_AllowsBoundaryValues_100_And_5000()
    {
        // Arrange
        var tempo = new Tempo(100);

        // Act
        tempo.SetQuarterMs(5000);

        // Assert
        Assert.Equal(5000, tempo.QuarterMs);
    }

    [Fact]
    public void Parser_TupleWithWrongArity_ThrowsParseException()
    {
        // Arrange
        var parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());

        // Act + Assert
        Assert.Throws<ParseException>(() => parser.Parse("(Do)"));
    }

    [Fact]
    public void DoublyLinkedList_Backward_IsReverseOfForward()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.Append(1);
        list.Append(2);
        list.Append(3);

        // Act
        var forward = list.Forward().ToArray();
        var backward = list.Backward().ToArray();

        // Assert
        Assert.Equal(new[] { 1, 2, 3 }, forward);
        Assert.Equal(new[] { 3, 2, 1 }, backward);
    }
}
