namespace Advent_of_Code.DayTwo
{
	internal class DayTwo
	{
		public DayTwo()
		{
			// load the file from disk
			string filePath = $@"{AppContext.BaseDirectory}\DayTwo\DayTwoInput.txt";

			string content = File.ReadAllText(filePath);
			string[] productIds = content.Split(',');

			long invalidProductIdCount = 0;

			string[][] ranges = [.. productIds
				.Select(id => id.Split('-'))
				.Select(parts => new string[] { parts[0], parts[1] })];

			//loop to go through the whole 2D array
			for (int i = 0; i < ranges.Length; i++)
			{
				long begin = long.Parse(ranges[i][0]);
				long finish = long.Parse(ranges[i][1]);

				for (long currentRange = begin; currentRange <= finish; currentRange++)
				{
					if (IsInvalidId(currentRange))
					{
						Console.WriteLine($"Found invalid id {currentRange}");
						invalidProductIdCount += currentRange;
					}
				}
			}

			Console.WriteLine($"Invalid Product Count total: {invalidProductIdCount}");
			Console.ReadLine();
		}

		private static bool IsInvalidId(long id)
		{
			int idLength = id.ToString().Length;

			if (idLength == 1)
				return false;

			for (int patternLength = 1; patternLength <= idLength / 2; patternLength++)
			{
				// pattern length must divide evenly into id length
				if (idLength % patternLength != 0)
				{
					continue;
				}

				string pattern = id.ToString().Substring(0, patternLength);

				// how many times to repeat the pattern
				int repeatCount = idLength / patternLength;
				string rebuilt = "";
				for (int i = 0; i < repeatCount; i++)
				{
					rebuilt += pattern;
				}

				if (rebuilt == id.ToString())
				{
					return true;
				}
			}

			return false;
		}
	}
}