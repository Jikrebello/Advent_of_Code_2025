// load the file from disk
string filePath = $@"{AppContext.BaseDirectory}\DayOneInput.txt";

string[] lines = File.ReadAllLines(filePath);

int passwordCount = 0;
int currentDialPosition = 50;

for (int i = 0; i < lines.Length; i++)
{
	string instruction = lines[i];

	char direction = instruction[0];

	int rotation = int.Parse(instruction[1..]);
	// flatten rotation to within 0 - 99 range of the dial
	while (rotation > 100)
	{
		rotation -= 100;
		passwordCount++;
	}
	Console.WriteLine($"Instruction: {instruction}\nCurrent Dial Position: {currentDialPosition}");

	// apply the rotation to the current
	switch (direction)
	{
		case
			'L':
			currentDialPosition -= rotation;

			break;

		case 'R':
			currentDialPosition += rotation;
			break;
	}

	if (currentDialPosition == 100)
	{
		currentDialPosition = 0;
	}

	// flatten currentDialPosition to within 0 - 99 range of the dial
	while (currentDialPosition > 100)
	{
		currentDialPosition -= 100;
	}

	while (currentDialPosition < -1)
	{
		currentDialPosition = 100 + currentDialPosition;
	}

	Console.WriteLine($"Current Dial Position after rotation {currentDialPosition}");

	if (currentDialPosition == 0)
	{
		currentDialPosition = 0;
		passwordCount++;
	}

	Console.WriteLine($"Password count: {passwordCount}");

	Console.WriteLine("");
}

Console.WriteLine(passwordCount);
Console.ReadLine();