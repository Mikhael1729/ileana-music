using System;

namespace IleanaMusic.Models 
{
    public class Piece 
    {
        public int Id { get; set; }
        public string Name { get; set;}
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
    }
}