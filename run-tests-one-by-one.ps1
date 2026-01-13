# ==========================================
# Script: Ejecución individual de pruebas
# Proyecto: MusicBox
# Descripción:
#   Ejecuta pruebas unitarias una por una
#   utilizando filtros de xUnit.
# ==========================================

Write-Host "Iniciando ejecución individual de pruebas unitarias..." -ForegroundColor Cyan
Write-Host ""

# -------------------- Tests de Tempo --------------------
Write-Host "Ejecutando test: Tempo_AllowsBoundaryValues_100_And_5000" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~Tempo_AllowsBoundaryValues_100_And_5000
Write-Host ""

# -------------------- Tests de Parser --------------------
Write-Host "Ejecutando test: Parser_TupleWithWrongArity_ThrowsParseException" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~Parser_TupleWithWrongArity_ThrowsParseException
Write-Host ""

Write-Host "Ejecutando test: Parser_IgnoresTextOutsideParentheses_AndParsesOnlyTuples" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~Parser_IgnoresTextOutsideParentheses_AndParsesOnlyTuples
Write-Host ""

# -------------------- Tests de Estructuras --------------------
Write-Host "Ejecutando test: DoublyLinkedList_Backward_IsReverseOfForward" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~DoublyLinkedList_Backward_IsReverseOfForward
Write-Host ""

# -------------------- Tests de Playback --------------------
Write-Host "Ejecutando test: Player_UsesTempoToComputeDurations_ForDifferentFigures" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~Player_UsesTempoToComputeDurations_ForDifferentFigures
Write-Host ""

# -------------------- Tests de Aplicación --------------------
Write-Host "Ejecutando test: App_Clear_RemovesAllNotes_AndPlaybackProducesNoTones" -ForegroundColor Yellow
dotnet test MusicBox.sln --filter FullyQualifiedName~App_Clear_RemovesAllNotes_AndPlaybackProducesNoTones
Write-Host ""

Write-Host "Ejecución individual de pruebas finalizada." -ForegroundColor Green
