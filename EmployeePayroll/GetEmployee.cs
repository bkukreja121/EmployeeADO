using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class GetEmployee
    {
        string connectionString = @"Data Source=IN-BMYKYD3;Initial Catalog=EmployeeDB;Integrated Security=True";
        private CommandType commandType;

        public List<EmployeeDetails> GetEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("spShowEmployees", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;


                sqlConnection.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

                while (dataReader.Read())
                {
                    EmployeeDetails employee = new EmployeeDetails()
                    {
                        EmpId = Convert.ToInt32(dataReader["Id"]),
                        Name = dataReader["Name"].ToString(),
                        ProfileImage = dataReader["ProfileImage"].ToString(),
                        Gender = dataReader["Gender"].ToString(),
                        Salary = Convert.ToInt32(dataReader["Salary"]),
                       
                        Notes = dataReader["Notes"].ToString(),
                        Department = dataReader["Department"].ToString()
                    };

                    employeeDetails.Add(employee);
                    

                }
                sqlConnection.Close();
                return employeeDetails;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message={ex.Message} and stack trace-{ex.StackTrace}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
            
}
