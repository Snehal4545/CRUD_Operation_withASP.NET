using CRUD_Operation_withASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation_withASP.NET.DAL
{
    public class EmployeeDal
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> emplist = new List<Employee>();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
           if(dr.HasRows)
           {
                while(dr.Read())
                {
                    Employee e = new Employee();
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToDouble(dr["Salary"]);
                    emplist.Add(e);
                }

           }
            con.Close();
            return emplist;
        }
        public Employee GetEmployeeById(int Id)
        {
            Employee e = new Employee();
            string qry = "select * from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToDouble(dr["Salary"]);
                }   

            }
            con.Close();
            return e;

        }
        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Employee values(@Name,@Salary)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@price", emp.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateEmployee(Employee emp)
        { 

            string qry = "update Employee set Name=@Name ,Salary=@Salary where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@price", emp.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int Id)
        {
            string qry = "delete from Employee where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }

    
} 

