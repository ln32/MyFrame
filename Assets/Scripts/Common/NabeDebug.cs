using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public static class NabeDebug
{
    private const string Mark = "[Log] ";

    [Conditional("DEBUG")]
    [Conditional("CONSOLE")]
    public static void Log(string message)
    {
        message = Mark + message;
        LogUnity(message);
        LogConsole(message);
    }


    [Conditional("DEBUG")]
    private static void LogUnity(string message)
    {
        // 디버그환경
        Debug.Log(message);
    }


    [Conditional("CONSOLE")]
    private static void LogConsole(string message)
    {
        // 콘솔환경
        Console.WriteLine(message);
    }
}