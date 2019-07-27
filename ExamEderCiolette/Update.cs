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
    public partial class Update : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = TournamentManager; " +
                                          "User ID = ProfileUser; Password = ProfileUser2019";
        public Update()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
        }

        private void BtnViews_Click(object sender, EventArgs e)
        {
            this.Hide();
            Views views = new Views();
            views.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                string mySql = "UPDATE Teams SET TeamName='" + txtTeamName.Text + "', CoachName='" + txtCoachName.Text + "'," +
                    " DirectorName='" + txtDirectorName.Text + "', AddressLine1='" + txtAddressLine1.Text + "', " +
                    " AddressLine2='" + txtAddressLine2.Text + "', PostCode='" + txtPostCode.Text + "'," +
                    "City='" + txtCity.Text + "',ContactNumber='" + txtContactNumber.Text + "'," +
                    "EmailAddress='" + txtEmailAddress.Text + "',CreatedBy='" + txtCreatedBy.Text + "'" +
                    "WHERE TeamId='" + txtTeamId.Text + "'";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                txtTeamName.Text = "";
                txtCoachName.Text = "";
                txtDirectorName.Text = "";
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtPostCode.Text = "";
                txtCity.Text = "";
                txtContactNumber.Text = "";
                txtEmailAddress.Text = "";
                txtCreatedBy.Text = "";

                MessageBox.Show("Saved successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }

        private void TxtTeamId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
