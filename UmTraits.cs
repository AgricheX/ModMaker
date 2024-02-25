using System;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod_Maker
{
    public partial class UmTraits : Form
    {
        #region InitializeComponent
        public UmTraits()
        {
            InitializeComponent();
        }

        private void UmTraits_Load(object sender, EventArgs e)
        {
            comboBox13.MouseClick += comboBox13_MouseClick;
            comboBox12.MouseClick += comboBox12_MouseClick;
            comboBox14.MouseClick += comboBox14_MouseClick;
            comboBox11.MouseClick += comboBox11_MouseClick;
        }

        #endregion

        #region comboBoxesMouseClick
        private void comboBox13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.Action1.Count == 0)
                {
                
                }
                else
                {
                    foreach (string act1 in Program.Action1)
                    {
                        if (!comboBox13.Items.Contains(act1))
                        {
                            comboBox13.Items.Add(act1);
                        }
                    }
                }
            }
        }
        private void comboBox12_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.Action2.Count == 0)
                {

                }
                else
                {
                    foreach (string act2 in Program.Action2)
                    {
                        if (!comboBox12.Items.Contains(act2))
                        {
                            comboBox12.Items.Add(act2);
                        }
                    }
                }
            }
        }

        private void comboBox14_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.Action3.Count == 0)
                {

                }
                else
                {
                    foreach (string act3 in Program.Action3)
                    {
                        if (!comboBox14.Items.Contains(act3))
                        {
                            comboBox14.Items.Add(act3);
                        }
                    }
                }
            }
        }

        private void comboBox11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.Action4.Count == 0)
                {

                }
                else
                {
                    foreach (string act4 in Program.Action4)
                    {
                        if (!comboBox11.Items.Contains(act4))
                        {
                            comboBox11.Items.Add(act4);
                        }   
                    }
                }
            }
        }

        #endregion

        #region createtrait
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox3.SelectedIndex != -1 && comboBox2.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && comboBox8.Text != "" && comboBox9.Text != "" && comboBox10.Text != "" && comboBox11.Text != "" && comboBox12.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
            {
                string NewTraitName = textBox1.Text;
                string[] NewTraitNamee;
                string NewNewTraitNamee = NewTraitName;
                if (NewTraitName.Contains(" "))
                {
                    NewTraitNamee = NewTraitName.Split(' ');
                    NewNewTraitNamee = NewTraitNamee[0] + NewTraitNamee[1];

                }
                string TrueTraitName = NewNewTraitNamee;

                string traitdescription = textBox2.Text;
                string traitbirth = textBox3.Text;
                string traitscale = textBox4.Text;
                string traithealth = textBox5.Text;
                string traitmaxage = textBox6.Text;
                string traitdamage = textBox7.Text;
                string traitspeed = textBox8.Text;
                string traitarmor = textBox9.Text;
                string traitattackspeed = textBox10.Text;
                string traitdodge = textBox11.Text;
                string traitaccuracy = textBox12.Text;
                string traitrange = textBox13.Text;
                string traittargets = textBox14.Text;
                string traitmaxcities = textBox15.Text;
                string traitinherit = textBox16.Text;
                string traitfertility = textBox17.Text;
                string traitmaxchildren = textBox18.Text;
                string traitcriticalchance = textBox19.Text;
                string traitknockback = textBox20.Text;
                string traitknockbackreduction = textBox21.Text;
                string traitintelligence = textBox22.Text;
                string traitwarfare = textBox23.Text;
                string traitdiplomacy = textBox24.Text;
                string traitstewardship = textBox25.Text;
                string traitopinion = textBox26.Text;
                string traitloyalty = textBox27.Text;
                string traitmaxcitysize = textBox28.Text;

                string traittype = comboBox2.Text;
                string traitgrouptype = comboBox3.Text;
                string traitgiven = comboBox4.Text;
                string traitremoved = comboBox5.Text;
                string traitcured = comboBox6.Text;
                string traitExplored = comboBox7.Text;
                string traitactiveera = comboBox8.Text;
                string traitactiveeranight = comboBox9.Text;
                string traitactiveeramoon = comboBox10.Text;

                string traitdeathaction = comboBox11.Text;
                string traitregularaction = comboBox12.Text;
                string traitattackaction = comboBox13.Text;
                string traitgetattackaction = comboBox14.Text;


                string icontraitname = comboBox1.Text;
                string[] arrayicontraitname;
                string icontraitnamee = icontraitname;
                if (icontraitname.Contains(".png"))
                {
                    arrayicontraitname = icontraitname.Split('.');
                    icontraitnamee = arrayicontraitname[0];
                }
                string trueicontraitname = icontraitnamee;

                string traitcode2 = " \n" +
                        "         ActorTrait " + TrueTraitName + "= new ActorTrait();\n" +
                        "         " + TrueTraitName + $".id = \"{NewTraitName}\";\n" +
                        "         " + TrueTraitName + ".path_icon = \"ui/Icons/" + trueicontraitname + "\";\n" +
                        "         " + TrueTraitName + ".type = TraitType." + traittype + ";\n" +
                        "         " + TrueTraitName + $".group_id = TraitGroup.{traitgrouptype};\n" +
                        "         " + TrueTraitName + ".can_be_cured = " + traitcured + ";\n" +
                        "         " + TrueTraitName + ".needs_to_be_explored = " + traitExplored + ";\n" +
                        "         " + TrueTraitName + ".can_be_given = " + traitgiven + ";\n" +
                        "         " + TrueTraitName + ".can_be_removed = " + traitremoved + ";\n" +
                        "         " + TrueTraitName + ".only_active_on_era_flag = " + traitactiveera + ";\n" +
                        "         " + TrueTraitName + ".era_active_night = " + traitactiveeranight + ";\n" +
                        "         " + TrueTraitName + ".era_active_moon = " + traitactiveeramoon + ";\n" +
                        "         " + TrueTraitName + ".birth = " + traitbirth + "f;\n" +
                        "         " + TrueTraitName + ".inherit = " + traitinherit + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.fertility] = " + traitfertility + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.max_children] = " + traitmaxchildren + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.max_age] = " + traitmaxage + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.attack_speed] = " + traitattackspeed + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.damage] = " + traitdamage + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.speed] = " + traitspeed + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.health] = " + traithealth + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.accuracy] = " + traitaccuracy + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.range] = " + traitrange + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.armor] = " + traitarmor + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.scale] = " + traitscale + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.dodge] = " + traitdodge + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.targets] = " + traittargets + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.critical_chance] = " + traitcriticalchance + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.knockback] = " + traitknockback + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.knockback_reduction] = " + traitknockbackreduction + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.intelligence] = " + traitintelligence + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.warfare] = " + traitwarfare + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.diplomacy] = " + traitdiplomacy + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.stewardship] = " + traitstewardship + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.opinion] = " + traitopinion + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.loyalty_traits] = " + traitloyalty + "f;\n" +
                        "         " + TrueTraitName + ".base_stats[S.cities] = " + traitmaxcities + ";\n" +
                        "         " + TrueTraitName + ".base_stats[S.zone_range] = " + traitmaxcitysize + ";\n" +
                        "         " + TrueTraitName + $".action_death = new WorldAction({traitdeathaction});\n" +
                        "         " + TrueTraitName + $".action_special_effect = new WorldAction({traitregularaction});\n" +
                        "         " + TrueTraitName + $".action_attack_target = new AttackAction({traitattackaction});\n" +
                        "         " + TrueTraitName + $".action_get_hit = new GetHitAction({traitgetattackaction});\n" +
                        $"         AssetManager.traits.add({TrueTraitName});\n" +
                        $"         addTraitToLocalizedLibrary({TrueTraitName}.id, \"{traitdescription}\");\n" +
                        $"         PlayerConfig.unlockTrait(\"{TrueTraitName}\");\n" +
                        " \n";

                if (Program.TraitsCode.Contains(traitcode2))
                {
                    int count = 1;
                    string tempName = $"{TrueTraitName}{count}";

                    string tempNameTGT = $"{traitgrouptype}{count}";
                    string tempNameCode = $"{traitcode2}{count}";

                    while (Program.TraitsCode.Contains(tempNameCode))
                    {
                        count++;
                        tempName = $"{TrueTraitName}_{count}";
                        tempNameTGT = $"{traitgrouptype}_{count}";
                        tempNameCode = $"{traitcode2}_{count}";
                    }
                    TrueTraitName = tempName;

                    traitgrouptype = tempNameTGT;

                    traitcode2 = tempNameCode;
                }

                if (pictureBox3.Image == null)
                {
                    MessageBox.Show("No Icon Selected.");
                    return;
                }
                else
                {
                    string icontraitName = pictureBox3.ImageLocation;
                    Program.TraitsIconNameList.Add(icontraitName);
                    string iconBase64;
                    using (MemoryStream icontraitsave = new MemoryStream())
                    {
                        pictureBox3.Image.Save(icontraitsave, ImageFormat.Png);
                        iconBase64 = Convert.ToBase64String(icontraitsave.ToArray());
                    }
                    Program.TraitsIcon.Add(iconBase64);
                }

                Program.TraitsCode.Add(traitcode2);
                Program.TraitsName.Add(TrueTraitName);
                Program.TraitsValue.Add(traitgrouptype);

                MessageBox.Show("Trait Created Successfully!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Text = "0.0";
                textBox4.Text = "0.0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                textBox12.Text = "0";
                textBox13.Text = "0";
                textBox14.Text = "0.0";
                textBox15.Text = "0";
                textBox16.Text = "0.0";
                textBox17.Text = "0.0";
                textBox18.Text = "0";
                textBox19.Text = "0.0";
                textBox20.Text = "0.0";
                textBox21.Text = "0.0";
                textBox22.Text = "0";
                textBox23.Text = "0";
                textBox24.Text = "0";
                textBox25.Text = "0";
                textBox26.Text = "0";
                textBox27.Text = "0";
                textBox28.Text = "0";

                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;
                comboBox6.Text = string.Empty;
                comboBox7.Text = string.Empty;
                comboBox8.Text = string.Empty;
                comboBox9.Text = string.Empty;
                comboBox10.Text = string.Empty;
                comboBox11.Text = string.Empty;
                comboBox12.Text = string.Empty;
                comboBox13.Text = string.Empty;
                comboBox14.Text = string.Empty;
                pictureBox3.Image = null;
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Trait Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox3.Image = Image.FromFile(pathImage);
                    pictureBox3.ImageLocation = openFileDialog.FileName;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox1.Text = fileName;
                }
            }
        }

        #endregion

        #region createtraitgroup
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox29.Text != "" && textBox30.Text != "" && textBox31.Text != "" && comboBox15.Text != "")
            {
                string tgname = textBox29.Text;
                string tgdescription = textBox30.Text;
                string tgcolor = textBox31.Text;
                string[] tgnamee;
                string newtgnamee = tgname;
                if (tgname.Contains(" "))
                {
                    tgnamee = tgname.Split(' ');
                    newtgnamee = tgnamee[0] + tgnamee[1];

                }
                string truetgname = newtgnamee;

                string tgtypefile2 = $"        public static string {truetgname} = " + $"\"{truetgname}\";\n";
                string tg3 = " \n" +
                         $"            ActorTraitGroupAsset {truetgname} = new ActorTraitGroupAsset();\n" +
                         $"            {truetgname}.id = \"{truetgname}\";\n" +
                         $"            {truetgname}.name = \"trait_group_{truetgname}\";\n" +
                         $"            {truetgname}.color = Toolbox.makeColor(\"{tgcolor}\", -1f);\n" +
                         $"            AssetManager.trait_groups.add({truetgname});\n" +
                         $"            addTraitGroupToLocalizedLibrary({truetgname}.id, \"{tgdescription}\");\n" +
                         " \n";

                if (Program.TraitGroupName.Contains(truetgname))
                {
                    int count = 1;
                    string temptg = $"{truetgname}" + $"{count}";
                    string tempNameDescription = $"{tgdescription}" + $"{count}";
                    string tempTGCode = $"{tg3}" + $"{count}";
                    string tempTypeFile2 = $"{tgtypefile2}{count}";

                    while (Program.TraitGroupName.Contains(tempTGCode))
                    {
                        count++;
                        temptg = $"{truetgname}_{count}";
                        tempNameDescription = $"{tgdescription}_{count}";
                        tempTGCode = $"{tg3}_{count}";
                        tempTypeFile2 = $"{tgtypefile2}_{count}";
                    }
                    truetgname = temptg;
                    tgdescription = tempNameDescription;
                    tg3 = tempTGCode;
                    tgtypefile2 = tempTypeFile2;
                }

                Program.TraitGroupName.Add(truetgname);
                Program.TraitGroupValues.Add(tgcolor);
                Program.TraitGroupValues.Add(tgdescription);
                Program.TraitGroupTypesFile.Add(tgtypefile2);
                Program.TraitGroupCode.Add(tg3);

                MessageBox.Show("TraitGroup Created Successfully!");

                textBox29.Clear();
                textBox30.Clear();
                textBox31.Clear();
                comboBox15.Text = string.Empty;
                pictureBox2.Image = null;

                comboBox3.Items.Add(truetgname);
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First");
            }
        }

        private void TraitGroupColor(string ColorName)
        {
            string directoryTraitsImages = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Colors");
            pictureBox2.ImageLocation = Path.Combine(directoryTraitsImages, $"{ColorName}" + ".png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        #endregion

        #region utils
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directoryTraitsImages = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "TraitImagens");
            string[] TraitsImages = Directory.GetFiles(directoryTraitsImages);

            foreach (string img in TraitsImages)
            {
                string[] separator = img.Split('\\');
                string[] traitimageSelected = separator[separator.Length - 1].Split('.');
                if (comboBox1.Text == traitimageSelected[0])
                {
                    pictureBox3.ImageLocation = Path.Combine(directoryTraitsImages, comboBox1.Text + ".png");
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            if (comboBox1.Text == "")
            {
                pictureBox3.Image = null;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Color = comboBox15.Text;

            Dictionary<string, string> colorMap = new Dictionary<string, string>
            {
             { "Color1", "#FFFFFF" },
             { "Color2", "#FFA500" },
             { "Color3", "#FFC0CB" },
             { "Color4", "#000000" },
             { "Color5", "#008000" },
             { "Color6", "#00FFFF" },
             { "Color7", "#FFFF00" },
             { "Color8", "#0000FF" },
             { "Color9", "#FF0000" },
             { "MakeYourColor", "PUTHERE" }
            };

            if (!string.IsNullOrEmpty(Color))
            {
                TraitGroupColor(Color);
                if (colorMap.ContainsKey(Color))
                {
                    textBox31.Text = colorMap[Color];
                }
                else
                {
                    textBox31.Text = string.Empty;
                }
            }
            else
            {
                textBox31.Text = string.Empty;
            }

            if (comboBox15.Text == "")
            {
                pictureBox2.Image = null;
            }
        }
        #endregion
    }
}