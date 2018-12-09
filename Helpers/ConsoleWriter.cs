using static System.Console;

namespace IleanaMusic.Helpers
{
    public class ConsoleWriter 
    {
        public string Spaces { get; private set; }

        public ConsoleWriter(int spaceQuantity) 
        {
            Spaces = GenerateSpaces(spaceQuantity);
        }

        public void Write(string text, int indent = 0, bool spaceBefore = false, bool cancelSpace = false) 
        {
            var extra = GenerateSpaces(indent * Spaces.Length);

            System.Console.Write(
                (spaceBefore ? "\n" : "") 
                + (!cancelSpace ? Spaces : "") 
                + extra
                + text 
            );
        }

        string GenerateSpaces(int spaceQuantity) 
        {
            var spaces = "";

            for (int i = 0; i < spaceQuantity; i++)
            {
                spaces += " ";
            }

            return spaces;
        }
    }
}