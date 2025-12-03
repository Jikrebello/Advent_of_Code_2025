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

			for (int row = 0; row < lines.Length; row++)
			{
				string line = lines[row].Trim();

				int maxValid = 0;

				for (int i = 0; i < line.Length; i++)
				{
					int first = int.Parse(line[i].ToString());

					for (int j = i + 1; j < line.Length; j++)
					{
						int second = int.Parse(line[j].ToString());

						int value = first * 10 + second;

						if (value > maxValid)
						{
							maxValid = value;
						}
					}
				}

				Console.WriteLine($"Max Joltage for bank in row {row + 1}: {maxValid}");

				totalJoltageOutput += maxValid;
			}

			Console.WriteLine($"Total Joltage: {totalJoltageOutput}");
			Console.ReadLine();
		}
	}
}