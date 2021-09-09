using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class Employee
    {
        public int Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
       
        public string Notes { get; set; }
        public string Department { get; set; }

    }
    public class EmployeeDetails
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
      
        public string Notes { get; set; }
        public string Department { get; set; }
    }
    public class InsertEmployee
    {
        EmployeeDetails employee = new EmployeeDetails();

        string connectionString = @"Data Source=IN-BMYKYD3;Initial Catalog=EmployeeDB;Integrated Security=True";

        public bool RegisterEmployee()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("spInsertEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                Console.WriteLine("Enter Employee Name");
                employee.Name = Console.ReadLine();
                command.Parameters.AddWithValue("Name", employee.Name);

                Console.WriteLine("Enter Employee Profile Image");
                employee.ProfileImage = Console.ReadLine();
                command.Parameters.AddWithValue("ProfileImage", employee.ProfileImage);

                Console.WriteLine("Enter Employee Gender");
                employee.Gender = Console.ReadLine();
                command.Parameters.AddWithValue("Gender", employee.Gender);

                Console.WriteLine("Enter Employee Salary");
                employee.Salary = Convert.ToInt32(Console.ReadLine());
                command.Parameters.AddWithValue("Salary", employee.Salary);


                Console.WriteLine("Enter Notes");
                employee.Notes = Console.ReadLine();
                command.Parameters.AddWithValue("Notes", employee.Notes);

                Console.WriteLine("Enter Departments");
                employee.Department = Console.ReadLine();
                command.Parameters.AddWithValue("departList", employee.Department);



                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //public void DepartmentJoin()
        //{
        //    try
        //    {
        //        string ConString = @"Data Source=IN-100N0F3;Initial Catalog=EmployeePayrollDB;Integrated Security=True";
        //        using (SqlConnection connection = new SqlConnection(ConString))
        //        {
        //            // Creating SqlCommand objcet 
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandText = "SELECT EmployeeDetails.Id,EmployeeDetails.Name,EmployeeDetails.Salary, Department.DeptName FROM EmployeeDetails JOIN EmpDept ON EmpDept.EmpId = EmployeeDetails.Id JOIN Department ON Department.DeptId= EmpDept.DeptId";
        //            cmd.Connection = connection;
        //            // Opening Connection  
        //            connection.Open();
        //            // Executing the SQL query  
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + Convert.ToInt32(sdr["Salary"]) + ",  " + sdr["DeptName"] );

        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("OOPs, something went wrong.\n" + e);
        //    }
        //}
    }
}
