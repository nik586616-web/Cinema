using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class ClassAdo
    {
        public string ConnectionString;
        public SqlCommand cmd;
        public ClassAdo()
        {
            ConnectionString = "Data Source=DESKTOP-0UJVRSB\\SQLEXPRES;Initial Catalog=DBCinema;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public DataSet GetDataSet(string sqlQuery)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            return ds;
        }
        public void DataGridBind(string sqlQuery, DataGridView dataGridView)
        {
            DataSet ds = GetDataSet(sqlQuery);
            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }
        public void comboBoxBind(string sqlQuery, ComboBox comboBox, string displayMember, string valueMember)
        {
            DataSet ds = GetDataSet(sqlQuery);
            comboBox.DataSource = ds.Tables[0];
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedValue = ds.Tables[0].Rows[0][valueMember].ToString();
        }
        public void CmdExec(string commandText)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = commandText;
            cmd.ExecuteNonQuery();
        }
        public SqlCommand StProcExec(string commandText)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = commandText;
            return cmd;
        }
    }
}
