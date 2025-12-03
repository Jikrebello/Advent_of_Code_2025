namespace Advent_of_Code.DayThree
{
	internal class DayThree
	{
		public DayThree()
		{
			// load the file from disk
			string filePath = $@"{AppContext.BaseDirectory}\DayThree\DayThreeInput.txt";
			string[] lines = File.ReadAllLines(filePath);

			int totalJoltageOutput = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i].Trim();

				int maxPair = 0;
				int bestRightDigit = -1;

				//right to left
				for (int j = line.Length - 1; j >= 0; j--)
				{
					int current = int.Parse(line[j].ToString());

					if (bestRightDigit != -1)
					{
						int value = current * 10 + bestRightDigit;
						if (value > maxPair)
							maxPair = value;
					}

					// update the highest digit to the right
					if (current > bestRightDigit)
						bestRightDigit = current;
				}

				Console.WriteLine($"Max Joltage for bank in row {i + 1}: {maxPair}");

				totalJoltageOutput += maxPair;
			}

			Console.WriteLine($"Total Joltage: {totalJoltageOutput}");
			Console.ReadLine();
		}
	}
}