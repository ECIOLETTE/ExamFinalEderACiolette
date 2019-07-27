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

namespace ExamEderCiolette
{
    public partial class Delete : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = TournamentManager; " +
                          "User ID = ProfileUser; Password = ProfileUser2019";
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "DELETE FROM Teams WHERE TeamId = " + txtTeamId_Delete.Text;

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                txtTeamId_Delete.Text = "";

                 MessageBox.Show("successfully deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail!");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main formInicial = new Main();
            formInicial.ShowDialog();
        }
    }
}
