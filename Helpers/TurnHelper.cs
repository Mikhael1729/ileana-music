using static System.Console;

namespace IleanaMusic.Helpers
{
    /// <summary>
    /// It's to manage console methods like Clear and Pause.
    /// </summary>
    public static class TurnHelper
    {
        public static void Pause()
        {
            WriteLine("\nPresiona Enter para continuar");
            ReadLine();
        }

        public static void Clear()
        {
            System.Console.Clear();
        }
    }
}
