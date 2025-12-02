namespace Advent_of_Code.DayThree
{
	internal class DayThree
	{
		public DayThree()
		{
			// load the file from disk
			string filePath = $@"{AppContext.BaseDirectory}\DayThree\DayThreeInput.txt";

			string content = File.ReadAllText(filePath);

			Console.ReadLine();
		}
	}
}