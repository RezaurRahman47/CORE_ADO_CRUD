using CORE_ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_ADO_CRUD.DAL
{
    public class EmployeeDataAccessLayer:Getway
    {
        //View all Employee details

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> listEmployee = new List<Employee>();
            Command.CommandText = "Sp_GetAllEmployees";
            Command.CommandType = CommandType.StoredProcedure;

            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee();

                employee.ID = Convert.ToInt32(reader["EmployeeId"]);
                employee.Name = reader["Name"].ToString();
                employee.Gender = reader["Gender"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.City = reader["City"].ToString();

                listEmployee.Add(employee);
            }

            Connection.Close();

            return listEmployee;
        }
       

        //ADD New Employee 

        public void AddEmployee(Employee employee)
        {

            Command.CommandText = "Sp_AddEmployee";
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@Name",employee.Name);
            Command.Parameters.AddWithValue("@Gender", employee.Gender);
            Command.Parameters.AddWithValue("@Department", employee.Department);
            Command.Parameters.AddWithValue("@City", employee.City);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        //Update Employee

        public void UpdateEmployee(Employee employee)
        {
            Command.CommandText = "Sp_UpdateEmployee";
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@EmpId", employee.ID);
            Command.Parameters.AddWithValue("@Name", employee.Name);
            Command.Parameters.AddWithValue("@Gender", employee.Gender);
            Command.Parameters.AddWithValue("@Department", employee.Department);
            Command.Parameters.AddWithValue("@City", employee.City);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        //Get the details of a particular employee   
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            
            string sqlQuery = "SELECT * FROM Employee WHERE EmployeeID= " + id;
            Command.CommandText = sqlQuery;
            


            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                employee.ID = Convert.ToInt32(reader["EmployeeID"]);
                employee.Name = reader["Name"].ToString();
                employee.Gender = reader["Gender"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.City = reader["City"].ToString();
            }
        
            return employee;
        }

        //Delete Employee

        public void DeleteEmployee(int? id)
        {
            Command.CommandText = "Sp_DeleteEmployee";
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@EmpId", id);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

    }
}
