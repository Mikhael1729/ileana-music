using System;
using IleanaMusic.Helpers;
using static System.Console;

namespace IleanaMusic.Models
{
    public class Piece : BaseEntity
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public Gender Gender { get; set; }
        public double Duration { get; set; }
        public Quality Quality { get; set; }
        public MusicFormat Format { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public void Print(bool withNumeration = false, int spaceQuantity = 0)
        {
            var spaces = "";
            for (int i = 0; i < spaceQuantity; i++)
            {
                spaces += " ";
            }

            var option = withNumeration;

            WriteLine(!option ? $"{spaces}- ID: {Id}" : $"{spaces}   ID: {Id}");
            WriteLine(!option ? $"{spaces}  Nombre: {Name}" : $"{spaces}1. Nombre: {Name}");
            WriteLine(!option ? $"{spaces}  Artista: {Artist}" : $"{spaces}2. Artista: {Artist}");
            WriteLine(!option ? $"{spaces}  Álbum: {Album}" : $"{spaces}3. Álbum: {Album}");

            Write(!option ? $"{spaces}  Género: " : $"{spaces}4. Género: ");
            switch (Gender)
            {
                case Gender.Classical:
                    Write("Clásica");
                    break;
                case Gender.Raggeton:
                    Write("Raggeton");
                    break;
                case Gender.Rock:
                    Write("Rock");
                    break;
            }

            WriteLine("");

            WriteLine(!option ? $"{spaces}  Duración: {Duration} minutos" : $"{spaces}5. Duración: {Duration} minutos");

            Write(!option ? $"{spaces}  Calidad: " : $"{spaces}6. Calidad: ");
            switch (Quality)
            {
                case Quality.High:
                    Write("Alta");
                    break;
                case Quality.Low:
                    Write("Baja");
                    break;
                case Quality.Medium:
                    Write("Media");
                    break;
            }

            WriteLine("");

            Write(!option ? $"{spaces}  Formato: " : $"{spaces}7. Formato: ");
            switch (Format)
            {
                case MusicFormat.Mp3:
                    Write("Mp3");
                    break;
                case MusicFormat.Mp4:
                    Write("Mp4");
                    break;
            }

            WriteLine("");
        }

        public void Request()
        {
            Write("- Nombre: ");
            Name = ReadLine();

            Write("- Artista: ");
            Artist = ReadLine();

            Write("- Álbum: ");
            Album = ReadLine();

            int genderOption = 0;
            while (genderOption == 0 && genderOption < 3)
            {
                WriteLine("- Género: ");
                Write("    1. Música clásica: \n" +
                        "    2. Rock: \n" +
                        "    3. Raggeton:\n\n" +
                        "    Escoje [1-3]: ");

                if (Int32.TryParse(ReadLine(), out genderOption))
                {
                    switch (genderOption)
                    {
                        case 1:
                            Gender = Gender.Classical;
                            break;
                        case 2:
                            Gender = Gender.Raggeton;
                            break;
                        case 3:
                            Gender = Gender.Rock;
                            break;
                    }
                }
            }

            double duration = 0;
            while (duration == 0)
            {
                Write("- Duración: ");

                if (Double.TryParse(ReadLine(), out duration))
                    Duration = duration;
            }

            var quality = 0;
            while (quality == 0)
            {
                Write("- Calidad: \n"
                        + "    1. Baja. \n"
                        + "    2. Media\n"
                        + "    3. Alta \n\n"
                        + "    Escoje [1-3]: ");

                if (Int32.TryParse(ReadLine(), out quality))
                {
                    switch (quality)
                    {
                        case 1:
                            Quality = Quality.Low;
                            break;
                        case 2:
                            Quality = Quality.Medium;
                            break;
                        case 3:
                            Quality = Quality.High;
                            break;
                    }
                }
            }

            // Format.
            var formatOption = 0;
            var writer = new ConsoleWriter(0);
            writer.Write("- Formato: \n");
            writer.Write(text: "1. Mp3\n", indent: 1);
            writer.Write(text: "2. Mp4\n\n", indent: 1);
            writer.Write(text: "Escoge [1-2]: ", indent: 1);

            if (Int32.TryParse(ReadLine(), out formatOption))
            {
                switch (formatOption)
                {
                    case 1:
                        Format = MusicFormat.Mp3;
                        break;
                    case 2:
                        Format = MusicFormat.Mp4;
                        break;
                }
            }
        }

        public void RequestName(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Nombre: ");
            Name = ReadLine();
        }
        public void RequestArtist(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Artista: ");
            Artist = ReadLine();
        }
        public void RequestAlbum(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Álbum");
            Album = ReadLine();
        }
        public void RequestGender(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);
            int genderOption = 0;
            while (genderOption == 0 && genderOption < 3)
            {
                writer.Write("- Género: \n");
                writer.Write("    1. Música clásica\n");
                writer.Write("    2. Rock: \n");
                writer.Write("    3. Raggeton:\n\n");
                writer.Write("    Escoje [1-3]: ");

                if (Int32.TryParse(ReadLine(), out genderOption))
                {
                    switch (genderOption)
                    {
                        case 1:
                            Gender = Gender.Classical;
                            break;
                        case 2:
                            Gender = Gender.Rock;
                            break;
                        case 3:
                            Gender = Gender.Raggeton;
                            break;
                    }
                }
            }
        }
        public void RequestDuration(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            double duration = 0;
            while (duration == 0)
            {
                writer.Write("- Duración: ");

                if (Double.TryParse(ReadLine(), out duration))
                    Duration = duration;
            }
        }
        public void RequestQuality(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            var quality = 0;
            while (quality == 0)
            {
                writer.Write("- Calidad: \n");
                writer.Write(text: $"1. Baja. \n", indent: 1);
                writer.Write(text: $"2. Media\n", indent: 1);
                writer.Write(text: $"3. Alta \n\n", indent: 1);
                writer.Write(text: $"Escoje [1-3]: ", indent: 1);

                if (Int32.TryParse(ReadLine(), out quality))
                {
                    switch (quality)
                    {
                        case 1:
                            Quality = Quality.Low;
                            break;
                        case 2:
                            Quality = Quality.Medium;
                            break;
                        case 3:
                            Quality = Quality.High;
                            break;
                    }
                }
            }
        }
        public void RequestFormat(ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            var formatOption = 0;
            writer.Write("- Formato: \n");
            writer.Write(text: "1. Mp3\n", indent: 1);
            writer.Write(text: "2. Mp4\n\n", indent: 1);
            writer.Write(text: "Escoge [1-2]: ", indent: 1);

            if (Int32.TryParse(ReadLine(), out formatOption))
            {
                switch (formatOption)
                {
                    case 1:
                        Format = MusicFormat.Mp3;
                        break;
                    case 2:
                        Format = MusicFormat.Mp4;
                        break;
                }
            }
        }

    }
}