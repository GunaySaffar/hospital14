using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Xestexana_qebul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            var sobeAd = textBox1.Text;
            var sql = "insert into sobe(ad) values('" + sobeAd + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            var selectSql = "select * from Sobe";
            var selectCmd = new SqlCommand(selectSql, conn);
            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.Items.Clear();
            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["ad"]);
            }
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            var selectSql = "select * from Sobe";
            var selectCmd = new SqlCommand(selectSql, conn);
            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.Items.Clear();
            for (var i=0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["ad"]);
            }
            conn.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            var selectedInd = comboBox1.SelectedIndex;
            var sql = "delete from Sobe where id=" + selectedInd + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            var selectSql = "select * from Sobe";
            var selectCmd = new SqlCommand(selectSql, conn);
            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.Items.Clear();
            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["ad"]);
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
            conn.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            var selectedInd = comboBox1.SelectedIndex;
            var sql = "update Sobe set   where id=" + selectedInd + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            var selectSql = "select * from Sobe";
            var selectCmd = new SqlCommand(selectSql, conn);
            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.Items.Clear();
            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["ad"]);
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
            conn.Close();
        }
    }
}
