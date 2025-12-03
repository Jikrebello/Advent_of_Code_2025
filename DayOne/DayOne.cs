namespace Advent_of_Code.DayOne
{
	internal class DayOne
	{
		public DayOne()
		{
			// load the file from disk
			string filePath = $@"{AppContext.BaseDirectory}\DayOne\DayOneInput.txt";

			string[] lines = File.ReadAllLines(filePath);

			int passwordCount = 0;
			int currentDialPosition = 50;

			for (int i = 0; i < lines.Length; i++)
			{
				string instruction = lines[i];

				char direction = instruction[0];

				int rotation = Convert.ToInt32(instruction[1..]);

				Console.WriteLine($"Instruction: {instruction}\nCurrent Dial Position: {currentDialPosition}");

				int overflow = 0;
				switch (direction)
				{
					case
						'L':
						overflow = -1;
						break;

					case 'R':
						overflow = 1;
						break;
				}

				for (int click = 0; click < rotation; click++)
				{
					currentDialPosition += overflow;

					if (currentDialPosition == 100)
					{
						currentDialPosition = 0;
					}
					else if (currentDialPosition == -1)
					{
						currentDialPosition = 99;
					}

					if (currentDialPosition == 0)
					{
						passwordCount++;
					}
				}

				Console.WriteLine($"Current Dial Position after rotation {currentDialPosition}");
				Console.WriteLine($"Password count: {passwordCount}");
				Console.WriteLine("");
			}

			Console.WriteLine(passwordCount);
			Console.ReadLine();
		}
	}
}