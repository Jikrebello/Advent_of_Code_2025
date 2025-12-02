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
	// starting at the first value in the first dimension of the array, count sequentially up to the value in the second dimension of the array
	currentRange = long.Parse(ranges[i][0]);
	for (long j = long.Parse(ranges[i][0]); j <= long.Parse(ranges[i][1]); j++)
	{
		// check one: logic that focuses on if there is an even number of digits
		if (currentRange.ToString().Length % 2 == 0)
		{
			int length = currentRange.ToString().Length;
			int halfLength = length / 2;

			string firstHalf = currentRange.ToString()[..halfLength];
			string secondHalf = currentRange.ToString()[halfLength..];

			if (firstHalf == secondHalf)
			{
				Console.WriteLine($"Found invalid id {currentRange}");
				invalidProductIdCount += currentRange;
			}
			else if (firstHalf.Length > 2 && secondHalf.Length > 2)
			{
				string evenFirstHalf = firstHalf + secondHalf[0];
				string evenSecondHalf = secondHalf + firstHalf[0];

				string reverseEvenFirstHalf = new(evenFirstHalf.Reverse().ToArray());

				if (reverseEvenFirstHalf == evenSecondHalf)
				{
					Console.WriteLine($"Found invalid id {currentRange}");
					invalidProductIdCount += currentRange;
				}
			}
		}

		// check two: logic that focuses on if there is an odd number of digits
		else
		{
			// eg) we have 123123123
		}
		currentRange++;
	}
}

Console.WriteLine($"Invalid Product Count total: {invalidProductIdCount}");

Console.ReadLine();