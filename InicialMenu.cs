using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod_Maker
{
    public partial class InicialMenu : Form
    {
        #region InitializeComponent
        public InicialMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region buttons
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                SplashScreen splashscreen = new SplashScreen();
                splashscreen.Show();
            }
            else if (radioButton2.Checked)
            {
                MessageBox.Show("Not available.");
            }
            else
            {
                MessageBox.Show("Choose a version first!");
            }
        }
        #endregion
    }
}