using System.Data.SqlClient;

namespace Task3
{
	internal class Program
	{
		static void Main(string[] args) {
			string connectionStr = "Data Source=CRYCOMBATPC\\MSSQL2019;Integrated Security=True;Connect Timeout=30;";

			using (SqlConnection connection = new SqlConnection(connectionStr)) {
				Console.WriteLine(@"1 - Відображення всієї інформації з таблиці овочів і фруктів
2 - Відображення усіх назв овочів і фруктів
3 - Відображення усіх кольорів
4 - Показати максимальну калорійність
5 - Показати мінімальну калорійність
6 - Показати середню калорійність");
				switch (Console.ReadKey(true).KeyChar) {
					case '1':
						WriteAll(connection);
						break;
					case '2':
						WriteNames(connection);
						break;
					case '3':
						WriteColors(connection);
						break;
					case '4':
						WriteMaxCalories(connection);
						break;
					case '5':
						WriteMinCalories(connection);
						break;
					case '6':
						WriteAvgCalories(connection);
						break;
				}
			}
		}

		static void WriteAll(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryAll.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.Write($"{sqlReader["Id"]}: ");
					Console.Write($"{sqlReader["Name"]} | ");
					Console.Write($"{sqlReader["Type"]} | ");
					Console.Write($"{sqlReader["Color"]} | ");
					Console.WriteLine(($"{sqlReader["Calories"]} | "));
				}
			}
		}
		static void WriteNames(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryNames.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Name"]);
				}
			}
		}
		static void WriteColors(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryColors.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Color"]);
				}
			}
		}
		static void WriteMaxCalories(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryMaxCalories.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Calories"]);
				}
			}
		}
		static void WriteMinCalories(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryMinCalories.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Calories"]);
				}
			}
		}
		static void WriteAvgCalories(SqlConnection connection) {
			StreamReader sr = new StreamReader(File.Open("querryAvgCalories.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			connection.Open();

			using (SqlCommand command = new SqlCommand(querry, connection)) {
				command.ExecuteNonQuery();
				SqlDataReader sqlReader = command.ExecuteReader();
				while (sqlReader.Read()) {
					Console.WriteLine(sqlReader["Calories"]);
				}
			}
		}
	}
}
