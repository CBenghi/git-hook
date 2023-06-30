public class ConsoleInerop
{
    public static int ReportError(string message, int errorCode = 1)
    {
        var bkp = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ForegroundColor = bkp;
        return errorCode;
    }
}