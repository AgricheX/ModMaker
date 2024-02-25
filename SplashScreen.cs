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
    public partial class SplashScreen : Form
    {
        #region InitializeComponent
        public SplashScreen()
        {
            InitializeComponent();
        }

        private static Random random = new Random();

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            int random2 = random.Next(phrases.Count);
            label2.Text = phrases[random2];
        }

        #endregion

        #region phrases
        List<string> phrases = new List<string>
        {
            "Stay hydrated, drink water!",
            "Create massive slime invasions in your world!",
            "ModMaker was made by aliens who play WorldBox.",
            "Now with a few clicks, you can turn your imagination\n" + "into reality!",
            "Transform your WorldBox into a Magical World!",
            "Want to see tanks at WorldBox? Now it's possible!",
            "Transform your WorldBox into a Futuristic World!",
            "You can now create lightsabers in WorldBox!",
            "Get weapons from your favorite games on WorldBox with\n" + "ModMaker!",
            "Subscribe to my YouTube channel. @AgricheX",
            "Create as many mods as you can!",
            "Found any bugs? Report me on discord!\n" + "My @: @agrichex",
            "Support me by subscribing to my Patreon to encourage me to\n" + "bring updates to ModMaker! patreon.com/Agriche",
            "Support me by subscribing to my Patreon!"
        };
        #endregion

        #region timers

        private void timerProgressBar_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                timerProgressBar.Stop();
                timerFadeOUT.Start();
            }
            if (progressBar1.Value == 50)
            {
                int random2 = random.Next(phrases.Count);
                label2.Text = phrases[random2];
            }
            if (progressBar1.Value == 90)
            {
                int random2 = random.Next(phrases.Count);
                label2.Text = phrases[random2];
            }
            else
            {

            }
        }

        private void timerFadeIN_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                timerFadeIN.Stop();
            }
            else
            {
                this.Opacity = this.Opacity + 0.02;
            }
        }

        private void timerFadeOUT_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 0)
            {
                timerFadeOUT.Stop();
                this.Dispose();
                ModMakerMain modmakermain = new ModMakerMain();
                modmakermain.Show();
            }
            else
            {
                this.Opacity = this.Opacity - 0.04;
            }
        }
        #endregion
    }
}
