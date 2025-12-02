// load the file from disk
string filePath = $@"{AppContext.BaseDirectory}\DayTwo\DayTwoInput.txt";

string content = File.ReadAllText(filePath);

string[] productIds = content.Split(',');

long currentRange = 0;
long invalidProductIdCount = 0;

string[][] ranges = [.. productIds
	.Select(id => id.Split('-'))
	.Select(parts => new string[] { parts[0], parts[1] })];

//loop to go through the whole 2D array
for (int i = 0; i < ranges.Length; i++)
{
	currentRange = long.Parse(ranges[i][0]);
	// starting at the first value in the first dimension of the array, count sequentially up to the value in the second dimension of the array
	for (long j = long.Parse(ranges[i][0]); j <= long.Parse(ranges[i][1]); j++)
	{
		// check if the current value is invalid
		if (currentRange.ToString().Length % 2 == 0)
		{
			int length = currentRange.ToString().Length;
			int halfLength = length / 2;

			string firstHalf = currentRange.ToString().Substring(0, halfLength);
			string secondHalf = currentRange.ToString().Substring(halfLength, halfLength);

			if (firstHalf == secondHalf)
			{
				Console.WriteLine($"Found invalid id {firstHalf}{secondHalf}");
				invalidProductIdCount += currentRange;
			}
		}
		currentRange++;
	}
}

Console.WriteLine($"Invalid Product Count total: {invalidProductIdCount}");

Console.ReadLine();