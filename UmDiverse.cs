using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod_Maker
{
    public partial class UmDiverse : Form
    {
        #region InitializeComponent
        public UmDiverse()
        {
            InitializeComponent();
        }

        private void UmDiverse_Load(object sender, EventArgs e)
        {
            comboBox4.MouseClick += comboBox4_MouseClick;
        }

        private List<string> AgesForbid = new List<string>();
        private List<string> AgesAllow = new List<string>();

        #endregion

        #region utilsbutton
        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.UnitName.Count == 0)
                {

                }
                else
                {
                    foreach (string unt1 in Program.UnitName)
                    {
                        if (!comboBox4.Items.Contains(unt1))
                        {
                            comboBox4.Items.Add(unt1);
                        }
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label14.Enabled = true;
                label14.Visible = true;
                comboBox5.Enabled = true;
                comboBox5.Visible = true;
                comboBox6.Items.Clear();
                comboBox6.Items.Add("spawnBiomass");
            }
            else
            {
                label14.Enabled = false;
                label14.Visible = false;
                comboBox5.Enabled = false;
                comboBox5.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label14.Enabled = false;
            label14.Visible = false;
            comboBox5.Enabled = false;
            comboBox5.Visible = false;
            if (radioButton2.Checked)
            {
                comboBox6.Items.Clear(); 
                comboBox6.Items.Add("simpleUnitAssetSpawnUsingIslands");
                comboBox6.Items.Add("spawnDragon");
                comboBox6.Items.Add("startAlienInvasion");
                comboBox6.Items.Add("spawnNecromancer");
                comboBox6.Items.Add("spawnEvilMage");
                comboBox6.Items.Add("spawnGreg");
                comboBox6.Items.Add("spawnTornado");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Invasion Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(pathImage);
                    pictureBox1.ImageLocation = openFileDialog.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox1.Text = fileName;
                }
            }
        }

        private void comboBox53_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox53.Text == "AngryBirds")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Projectiles");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "angry birds" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Projectile Sprite";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(pathImage);
                    pictureBox2.ImageLocation = openFileDialog.FileName;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox53.Text = fileName;
                }
            }
        }

        #endregion

        #region createAgesForbidAndAllow
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "None")
            {
                string forbidcode = " ";
                AgesForbid.Add(forbidcode);

                MessageBox.Show("Ages Forbid Created Successfully!");
                comboBox2.Text = string.Empty;
            }
            else if (comboBox2.Text != "" && textBox1.Text != "")
            {
                string NewInvasionName = textBox1.Text;
                string[] NewInvasionNamee;
                string NewNewInvasionNamee = NewInvasionName;
                if (NewInvasionName.Contains(" "))
                {
                    NewInvasionNamee = NewInvasionName.Split(' ');
                    NewNewInvasionNamee = NewInvasionNamee[0] + NewInvasionNamee[1];

                }
                string TrueInvasionName = NewNewInvasionNamee;
                string forbid = comboBox2.Text;
                string forbidcode = $"{TrueInvasionName}.ages_forbid.Add(S.{forbid});";
                AgesForbid.Add(forbidcode);

                MessageBox.Show("Ages Forbid Created Successfully!");
                comboBox2.Text = string.Empty;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please Write a Invasion Name First!");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Please Select a Ages Forbid First!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "None") 
            {
                string allowcode = " ";
                AgesAllow.Add(allowcode);

                MessageBox.Show("Ages Allow Created Successfully!");
                comboBox3.Text = string.Empty;
            }
            else if (comboBox3.Text != "" && textBox1.Text != "")
            {
                string NewInvasionName = textBox1.Text;
                string[] NewInvasionNamee;
                string NewNewInvasionNamee = NewInvasionName;
                if (NewInvasionName.Contains(" "))
                {
                    NewInvasionNamee = NewInvasionName.Split(' ');
                    NewNewInvasionNamee = NewInvasionNamee[0] + NewInvasionNamee[1];

                }
                string TrueInvasionName = NewNewInvasionNamee;
                string allow = comboBox3.Text;
                string allowcode = $"{TrueInvasionName}.ages_allow.Add(S.{allow});";
                AgesAllow.Add(allowcode);

                MessageBox.Show("Ages Allow Created Successfully!");
                comboBox3.Text = string.Empty;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please Write a Invasion Name First!");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Please Select a Ages Allow First!");
            }
        }

        #endregion

        #region createinvasions
        private void button4_Click(object sender, EventArgs e)
        {
            if (AgesForbid.Count == 0 && AgesAllow.Count == 0)
            {
                MessageBox.Show("Please Select a Ages Allow and Forbid First!");
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "" & textBox7.Text != "" & textBox8.Text != "" & textBox9.Text != "" && comboBox1.Text != "" && comboBox4.Text != "" && comboBox6.Text != "")
                {
                    if (radioButton1.Checked)
                    {
                        string NewInvasionName = textBox1.Text;
                        string[] NewInvasionNamee;
                        string NewNewInvasionNamee = NewInvasionName;
                        if (NewInvasionName.Contains(" "))
                        {
                            NewInvasionNamee = NewInvasionName.Split(' ');
                            NewNewInvasionNamee = NewInvasionNamee[0] + NewInvasionNamee[1];

                        }
                        string TrueInvasionName = NewNewInvasionNamee;

                        string rate = textBox3.Text; 
                        if (int.TryParse(textBox3.Text, out int number))
                        {
                            if (number > 9)
                            {
                                rate = "9";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please use numbers in \"Rate\".");
                        }

                        string description = textBox2.Text;
                        string chance = textBox4.Text;
                        string minworldcities = textBox5.Text;
                        string maxexistingunits = textBox6.Text;
                        string minworldpopulation = textBox7.Text;
                        string unitsmin = textBox8.Text;
                        string unitsmax = textBox9.Text;

                        string iconinvasionname = comboBox1.Text;
                        string[] arrayiconinvasionname;
                        string iconinvasionnamee = iconinvasionname;
                        if (iconinvasionname.Contains(".png"))
                        {
                            arrayiconinvasionname = iconinvasionname.Split('.');
                            iconinvasionnamee = arrayiconinvasionname[0];
                        }
                        string trueiconinvasionname = iconinvasionnamee;
                        string units = comboBox4.Text;
                        string action = comboBox6.Text;

                        string forbids = string.Join(Environment.NewLine, AgesForbid);
                        string allows = string.Join(Environment.NewLine, AgesAllow);

                        string invasionscode1 = $"          DisasterAsset {TrueInvasionName} = new DisasterAsset();\n" +
                        $"          {TrueInvasionName}.id = \"{TrueInvasionName}\";\n" +
                        $"          {TrueInvasionName}.rate = {rate};\n" +
                        $"          {TrueInvasionName}.chance = {chance}f;\n" +
                        $"          {TrueInvasionName}.min_world_cities = {minworldcities};\n" +
                        $"          {TrueInvasionName}.max_existing_units = {maxexistingunits};\n" +
                        $"          {TrueInvasionName}.world_log = \"{description}\";\n" +
                        $"          {TrueInvasionName}.world_log_icon = \"{trueiconinvasionname}\";\n" +
                        $"          {TrueInvasionName}.min_world_population = {minworldpopulation};\n" +
                        $"          {TrueInvasionName}.spawn_asset_unit = \"{units}\";\n" +
                        $"          {TrueInvasionName}.units_min = {unitsmin};\n" +
                        $"          {TrueInvasionName}.units_max = {unitsmax};\n" +
                        $"          {forbids}" +
                        $"          {allows}" +
                        $"          {TrueInvasionName}.action = new DisasterAction(AssetManager.disasters.{action});\n" +
                        $"          AssetManager.disasters.add({TrueInvasionName});\n";

                        if (Program.InvasionsCode.Contains(invasionscode1))
                        {
                            int count = 1;
                            string tempName = $"{TrueInvasionName}{count}";

                            string tempNameCode = $"{invasionscode1}{count}";

                            while (Program.TraitsCode.Contains(tempNameCode))
                            {
                                count++;
                                tempName = $"{TrueInvasionName}_{count}";
                                tempNameCode = $"{invasionscode1}_{count}";
                            }
                            TrueInvasionName = tempName;

                            invasionscode1 = tempNameCode;
                        }

                            string selectedText = comboBox1.Text;
                            if (!comboBox1.Items.Contains(selectedText))
                            {
                                if (pictureBox1.Image == null)
                                {
                                    MessageBox.Show("No Icon Selected.");
                                    return;
                                }
                                else
                                {
                                    string iconinvasionName = pictureBox1.ImageLocation;
                                    Program.InvasionsIconNameList.Add(iconinvasionName);
                                    string iconBase64;
                                    using (MemoryStream iconinvasionsave = new MemoryStream())
                                    {
                                        pictureBox1.Image.Save(iconinvasionsave, ImageFormat.Png);
                                        iconBase64 = Convert.ToBase64String(iconinvasionsave.ToArray());
                                    }
                                    Program.InvasionsIcon.Add(iconBase64);
                                }
                            }

                        Program.InvasionsCode.Add(invasionscode1);
                        Program.InvasionsName.Add(TrueInvasionName);

                        MessageBox.Show("Invasion Created Successfully!");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Text = "1";
                        textBox4.Text = "0.1";
                        textBox5.Text = "1";
                        textBox6.Text = "1";
                        textBox7.Text = "1";
                        textBox8.Text = "1";
                        textBox9.Text = "1";

                        comboBox1.Text = string.Empty;
                        comboBox2.Text = string.Empty;
                        comboBox3.Text = string.Empty;
                        comboBox4.Text = string.Empty;
                        comboBox5.Text = string.Empty;
                        comboBox6.Text = string.Empty;
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;

                        AgesForbid.Clear();
                        AgesAllow.Clear();
                    }
                    else if (radioButton2.Checked)
                    {
                        string NewInvasionName = textBox1.Text;
                        string[] NewInvasionNamee;
                        string NewNewInvasionNamee = NewInvasionName;
                        if (NewInvasionName.Contains(" "))
                        {
                            NewInvasionNamee = NewInvasionName.Split(' ');
                            NewNewInvasionNamee = NewInvasionNamee[0] + NewInvasionNamee[1];

                        }
                        string TrueInvasionName = NewNewInvasionNamee;

                        string rate = textBox3.Text;
                        if (int.TryParse(textBox3.Text, out int number))
                        {
                            if (number > 9)
                            {
                                rate = "9";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please use numbers in \"Rate\".");
                        }

                        string description = textBox2.Text;
                        string chance = textBox4.Text;
                        string minworldcities = textBox5.Text;
                        string maxexistingunits = textBox6.Text;
                        string minworldpopulation = textBox7.Text;
                        string unitsmin = textBox8.Text;
                        string unitsmax = textBox9.Text;

                        string iconinvasionname = comboBox1.Text;
                        string[] arrayiconinvasionname;
                        string iconinvasionnamee = iconinvasionname;
                        if (iconinvasionname.Contains(".png"))
                        {
                            arrayiconinvasionname = iconinvasionname.Split('.');
                            iconinvasionnamee = arrayiconinvasionname[0];
                        }
                        string trueiconinvasionname = iconinvasionnamee;
                        string units = comboBox4.Text;
                        string build = comboBox5.Text;
                        string action = comboBox6.Text;

                        string forbids = string.Join(Environment.NewLine, AgesForbid);
                        string allows = string.Join(Environment.NewLine, AgesAllow);

                        string invasionscode2 = $"          DisasterAsset {TrueInvasionName} = new DisasterAsset();\n" +
                        $"          {TrueInvasionName}.id = \"{TrueInvasionName}\";\n" +
                        $"          {TrueInvasionName}.rate = {rate};\n" +
                        $"          {TrueInvasionName}.chance = {chance}f;\n" +
                        $"          {TrueInvasionName}.min_world_cities = {minworldcities};\n" +
                        $"          {TrueInvasionName}.max_existing_units = {maxexistingunits};\n" +
                        $"          {TrueInvasionName}.world_log = \"{description}\";\n" +
                        $"          {TrueInvasionName}.world_log_icon = \"{trueiconinvasionname}\";\n" +
                        $"          {TrueInvasionName}.min_world_population = {minworldpopulation};\n" +
                        $"          {TrueInvasionName}.spawn_asset_building = \"{build}\";\n" +
                        $"          {TrueInvasionName}.spawn_asset_unit = \"{units}\";\n" +
                        $"          {TrueInvasionName}.units_min = {unitsmin};\n" +
                        $"          {TrueInvasionName}.units_max = {unitsmax};\n" +
                        $"          {forbids}" +
                        $"          {allows}" +
                        $"          {TrueInvasionName}.action = new DisasterAction(AssetManager.disasters.{action});\n" +
                        $"          AssetManager.disasters.add({TrueInvasionName});\n";

                        if (Program.InvasionsCode.Contains(invasionscode2))
                        {
                            int count = 1;
                            string tempName = $"{TrueInvasionName}{count}";

                            string tempNameCode = $"{invasionscode2}{count}";

                            while (Program.InvasionsCode.Contains(tempNameCode))
                            {
                                count++;
                                tempName = $"{TrueInvasionName}_{count}";
                                tempNameCode = $"{invasionscode2}_{count}";
                            }
                            TrueInvasionName = tempName;

                            invasionscode2 = tempNameCode;
                        }

                        string selectedText = comboBox1.Text;
                        if (!comboBox1.Items.Contains(selectedText))
                        {
                            if (pictureBox1.Image == null)
                            {
                                MessageBox.Show("No Icon Selected.");
                                return;
                            }
                            else
                            {
                                string iconinvasionName = pictureBox1.ImageLocation;
                                Program.InvasionsIconNameList.Add(iconinvasionName);
                                string iconBase64;
                                using (MemoryStream iconinvasionsave = new MemoryStream())
                                {
                                    pictureBox1.Image.Save(iconinvasionsave, ImageFormat.Png);
                                    iconBase64 = Convert.ToBase64String(iconinvasionsave.ToArray());
                                }
                                Program.InvasionsIcon.Add(iconBase64);
                            }
                        }

                        Program.InvasionsCode.Add(invasionscode2);
                        Program.InvasionsName.Add(TrueInvasionName);

                        MessageBox.Show("Invasion Created Successfully!");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Text = "1";
                        textBox4.Text = "0.1";
                        textBox5.Text = "1";
                        textBox6.Text = "1";
                        textBox7.Text = "1";
                        textBox8.Text = "1";
                        textBox9.Text = "1";

                        comboBox1.Text = string.Empty;
                        comboBox2.Text = string.Empty;
                        comboBox3.Text = string.Empty;
                        comboBox4.Text = string.Empty;
                        comboBox5.Text = string.Empty;
                        comboBox6.Text = string.Empty;
                        pictureBox1.Image = null;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;

                        AgesForbid.Clear();
                        AgesAllow.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Fill in All Blanks First!");
                }
            }
        }
        #endregion

        #region projectileRadionButton

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label19.Visible = true;
            comboBox9.Visible = true;

            label19.Enabled = true;
            comboBox9.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label19.Visible = false;
            comboBox9.Visible = false;

            label19.Enabled = false;
            comboBox9.Enabled = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label20.Visible = true;
            comboBox10.Visible = true;

            label20.Enabled = true;
            comboBox10.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label20.Visible = false;
            comboBox10.Visible = false;

            label20.Enabled = false;
            comboBox10.Enabled = false;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label21.Visible = true;
            comboBox11.Visible = true;

            label21.Enabled = true;
            comboBox11.Enabled = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label21.Visible = false;
            comboBox11.Visible = false;

            label21.Enabled = false;
            comboBox11.Enabled = false;
        }

        #endregion

        #region createprojectile
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && (radioButton3.Checked || radioButton4.Checked) && (radioButton6.Checked || radioButton5.Checked) && (radioButton8.Checked || radioButton7.Checked) && pictureBox2.Image != null)
            {
                if (radioButton3.Checked && radioButton6.Checked && radioButton8.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectiletexturashadow = comboBox11.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundlaunche = comboBox9.Text;
                    string projectilesoundimpact = comboBox10.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.texture_shadow = \"{projectiletexturashadow};\n" +
                    $"          {TrueProjectilesName}.sound_launch = \"event:/SFX/WEAPONS/{projectilesoundlaunche}\";\n" +
                    $"          {TrueProjectilesName}.sound_impact = \"event:/SFX/WEAPONS/{projectilesoundimpact}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;

                }
                else if (radioButton3.Checked && radioButton6.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundlaunche = comboBox9.Text;
                    string projectilesoundimpact = comboBox10.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.sound_launch = \"event:/SFX/WEAPONS/{projectilesoundlaunche}\";\n" +
                    $"          {TrueProjectilesName}.sound_impact = \"event:/SFX/WEAPONS/{projectilesoundimpact}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if(radioButton3.Checked && radioButton8.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectiletexturashadow = comboBox11.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundlaunche = comboBox9.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.texture_shadow = \"{projectiletexturashadow};\n" +
                    $"          {TrueProjectilesName}.sound_launch = \"event:/SFX/WEAPONS/{projectilesoundlaunche}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if(radioButton6.Checked && radioButton8.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectiletexturashadow = comboBox11.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundimpact = comboBox10.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.texture_shadow = \"{projectiletexturashadow};\n" +
                    $"          {TrueProjectilesName}.sound_impact = \"event:/SFX/WEAPONS/{projectilesoundimpact}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if (radioButton3.Checked) 
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundlaunche = comboBox9.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.sound_launch = \"event:/SFX/WEAPONS/{projectilesoundlaunche}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if (radioButton6.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectilelooped = comboBox12.Text;
                    string projectilesoundimpact = comboBox10.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.sound_impact = \"event:/SFX/WEAPONS/{projectilesoundimpact}\";\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if (radioButton8.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectiletexturashadow = comboBox11.Text;
                    string projectilelooped = comboBox12.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          {TrueProjectilesName}.texture_shadow = \"{projectiletexturashadow};\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
                else if (radioButton4.Checked && radioButton5.Checked && radioButton7.Checked)
                {
                    string NewProjectilesName = textBox10.Text;
                    string[] NewProjectilesNamee;
                    string NewNewProjectilesNamee = NewProjectilesName;
                    if (NewProjectilesName.Contains(" "))
                    {
                        NewProjectilesNamee = NewProjectilesName.Split(' ');
                        NewNewProjectilesNamee = NewProjectilesNamee[0] + NewProjectilesNamee[1];

                    }
                    string TrueProjectilesName = NewNewProjectilesNamee;

                    string projectileparabolic = comboBox8.Text;
                    string projectilelooped = comboBox12.Text;

                    string projectilecode = $"          ProjectileAsset {TrueProjectilesName} = new ProjectileAsset();\n" +
                    $"          {TrueProjectilesName}.id = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.texture = \"{TrueProjectilesName}\";\n" +
                    $"          {TrueProjectilesName}.trailEffect_enabled = true;\n" +
                    $"          {TrueProjectilesName}.look_at_target = true;\n" +
                    $"          {TrueProjectilesName}.parabolic = {projectileparabolic};\n" +
                    $"          {TrueProjectilesName}.looped = {projectilelooped};\n" +
                    $"          {TrueProjectilesName}.speed = 18f;\n" +
                    $"          AssetManager.projectiles.add({TrueProjectilesName});\n" +
                    " \n";

                    string ProjectileIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.ProjectileIconNameList.Add(ProjectileIconName);
                    string projectileiconBase64;
                    using (MemoryStream projectileiconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(projectileiconsave, ImageFormat.Png);
                        projectileiconBase64 = Convert.ToBase64String(projectileiconsave.ToArray());
                    }
                    Program.ProjectileIcon.Add(projectileiconBase64);

                    string projectilefolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\effects\projectiles\";
                    string projectilesfoldername = $"{TrueProjectilesName}";
                    string createprojectilesfolder = projectilefolder + projectilesfoldername;
                    Directory.CreateDirectory(createprojectilesfolder);

                    if (Program.ProjectileIcon != null && Program.ProjectileIcon.Count > 0)
                    {
                        for (int i = 0; i < Program.ProjectileIcon.Count; i++)
                        {
                            string iconprojectileprojectileBase64 = Program.ProjectileIcon[i];
                            byte[] imagemBytesProjectile = Convert.FromBase64String(iconprojectileprojectileBase64);

                            string iconProjectileFilePath = Path.Combine(createprojectilesfolder, Path.GetFileName(Program.ProjectileIconNameList[i]));
                            File.WriteAllBytes(iconProjectileFilePath, imagemBytesProjectile);
                        }
                    }

                    Program.ProjectileCode.Add(projectilecode);
                    Program.ProjectileName.Add(TrueProjectilesName);

                    MessageBox.Show("The Projectile Were Successfully Saved!");

                    textBox10.Clear();
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton6.Checked = false;
                    radioButton5.Checked = false;
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    comboBox53.Text = "";
                    pictureBox2.Image = null;
                }
            }
            else
            {
                    MessageBox.Show("Fill in All Blanks First!");
            }
        }
        #endregion
    }
}