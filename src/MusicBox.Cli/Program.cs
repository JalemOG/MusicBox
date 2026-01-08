using MusicBox.Core;
using MusicBox.Errors;
using MusicBox.Playback;

bool verbose = false;


const string DEMO_SCORE =
    "(Do, negra), (Re, corchea), (Mi, corchea), " +
    "(Fa, blanca), " +
    "(Sol, negra), (La, semicorchea), (Si, semicorchea), " +
    "(Do, blanca)";


static void PrintHelp()
{
    Console.WriteLine("MusicBox CLI");
    Console.WriteLine("Formato de entrada: (Do, negra), (Re, blanca), (Mi, corchea)");
    Console.WriteLine("Comandos:");
    Console.WriteLine("  set <ms>      -> cambia duración de la negra (100..5000)");
    Console.WriteLine("  load <texto>  -> carga partitura");
    Console.WriteLine("  fwd           -> reproduce hacia adelante");
    Console.WriteLine("  bwd           -> reproduce hacia atrás");
    Console.WriteLine("  demo          -> carga y reproduce una partitura de demostración");
    Console.WriteLine("  verbose on/off -> muestra nota, Hz y duración al reproducir");
    Console.WriteLine("  count         -> cantidad de notas cargadas");
    Console.WriteLine("  help          -> mostrar ayuda");
    Console.WriteLine("  exit          -> salir");
    Console.WriteLine();
}

var audio = new BeepAudioEngine();
var app = new MusicBoxApp(audio, quarterMs: 500);

PrintHelp();

// Carga rápida de ejemplo (podés borrarlo si querés)
try
{
    app.LoadFromString("(Do, negra), (Re, negra), (Mi, negra), (Fa, negra), (Sol, negra)");
    Console.WriteLine("Ejemplo cargado. Usa 'fwd' para reproducir.");
}
catch { }

while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (line is null) continue;

    line = line.Trim();
    if (line.Length == 0) continue;

    var parts = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
    var cmd = parts[0].ToLowerInvariant();
    var arg = parts.Length > 1 ? parts[1] : "";

    try
    {
        switch (cmd)
        {
            case "help":
                PrintHelp();
                break;

            case "set":
                if (!int.TryParse(arg, out var ms))
                {
                    Console.WriteLine("Uso: set <ms>");
                    break;
                }
                app.SetQuarterDuration(ms);
                Console.WriteLine($"Negra = {ms} ms");
                break;

            case "load":
                if (string.IsNullOrWhiteSpace(arg))
                {
                    Console.WriteLine("Uso: load <texto>");
                    break;
                }
                app.LoadFromString(arg);
                Console.WriteLine("Partitura cargada.");
                break;

            case "fwd":
                app.PlayForward();
                Console.WriteLine("OK (forward).");
                break;

            case "bwd":
                app.PlayBackward();
                Console.WriteLine("OK (backward).");
                break;

            case "count":
                Console.WriteLine($"Notas en memoria: {app.Count()}");
                break;
                        
            case "demo":
                try
                {
                    app.LoadFromString(DEMO_SCORE);
                    Console.WriteLine("Partitura demo cargada:");
                    Console.WriteLine(DEMO_SCORE);
                    app.PlayForward();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en demo: {ex.Message}");
                }
                break;

            case "verbose":
                if (arg.Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    verbose = true;
                    app.SetPlaybackLogger(Console.WriteLine);
                    Console.WriteLine("Verbose: ON");
                }
                else if (arg.Equals("off", StringComparison.OrdinalIgnoreCase))
                {
                    verbose = false;
                    app.SetPlaybackLogger(null);
                    Console.WriteLine("Verbose: OFF");
                }
                else
                {
                    Console.WriteLine("Uso: verbose on | verbose off");
                }
                break;

            case "exit":
            case "quit":
                return;

            default:
                Console.WriteLine("Comando no reconocido. Usa 'help'.");
                break;
        }
    }
    catch (ParseException ex)
    {
        Console.WriteLine($"Parse error: {ex.Message}");
    }
    catch (InvalidTempoException ex)
    {
        Console.WriteLine($"Tempo error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
