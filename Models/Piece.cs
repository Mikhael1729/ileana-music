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

        public void Print(bool withNumeration = false, int spaceQuantity = 0)
        {
            var spaces = "";
            for(int i = 0; i < spaceQuantity; i++) {
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

            Write(!option ? $"{spaces}  Calidad: " : $"{spaces}6. Calidad");
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
    
    }
}