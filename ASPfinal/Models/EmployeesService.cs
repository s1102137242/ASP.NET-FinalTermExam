using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPfinal.Models
{
    public class EmployeesService
    {
        private string GetconnectionStrings()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }

        public List<Employees> GetEmployeesName()
        {
            DataTable result = new DataTable();
            string sql = @"SELECT EmployeeID,LastName+'-'+FirstName as LastName FROM HR.Employees ";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                sqlAdapter.SelectCommand = new SqlCommand(sql, conn);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapEmployeeIDList(result);
        }

        private List<Employees> MapEmployeeIDList(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    LastName = row["LastName"].ToString(),
                    EmployeeID = (string)row["EmployeeID"]
                });
            }
            return result;
        }

    }
}