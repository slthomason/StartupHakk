using (var connection = new SqlConnection(connectionString)
{
	connection.Open();
	[....]
}
//Here, the connection is already disposed for you


using var connection = new SqlConnection(connectionString)
connection.Open();
	
var connection = new SqlConnection(connectionString)
connection.Open();
connection.Close();
return;

