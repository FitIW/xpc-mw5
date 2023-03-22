using System.Data.SqlClient;

const string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MW5_project;"
                                            + "Integrated Security=true";

// Provide the query string with a parameter placeholder.
const string queryString = @"SELECT TOP (1000) [Id]
      ,[Name]
      ,[Code]
      ,[Description]
      ,[CategoryId]
      ,[BrandId]
      ,[Price]
      ,[Stock]
      ,[Weight]
      ,[ImageKey]
      ,[Created]
      ,[Updated]
  FROM [MW5_project].[dbo].[Products]
  where Description =  @description";

// Specify the parameter value.
var paramValue = "Car";

// Create and open the connection in a using block. This
// ensures that all resources will be closed and disposed
// when the code exits.
using var connection = new SqlConnection(connectionString);
// Create the Command and Parameter objects.
var command = new SqlCommand(queryString, connection);
command.Parameters.AddWithValue("@description", paramValue);

// Open the connection in a try/catch block. 
// Create and execute the DataReader, writing the result
// set to the console window.
try
{
    connection.Open();
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
            reader[0], reader[1], reader[2], reader[3], reader[4]);
    }

    reader.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();