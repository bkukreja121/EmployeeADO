using System;
using System.Collections.Generic;

namespace EmployeePayroll
{
    public class Program
    {
        
        public static  void Main(string[] args)
        {

            InsertEmployee employeePayroll = new InsertEmployee();
            //employeePayroll.DepartmentJoin();


            bool value = employeePayroll.RegisterEmployee();
            if (value == true)
            {
                Console.WriteLine("Employee successfully registered");
            }
            else
            {
                Console.WriteLine("Employee Registration failed");
            }

            //GetEmployee getEmployee = new GetEmployee();
            //List<EmployeeDetails> details = getEmployee.GetEmployees();
            //foreach(EmployeeDetails item in details)
            //{
            //    Console.WriteLine($"{item.EmpId} {item.Name} {item.ProfileImage} {item.Gender} {item.Salary} {item.StartDate} {item.Notes} {item.Department}");
            //}
            //Console.ReadKey();



            //GetEmployee getEmployee = new GetEmployee();
            //getEmployee.GetEmployeeDetails();


        }
    }
}
