using System.Data.SqlClient;

namespace Task1
{
	internal class Program
	{
		static void Main(string[] args) {
			StreamReader sr = new StreamReader(File.Open("querry.sql", FileMode.Open));
			string querry = sr.ReadToEnd();
			sr.Close();

			Console.WriteLine(querry);

			string connectionStr = "Data Source=CRYCOMBATPC\\MSSQL2019;Integrated Security=True;Connect Timeout=30;";

			using (SqlConnection connection = new SqlConnection(connectionStr)) {
				connection.Open();

				using (SqlCommand command = new SqlCommand(querry, connection)) {
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
