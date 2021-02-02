using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Assignment1Feb
{
    class Assignment
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table after the DML command");
                Console.WriteLine("-----------------------------------------------");
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from Employee", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t {dr["empname"]}\t {dr["salary"]}\t {dr["deptno"]}");
                }
                return 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Insert into employee values('" + ename + "'," + esal + "," + did + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table....");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteOneRow()
        {
            try
            {
                Console.WriteLine("Emplyee id");
                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from Employee where empid=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is deleted to the table....");
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                ShowData();
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int UpdateOneRow()
        {
            try
            {
                Console.WriteLine("Enter employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update Employee set salary=" + esal + ",empname='" + ename + "' where empid=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int InsertWithOutParameter()
        {
            try
            {
                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into employee values(@ename,@esal,@deptid)", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int UpdateWithOutParameter()
        {
            try
            {
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());

                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update Employee set salary=@esal,empname=@ename where empid=@empid", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteWithOutParameter()
        {
            try
            {
                Console.WriteLine("Emplyee employee id");

                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from Employee where empid=@empid", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }


        public int InsertWithSP()
        {
            try
            {

                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_InsertEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is Inserted to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                cn.Close();
            }
        }

        public int UpdateWithSP()
        {
            try
            {
                Console.WriteLine("Enter Employee id for updation");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Emplyee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteWithSP()
        {
            try
            {
                Console.WriteLine("Enter Employee id for updation");
                var eid = Convert.ToInt32(Console.ReadLine());
               
                cn = new SqlConnection("Data Source=LAPTOP-75TSV0JU;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
               
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row is updated to the table....");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                cn.Close();
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Assignment ass = new Assignment();
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("Enter Your Choice With,Without and with stored Parameter--------- ");
                Console.WriteLine("1.To Insert the record with Sql parameter");
                Console.WriteLine("2.To Delete the record with Sql parameter");
                Console.WriteLine("3.To Update the record with Sql parameter");
                Console.WriteLine("4.To Insert the record withOut Sql parameter");
                Console.WriteLine("5.To Delete the record withOut Sql parameter");
                Console.WriteLine("6.To Update the record withOut Sql parameter");
                Console.WriteLine("7.To Insert the record with Stored Procedure Sql parameter");
                Console.WriteLine("8.To Delete the record with Stored Procedure Sql parameter");
                Console.WriteLine("9.To Update the record with Stored Procedure Sql parameter");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {

                    case 1:
                        ass.InsertOneRow();
                        break;
                    case 2:
                        ass.DeleteOneRow();
                        break;
                    case 3:
                        ass.UpdateOneRow();
                        break;
                    case 4:
                        ass.InsertWithOutParameter();
                        break;
                    case 5:
                        ass.DeleteWithOutParameter();
                        break;
                    case 6:
                        ass.UpdateWithOutParameter();
                        break;
                    case 7:
                        ass.InsertWithSP();
                        break;
                    case 8:
                        ass.DeleteWithSP();
                        break;
                    case 9:
                        ass.UpdateWithSP();
                        break;
                    case 10:
                        i = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
            }
        }
    }
}
 

