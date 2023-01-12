using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class usingkeyword
    {
    
    public void addconnection()
    {
        // Declare a nullable integer
        // Bad Implementation
        SqlConnection connection = new SqlConnection("connection string");
        connection.Open();
        // Do something with the connection
        connection.Close();

        // Good example
        using (SqlConnection connectiond = new SqlConnection("connection string"))
        {
            connection.Open();
            // Do something with the connection

        }
    }
}}