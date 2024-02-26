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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod_Maker
{
    public partial class UmTab : Form
    {
        #region InitializeComponent
        public UmTab()
        {
            InitializeComponent();
        }

        private void UmTab_Load(object sender, EventArgs e)
        {
            comboBox3.MouseClick += comboBox3_MouseClick;
        }
        #endregion

        #region utilsbutton
        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
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
                        if (!comboBox3.Items.Contains(unt1))
                        {
                            comboBox3.Items.Add(unt1);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Tab Icon";
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

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Button Item Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox3.Image = Image.FromFile(pathImage);
                    pictureBox3.ImageLocation = openFileDialog.FileName;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox5.Text = fileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Button Unit Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(pathImage);
                    pictureBox2.ImageLocation = openFileDialog.FileName;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox4.Text = fileName;
                }
            }
        }

        #endregion

        #region imagestopicturebox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MonsterTab")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "TabIcon", "Icon3");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "TabIcon" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "")
            {
                pictureBox1.Image = null;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "SanjiRaidSuit")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "ButtonsIcon", "Sanji");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_SanjiRaidSuit" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox5.Text == "")
            {
                pictureBox3.Image = null;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directoryUnitButtonImages = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "ButtonsIcon", "Units");
            string[] UnitButtonImages = Directory.GetFiles(directoryUnitButtonImages);

            foreach (string img in UnitButtonImages)
            {
                string[] separator = img.Split('\\');
                string[] unitbuttonimageSelected = separator[separator.Length - 1].Split('.');
                if (comboBox4.Text == unitbuttonimageSelected[0])
                {
                    pictureBox2.ImageLocation = Path.Combine(directoryUnitButtonImages, comboBox4.Text + ".png");
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            if (comboBox4.Text == "")
            {
                pictureBox2.Image = null;
            }
        }

        #endregion

        #region createtab
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox2.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                string TabCreatorName = textBox1.Text;
                string[] NewTabCreatorNamee;
                string NewNewTabCreatorNamee = TabCreatorName;
                if (TabCreatorName.Contains(" "))
                {
                    NewTabCreatorNamee = TabCreatorName.Split(' ');
                    NewNewTabCreatorNamee = NewTabCreatorNamee[0] + NewTabCreatorNamee[1];

                }
                string TrueTabCreatorName = NewNewTabCreatorNamee;

                string TabIconName = Path.GetFileName(pictureBox1.ImageLocation);
                string TrueTabIconName = TabIconName;

                string tabdescription = textBox6.Text;
                string tabposition = comboBox2.Text;

                string tabcode0 = $"            Tab.createTab(\"Button Tab_{TrueTabCreatorName}\", \"Tab_{TrueTabCreatorName}\", \"{TrueTabCreatorName}\", \"{tabdescription}\", -150);\n" +
                "            loadButtons();\n";
                
                string tabcode1 = $"            PowersTab Tab = getPowersTab(\"{TrueTabCreatorName}\");\n" +
                " \n" +
                $"            #region {TrueTabCreatorName}Buttons\n" +
                " \n";
                string tabcode2 = " \n" +
                    "            #endregion\n";

                string tabcodee = "        public static void createTab(string buttonID, string tabID, string name, string desc, int xPos)\n" +
                                 "        {\n" +
                                 "           GameObject OtherTabButton = GameObjects.FindEvenInactive(\"Button_Other\");\n" +
                                 "            if (OtherTabButton != null)\n" +
                                 "            {\n" +
                                 "                Localization.AddOrSet(buttonID, name);\n" +
                                 "                Localization.AddOrSet($\"{buttonID} Description\", desc);\n" +
                                 $"                Localization.AddOrSet(\"{TrueTabCreatorName}_mod_creator\",  \"Made By: {TrueTabCreatorName}\");\n" +
                                 "                Localization.AddOrSet(tabID, name);\n" +
                                 " \n" +
                                 " \n" +
                                 "                GameObject newTabButton = GameObject.Instantiate(OtherTabButton);\n" +
                                 "                newTabButton.transform.SetParent(OtherTabButton.transform.parent);\n" +
                                 "                Button buttonComponent = newTabButton.GetComponent<Button>();\n" +
                                 "                TipButton tipButton = buttonComponent.gameObject.GetComponent<TipButton>();\n" +
                                 "                tipButton.textOnClick = buttonID;\n" +
                                 "                tipButton.textOnClickDescription = $\"{buttonID} Description\";\n" +
                                 $"                tipButton.text_description_2 = \"{TrueTabCreatorName}_mod_creator\";\n" +
                                 " \n" +
                                 " \n" +
                                 " \n" +
                                 $"                newTabButton.transform.localPosition = new Vector3({tabposition}f, 49.57f);\n" +
                                 "                newTabButton.transform.localScale = new Vector3(1f, 1f);\n" +
                                 "                newTabButton.name = buttonID;\n" +
                                 " \n" +
                                 $"                var spriteForTab = Resources.Load<Sprite>(\"ui/Icons/{TrueTabIconName}\");\n" +
                                 "                newTabButton.transform.Find(\"Icon\").GetComponent<Image>().sprite = spriteForTab;\n" +
                                 " \n" +
                                 " \n" +
                                 "                GameObject OtherTab = GameObjects.FindEvenInactive(\"Tab_Other\");\n" +
                                 "                foreach (Transform child in OtherTab.transform)\n" +
                                 "                {\n" +
                                 "                    child.gameObject.SetActive(false);\n" +
                                 "                }\n" +
                                 " " +
                                 "                GameObject additionalPowersTab = GameObject.Instantiate(OtherTab);\n" +
                                 " " +
                                 "                foreach (Transform child in additionalPowersTab.transform)\n" +
                                 "                {\n";
                                 string tabcodeee = "                    if (child.gameObject.name == \"tabBackButton\" || child.gameObject.name == \"-space\")\n" +
                                 "                    {\n" +
                                 "                        child.gameObject.SetActive(true);\n" +
                                 "                        continue;\n" +
                                 "                    }\n" +
                                 " \n" +
                                 "                    GameObject.Destroy(child.gameObject);\n" +
                                 "                }\n" +
                                 " \n" +
                                 "                foreach (Transform child in OtherTab.transform)\n" +
                                 "                {\n" +
                                 "                    child.gameObject.SetActive(true);\n" +
                                 "                }\n" +
                                 " \n" +
                                 " \n" +
                                 "                additionalPowersTab.transform.SetParent(OtherTab.transform.parent);\n" +
                                 "                PowersTab powersTabComponent = additionalPowersTab.GetComponent<PowersTab>();\n" +
                                 "                powersTabComponent.powerButton = buttonComponent;\n" +
                                 "                powersTabComponent.powerButtons.Clear();\n" +
                                 " \n" +
                                 " \n" +
                                 "                additionalPowersTab.name = tabID;\n" +
                                 "                powersTabComponent.powerButton.onClick = new Button.ButtonClickedEvent();\n" +
                                 "                powersTabComponent.powerButton.onClick.AddListener(() => tabOnClick(tabID));\n" +
                                 "                Reflection.SetField<GameObject>(powersTabComponent, \"parentObj\", OtherTab.transform.parent.parent.gameObject);\n" +
                                 " \n" +
                                 "                additionalPowersTab.SetActive(true);\n" +
                                 "                powersTabComponent.powerButton.gameObject.SetActive(true);\n" +
                                 "            }\n" +
                                 "        }\n" +
                                 " \n" +
                                 "        public static void tabOnClick(string tabID)\n" +
                                 "        {\n" +
                                 "            GameObject AdditionalTab = GameObjects.FindEvenInactive(tabID);\n" +
                                 "            PowersTab AdditionalPowersTab = AdditionalTab.GetComponent<PowersTab>();\n" +
                                 " \n" +
                                 "                    AdditionalPowersTab.showTab(AdditionalPowersTab.powerButton);\n" +
                                 "        }\n";

                Program.TabCreator.Add(TrueTabCreatorName);
                Program.TabDescription.Add(tabdescription);
                Program.TabCode0.Add(tabcode0);
                Program.TabCode1.Add(tabcode1);
                Program.TabCode2.Add(tabcode2);

                if (Program.TabCode.Contains(tabcodee))
                {
                    int count = 1;
                    string tempName = $"{tabcodee}{count}";

                    while (Program.TabCode.Contains(tempName))
                    {
                        count++;
                        tempName = $"{tabcodee}_{count}";
                    }

                    tabcodee = tempName;
                    Program.TabCode.Add(tabcodee);
                }
                else
                {
                    Program.TabCode.Add(tabcodee);
                }

                if (Program.TabCode.Contains(tabcodeee))
                {
                    int count = 1;
                    string tempName = $"{tabcodeee}{count}";

                    while (Program.TabCode.Contains(tempName))
                    {
                        count++;
                        tempName = $"{tabcodeee}_{count}";
                    }

                    tabcodeee = tempName;
                    Program.TabCode.Add(tabcodeee);
                }
                else
                {
                    Program.TabCode.Add(tabcodeee);
                }

                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";

                if (Directory.Exists(downloadsPath))
                {
                    string diretorioTabIconImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                    string newFolder = "TabIcon";
                    string newFolder2 = diretorioTabIconImagens + newFolder;
                    Directory.CreateDirectory(newFolder2);
                    string diretorioTabIcon = Path.Combine(newFolder2, TrueTabIconName + ".png");

                    string tabicondiretory = pictureBox1.ImageLocation;

                    File.Copy(tabicondiretory, diretorioTabIcon);

                    pictureBox1.Image = Image.FromFile(diretorioTabIcon);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("No Icon Selected.");
                        return;
                    }
                    else
                    {
                        string TabiconBase64;
                        string icotabnameeee = diretorioTabIcon;
                        Program.TabIconNameList.Add(icotabnameeee);
                        using (MemoryStream icontabiconsave = new MemoryStream())
                        {
                            pictureBox1.Image.Save(icontabiconsave, ImageFormat.Png);
                            TabiconBase64 = Convert.ToBase64String(icontabiconsave.ToArray());
                        }
                        Program.TabIcon.Add(TabiconBase64);
                    }
                }

                MessageBox.Show("The Tab Were Successfully Saved!");

                textBox1.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                groupBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }
        #endregion

        #region creatunitbutton
        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.TabCode.Count != 0)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && pictureBox2.Image != null && textBox7.Text != "")
                {
                    string NewButtonUnitName = textBox2.Text;
                    string[] NewButtonUnitNamee;
                    string NewNewButtonUnitNamee = NewButtonUnitName;
                    if (NewButtonUnitName.Contains(" "))
                    {
                        NewButtonUnitNamee = NewButtonUnitName.Split(' ');
                        NewNewButtonUnitNamee = NewButtonUnitNamee[0] + NewButtonUnitNamee[1];

                    }
                    string TrueButtonUnitName = NewNewButtonUnitNamee;

                    string unitbuttontitle = textBox3.Text;
                    string unitbuttondescription = textBox7.Text;
                    string unitbuttonchoosedunit = comboBox3.Text;
                    string unitbuttoniconname = Path.GetFileNameWithoutExtension(pictureBox2.ImageLocation);

                    int clicks = Program.ButtonPositionCounter;
                    clicks++;
                    if (clicks == 3 || clicks == 5)
                    {
                        Program.ButtonCounter += Program.ButtonIncrements[Program.ButtonIndex];
                        Program.ButtonIndex = (Program.ButtonIndex + 1) % Program.ButtonIncrements.Length;
                    }
                    else if (clicks == 6)
                    {
                        clicks = 2;
                    }
                    Program.ButtonPositionCounter = clicks;

                    int position1 = Program.ButtonCounter;

                    Program.Position2 = (Program.Position2 == "18") ? "-18" : "18";
                    string position2 = Program.Position2;

                    string unitbuttoncode = $"            var {TrueButtonUnitName}Button = new GodPower();\n" +
                    $"            {TrueButtonUnitName}Button.id = \"spawn{TrueButtonUnitName}Button\";\n" +
                    $"            {TrueButtonUnitName}Button.showSpawnEffect = true;\n" +
                    $"            {TrueButtonUnitName}Button.multiple_spawn_tip = true;\n" +
                    $"            {TrueButtonUnitName}Button.actorSpawnHeight = 3f;\n" +
                    $"            {TrueButtonUnitName}Button.name = \"spawn{TrueButtonUnitName}Button\";\n" +
                    $"            {TrueButtonUnitName}Button.spawnSound = \"spawnelf\";\n" +
                    $"            {TrueButtonUnitName}Button.actor_asset_id = \"{unitbuttonchoosedunit}\";\n" +
                    $"            {TrueButtonUnitName}Button.click_action = new PowerActionWithID(callSpawnUnit);\n" +
                    $"            AssetManager.powers.add({TrueButtonUnitName}Button);\n" +
                    " \n" +
                    $"            var button{TrueButtonUnitName}Button = NCMS.Utils.PowerButtons.CreateButton(\n" +
                    $"            \"spawn{TrueButtonUnitName}Button\",\n" +
                    $"            Mod.EmbededResources.LoadSprite($\"{{Mod.Info.Name}}.Resources.Units.{unitbuttoniconname}.png\"),\n" +
                    $"            \"{unitbuttontitle}\",\n" +
                    $"            \"{unitbuttondescription}\",\n" +
                    $"            new Vector2({position1}, {position2}),\n" +
                    "            ButtonType.GodPower,\n" +
                    $"            Tab.transform,\n" +
                    "             null\n" +
                    "             );\n" +
                    " \n";

                    if (Program.UnitButtonCode.Contains(unitbuttoncode))
                    {
                        int count = 1;
                        string tempName = $"{unitbuttoncode}{count}";

                        while (Program.UnitButtonCode.Contains(tempName))
                        {
                            count++;
                            tempName = $"{unitbuttoncode}_{count}";
                        }

                        unitbuttoncode = tempName;
                        Program.UnitButtonCode.Add(unitbuttoncode);
                    }
                    else
                    {
                        Program.UnitButtonCode.Add(unitbuttoncode);
                    }

                    string UnitButtonIconName = Path.GetFileName(pictureBox2.ImageLocation);
                    Program.UnitButtonIconNameList.Add(UnitButtonIconName);
                    string unitbuttoniconBase64;
                    using (MemoryStream unitbuttoniconsave = new MemoryStream())
                    {
                        pictureBox2.Image.Save(unitbuttoniconsave, ImageFormat.Png);
                        unitbuttoniconBase64 = Convert.ToBase64String(unitbuttoniconsave.ToArray());
                    }
                    Program.UnitButtonIcon.Add(unitbuttoniconBase64);

                    MessageBox.Show("The Unit Button Were Successfully Saved!");

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox7.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    pictureBox2.Image = null;

                }
                else
                {
                    MessageBox.Show("Fill in All Blanks First!");
                }
            }
            else
            {
                MessageBox.Show("Create a Tab First!");
            }
        }
        #endregion
    }
}