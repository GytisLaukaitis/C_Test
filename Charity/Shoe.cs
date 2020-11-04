namespace Charity
{
    public class Shoe
    {
        public string Type { get; private set; }

        public string Season { get; private set; }

        public int Size { get; private set; }

        private string Color { get; set; }

        public string Condition { get; private set; }

        public Shoe(string type, string season, int size, string color, string condition)
        {
            Type = type;
            Season = season;
            Size = size;
            Color = color;
            Condition = condition;
        }


        public override string ToString()
        {
            return "Shoe type: " + Type + "\n" + "Season type: " + Season + "\n"
                   + "Size: " + Size + "\n" + "Color: " + Color + "\n" + "Condition: " + Condition +"\n";
        }
    }
}