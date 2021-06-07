using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace HCI_MAP.Model
{
    [Serializable]
    public struct Colour
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

        public Colour(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public Colour(Color color)
            : this(color.A, color.R, color.G, color.B)
        {
        }

        public static implicit operator Colour(Color color)
        {
            return new Colour(color);
        }

        public static implicit operator Color(Colour colour)
        {
            return Color.FromArgb(colour.A, colour.R, colour.G, colour.B);
        }
    }

    [Serializable]
    public class StickyNote
    {
        private string description;
        private string human_description;
        private Colour color;

        public StickyNote() { }
        public StickyNote(string description, string human_description, Colour color)
        {
            Description = description;
            Human_description = human_description;
            Color = color;
        }

        public string Description { get => description; set => description = value; }
        public string Human_description { get => human_description; set => human_description = value; }
        public Colour Color { get => color; set => color = value; }
    }
}
