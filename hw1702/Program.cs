namespace hw1702
{
	internal class Program
	{
		static void Main(string[] args) {
			StreamReader sr = new StreamReader(File.Open("querry.sql", FileMode.Open));
			string querry = sr.ReadToEnd();

			Console.WriteLine(querry);
		}
	}
}
