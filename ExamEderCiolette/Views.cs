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
    public partial class Views : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = TournamentManager; " +
                                          "User ID = ProfileUser; Password = ProfileUser2019";

        public Views()
        {
            InitializeComponent();
            GetContacts();
        }

        private void GetContacts()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();
                string query = "SELECT * FROM Teams ORDER BY TeamName";

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = query;

                DataTable myContacts = new DataTable();
                myContacts.Columns.Add(new DataColumn("TeamId"));
                myContacts.Columns.Add(new DataColumn("TeamName"));
                myContacts.Columns.Add(new DataColumn("CoachName"));
                myContacts.Columns.Add(new DataColumn("DirectorName"));
                myContacts.Columns.Add(new DataColumn("AddressLine1"));
                myContacts.Columns.Add(new DataColumn("AddressLine2"));
                myContacts.Columns.Add(new DataColumn("PostCode"));
                myContacts.Columns.Add(new DataColumn("City"));
                myContacts.Columns.Add(new DataColumn("ContactNumber"));
                myContacts.Columns.Add(new DataColumn("EmailAddress"));
                myContacts.Columns.Add(new DataColumn("CreatedBy"));

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    DataRow contact = myContacts.NewRow();
                    contact["TeamId"] = myReader["TeamId"];
                    contact["TeamName"] = myReader["TeamName"];
                    contact["CoachName"] = myReader["CoachName"];
                    contact["DirectorName"] = myReader["DirectorName"];
                    contact["AddressLine1"] = myReader["AddressLine1"];
                    contact["AddressLine2"] = myReader["AddressLine2"];
                    contact["PostCode"] = myReader["PostCode"];
                    contact["City"] = myReader["City"];
                    contact["ContactNumber"] = myReader["ContactNumber"];
                    contact["EmailAddress"] = myReader["EmailAddress"];
                    contact["CreatedBy"] = myReader["CreatedBy"];


                    myContacts.Rows.Add(contact);

                }

                dgView.DataSource = myContacts;

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
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
        }

        private void DgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                Insert insert = new Insert();
                insert.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.ShowDialog();
        }
    }
}
