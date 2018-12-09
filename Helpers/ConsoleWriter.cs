using static System.Console;

namespace IleanaMusic.Helpers
{
    public class ConsoleWriter 
    {
        public string Spaces { get; private set; }
        public int Indentation { get; set; }

        public ConsoleWriter(int spaceQuantity, int indentation = 3) 
        {
            Spaces = GenerateSpaces(spaceQuantity);
            Indentation = indentation;
        }

        public void Write(string text, int indent = 0, bool spaceBefore = false, bool cancelSpace = false) 
        {
            var extra = GenerateSpaces(indent * (Spaces.Length > 0 ? Spaces.Length : Indentation));

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