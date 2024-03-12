using System.Data.SqlClient;
using System.Text;

namespace Task4
{
	internal class Program
	{
		static void Main(string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			string connectionStr = "Data Source=CRYCOMBATPC\\MSSQL2019;Integrated Security=True;Connect Timeout=30;";

			using (SqlConnection connection = new SqlConnection(connectionStr)) {
				Console.WriteLine(@"1 - Показати кількість овочів.
2 - Показати кількість фруктів.
3 - Показати кількість овочів і фруктів заданого кольору.
4 - Показати кількість овочів і фруктів кожного кольору.
5 - Показати овочі та фрукти з калорійністю нижче вказаної.
6 - Показати овочі та фрукти з калорійністю вище вказаної.
7 - Показати овочі та фрукти з калорійністю у вказаному
діапазоні.
8 - Показати усі овочі та фрукти жовтого або червоного
кольору.");

				int count = 0;
				switch (Console.ReadKey(true).KeyChar) {
					case '1':
						ShowVegetablesCount(connection);
						break;
					case '2':
						ShowFruitsCount(connection);
						break;
					case '3':
                        Console.Write("colors: ");
                        ShowVegetablesCount(connection, Console.ReadLine());
						break;
					case '4':
						Console.Write("colors: ");
						ShowFruitsCount(connection, Console.ReadLine());
						break;
					case '5':
						Console.Write("calories lower than: ");
						count = int.Parse(Console.ReadLine() ?? "0");
						ShowWithCalories(connection, calories => calories < count);
						break;
					case '6':
						Console.Write("calories higher than: ");
						count = int.Parse(Console.ReadLine() ?? "0");
						ShowWithCalories(connection, calories => calories > count);
						break;
					case '7':
						Console.Write("calories from: ");
						int from = int.Parse(Console.ReadLine() ?? "0");
						Console.Write("to: ");
						int to = int.Parse(Console.ReadLine() ?? "0");
						ShowWithCalories(connection, calories => calories >= from && calories <= to);
						break;
					case '8':
						ShowRedAndYellow(connection);
						break;
				}
			}
		}

		private static void ShowVegetablesCount(SqlConnection connection, string? color = null) {
			ShowCount(connection, 'v', color);
		}
		private static void ShowFruitsCount(SqlConnection connection, string? color = null) {
			ShowCount(connection, 'f', color);
		}
		private static void ShowCount(SqlConnection connection, char type, string? color = null) {
			string querry = $"USE VegetablesAndFruits\nSELECT Color FROM MainTable WHERE Type = '{type}'";
			if (color is not null) {
				querry += $" AND Color = '{color}'";
			}

			connection.Open();
			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				int i = 0;
				while (sqlReader.Read()) {
					i++;
				}
				Console.WriteLine(i);
			}
		}
		

		private delegate bool CaloriesComparison(int calories);
		private static void ShowWithCalories(SqlConnection connection, CaloriesComparison comparison) {
			string querry = $"USE VegetablesAndFruits\nSELECT Name, Calories FROM MainTable";

			connection.Open();
			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					if (comparison((int)sqlReader["Calories"])) {
						Console.WriteLine(sqlReader["Name"]);
                    }
				}
			}
		}

		private static void ShowRedAndYellow(SqlConnection connection) {
			string querry = $"USE VegetablesAndFruits\nSELECT Name, Color FROM MainTable WHERE Color = 'red' OR Color = 'yellow'";

			connection.Open();
			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Name"]);
				}
			}
		}
	}
}
