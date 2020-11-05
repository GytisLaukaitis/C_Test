using Charity.Enums;

namespace Charity.Models
{
	public class Shoe
	{
		public ShoeType Type { get; private set; }

		public Season Season { get; private set; }

		public int Size { get; private set; }

		private string Color { get; set; }

		public Condition Condition { get; private set; }

		public Shoe(ShoeType type, Season season, int size, string color, Condition condition)
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
				   + "Size: " + Size + "\n" + "Color: " + Color + "\n" + "Condition: " + Condition + "\n";
		}
	}
}