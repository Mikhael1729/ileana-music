using System;
using static System.Console;

namespace IleanaMusic.Models
{
    public class Piece
    {
        public int Id { get; set; }
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

        public void Print()
        {
            WriteLine($"- ID: {Id}");
            WriteLine($"  Nombre: {Name}");
            WriteLine($"  Artista: {Artist}");
            WriteLine($"  Álbum: {Album}");
            Write($"  Género: Música ");
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

            WriteLine($"  Duración: {Duration} minutos");

            Write($"  Calidad: ");
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

            Write("  Formato: ");
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
    }
}