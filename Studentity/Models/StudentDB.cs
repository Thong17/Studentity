using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Studentity.Models
{
    public class StudentDB
    {
        string cs = ConfigurationManager.ConnectionStrings["winCon"].ConnectionString;
        public List<Student> ListAll()
        {
            List<Student> list = new List<Student>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Student
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        State = rdr["State"].ToString(),
                        Country = rdr["Country"].ToString()

                    });
                }
                return list;
            }
            
        }
        public int Add(Student std)
        {
            int i;
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateStudent", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", std.ID);
                com.Parameters.AddWithValue("@Name", std.Name);
                com.Parameters.AddWithValue("@Age", std.Age);
                com.Parameters.AddWithValue("@State", std.State);
                com.Parameters.AddWithValue("@Country", std.Country);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}