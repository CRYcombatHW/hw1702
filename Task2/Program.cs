using System.Data.SqlClient;

namespace Task2
{
	internal class Program
	{
		static void Main(string[] args) {
			StreamReader sr = new StreamReader(File.Open("querry.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			string connectionStr = "Data Source=CRYCOMBATPC\\MSSQL2019;Integrated Security=True;Connect Timeout=30;";

			try {
				using (SqlConnection connection = new SqlConnection(connectionStr)) {
					connection.Open();

					using (SqlCommand command = new SqlCommand(querry, connection)) {
						command.ExecuteNonQuery();
						SqlDataReader sqlReader = command.ExecuteReader();
						Console.WriteLine("Connection succesful, data:");
						while (sqlReader.Read()) {
							Console.Write($"{sqlReader["Id"]}: ");
							Console.Write($"{sqlReader["Name"]} | ");
							Console.Write($"{sqlReader["Type"]} | ");
							Console.Write($"{sqlReader["Color"]} | ");
							Console.WriteLine(($"{sqlReader["Calories"]} | "));
						}
					}
				}
			}
			catch {
				Console.WriteLine("Cant connect to database");
			}
		}
	}
}
