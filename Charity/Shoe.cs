namespace Charity
{
    public class Shoe
    {
        private string type;
        private string season;
        private int size;
        private string color;
        private string condition;

        public string Type
        {
            get => type;
            set => type = value;
        }

        public string Season
        {
            get => season;
            set => season = value;
        }

        public int Size
        {
            get => size;
            set => size = value;
        }

        public string Color
        {
            get => color;
            set => color = value;
        }

        public string Condition
        {
            get => condition;
            set => condition = value;
        }

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
            return "Shoe type: " + type + "\n" + "Season type: " + season + "\n"
                   + "Size: " + size + "\n" + "Color: " + color + "\n" + "Condition: " + condition +"\n";
        }
    }
}