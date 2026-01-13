[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

$ErrorActionPreference = "Stop"

Write-Host "Ejecución estricta de pruebas unitarias (una por una)" -ForegroundColor Cyan
Write-Host ""

$tests = @(
  "MusicBox.Tests.MoreUnitTests.Tempo_AllowsBoundaryValues_100_And_5000",
  "MusicBox.Tests.MoreUnitTests.Parser_TupleWithWrongArity_ThrowsParseException",
  "MusicBox.Tests.MoreUnitTests.DoublyLinkedList_Backward_IsReverseOfForward",

  "MusicBox.Tests.ExtraTests.App_Clear_RemovesAllNotes_AndPlaybackProducesNoTones",
  "MusicBox.Tests.ExtraTests.Player_UsesTempoToComputeDurations_ForDifferentFigures",
  "MusicBox.Tests.ExtraTests.Parser_IgnoresTextOutsideParentheses_AndParsesOnlyTuples",

  "MusicBox.Tests.DomainCatalogTests.NoteCatalog_IsCaseInsensitive_AndTrims",
  "MusicBox.Tests.DomainCatalogTests.FigureCatalog_IsCaseInsensitive_AndTrims",

  "MusicBox.Tests.DoublyLinkedListTests.Append_AddsToTail_AndUpdatesHeadTail",
  "MusicBox.Tests.DoublyLinkedListTests.Prepend_AddsToHead_AndUpdatesHeadTail",
  "MusicBox.Tests.DoublyLinkedListTests.Backward_IteratesFromTailToHead",
  "MusicBox.Tests.DoublyLinkedListTests.Clear_ResetsListState",

  "MusicBox.Tests.ParserEdgeCaseTests.Parse_EmptyInput_Throws",
  "MusicBox.Tests.ParserEdgeCaseTests.Parse_AllowsSpacesAndMixedCase",
  "MusicBox.Tests.ParserEdgeCaseTests.Parse_TupleWithWrongArity_Throws",

  "MusicBox.Tests.ParserTests.Parse_ValidInput_CreatesEvents",
  "MusicBox.Tests.ParserTests.Parse_InvalidNote_Throws",
  "MusicBox.Tests.ParserTests.Parse_InvalidFigure_Throws",
  "MusicBox.Tests.ParserTests.Parse_UnbalancedParentheses_Throws",

  "MusicBox.Tests.PlaybackTests.PlayForward_ProducesTonesInOrder",
  "MusicBox.Tests.PlaybackTests.PlayBackward_ProducesTonesInReverseOrder",
  "MusicBox.Tests.PlaybackTests.SetQuarterDuration_OutOfRange_Throws",

  "MusicBox.Tests.TempoTests.Tempo_Limits_RejectTooSmall",
  "MusicBox.Tests.TempoTests.Tempo_Limits_RejectTooLarge",
  "MusicBox.Tests.TempoTests.DurationMs_ScalesCorrectly",

  "MusicBox.Tests.VerboseLoggerTests.Logger_IsCalledOncePerNote_WithHzAndMs"
)

# Quitar duplicados por si acaso
$tests = $tests | Select-Object -Unique

$passed = 0
foreach ($t in $tests) {
  Write-Host "Ejecutando: $t" -ForegroundColor Yellow
  dotnet test MusicBox.sln --filter "FullyQualifiedName=$t" -v minimal
  $passed++
  Write-Host ""
}

Write-Host "Ejecución individual finalizada correctamente. Tests ejecutados: $passed" -ForegroundColor Green
