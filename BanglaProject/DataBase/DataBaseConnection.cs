using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BanglaProject.DataBase
{
    public class DataBaseConnection
    {
        private SqlConnection Sqlcon { set; get; }
        private SqlCommand Sqlcom { set; get; }
        private SqlDataAdapter Sda { set; get; }
        private DataSet Ds { set; get; }

        private readonly string connectionString =
    @"Data Source=DESKTOP-V36EUUO\SQLEXPRESS;Initial Catalog=FarmInvoiceManager;Integrated Security=True;Encrypt=False";
        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        public DataBaseConnection()
        {


            try
            {
                this.Sqlcon = new SqlConnection(@"Data Source=DESKTOP-V36EUUO\SQLEXPRESS;Initial Catalog=FarmInvoiceManager;Integrated Security=True;Encrypt=False");

                Sqlcon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in opening the database system, please try again.\n" + ex.Message);
            }
        }

        //private void QueryText(string query)
        //{
        //    this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        //}

        public DataSet ExecuteQuery(string sql)
        {
            try
            {
                this.Sqlcom = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
                this.Sda = new SqlDataAdapter(this.Sqlcom);
                this.Ds = new DataSet();
                this.Sda.Fill(this.Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + ex.Message);
                return null;
            }
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            try
            {
                this.Sqlcom = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
                this.Sda = new SqlDataAdapter(this.Sqlcom);
                this.Ds = new DataSet();
                this.Sda.Fill(this.Ds);
                return Ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + ex.Message);
                return null;
            }
        }

        public int ExecuteDMLQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw; 
            }
        }


        public void CloseConnection()
        {
            try
            {
                if (this.Sqlcon != null && this.Sqlcon.State == ConnectionState.Open)
                {
                    this.Sqlcon.Close();
                    this.Sqlcon.Dispose();
                    Sqlcon = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in closing database system, please try again.\n" + ex.Message);
            }
        }
        public int ExecuteDMLQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                this.Sqlcom = new SqlCommand(sql, this.Sqlcon);
                if (parameters != null && parameters.Length > 0)
                    this.Sqlcom.Parameters.AddRange(parameters);

                return this.Sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + ex.Message);
                return -1;
            }
        }


        public object ExecuteScalarQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                this.Sqlcom = new SqlCommand(sql, this.Sqlcon);
                if (parameters != null && parameters.Length > 0)
                    this.Sqlcom.Parameters.AddRange(parameters);

                return this.Sqlcom.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable ExecuteQueryTable(string sql, params SqlParameter[] parameters)
        {
            try
            {
                this.Sqlcom = new SqlCommand(sql, this.Sqlcon);

                if (parameters != null && parameters.Length > 0)
                    this.Sqlcom.Parameters.AddRange(parameters);

                this.Sda = new SqlDataAdapter(this.Sqlcom);
                this.Ds = new DataSet();
                this.Sda.Fill(this.Ds);

                return this.Ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error has occurred in the database system, please try again.\n" + ex.Message
                );
                return null;
            }
        }



    }
}
