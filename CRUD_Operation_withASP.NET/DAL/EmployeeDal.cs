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
            List<Employee> emp = new List<Employee>();
            string qry = "select * from Employee";
            cmd=  
        }
        
    }

    }
} 

