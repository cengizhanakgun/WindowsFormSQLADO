using MaterialSkin;
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


namespace MaterialDesignLogin
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-P7OC757\\SQLEXPRESS; Initial Catalog=App1; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;

            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green600, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        

        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }
        bool isThere;
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string userName = mUsername.Text;
            string password = mPassword.Text;
           

            connection.Open();
            SqlCommand command = new SqlCommand("Select *from login", connection);
            SqlDataReader reader = command.ExecuteReader(); 

            while(reader.Read())
            {
                if (userName == reader["userName"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd())
                {
                    isThere = true; 
                    break;
                }
                else
                {
                    isThere = false;    

                }
                connection.Close();

            }
            if (isThere)
            {
                MessageBox.Show("Başarılı bir şekilde giriş yaptınız");
            }
            else
            {
                MessageBox.Show("Giriş başarısız !!!");
            }
        }
    }
}
