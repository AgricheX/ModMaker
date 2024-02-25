using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod_Maker
{
    public partial class ModMakerMain : Form
    {
        private Dictionary<PictureBox, string> pictureBoxesGifs = new Dictionary<PictureBox, string>();
        private Dictionary<PictureBox, string> pictureBoxesIcons = new Dictionary<PictureBox, string>();

        #region initializecomponent
        public ModMakerMain()
        {
            InitializeComponent();

            pictureBoxesGifs.Add(pictureBox4, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "achievements_theland.gif"));
            pictureBoxesGifs.Add(pictureBox5, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "achievements_theliving.gif"));
            pictureBoxesGifs.Add(pictureBox6, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "achievements_thesky_2.gif"));
            pictureBoxesGifs.Add(pictureBox7, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "achievements_themoon.gif"));
            pictureBoxesGifs.Add(pictureBox8, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "achievements_thesun.gif"));
            pictureBoxesGifs.Add(pictureBox9, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "bubbles_12.gif"));
            pictureBoxesGifs.Add(pictureBox10, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "bubbles_10.gif"));
            pictureBoxesGifs.Add(pictureBox11, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "GifsIcon", "bubbles_11.gif"));

            pictureBoxesIcons.Add(pictureBox4, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "achievements_theland.png"));
            pictureBoxesIcons.Add(pictureBox5, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "achievements_theliving.png"));
            pictureBoxesIcons.Add(pictureBox6, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "achievements_thesky.png"));
            pictureBoxesIcons.Add(pictureBox7, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "achievements_themoon.png"));
            pictureBoxesIcons.Add(pictureBox8, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "achievements_thesun.png"));
            pictureBoxesIcons.Add(pictureBox9, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "bubbles_12.png"));
            pictureBoxesIcons.Add(pictureBox10, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "bubbles_10.png"));
            pictureBoxesIcons.Add(pictureBox11, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Images", "StaticIcon", "bubbles_11.png"));

            foreach (var pictureBox in pictureBoxesGifs.Keys)
            {
                pictureBox.MouseEnter += pictureBox_MouseEnter;
            }

            foreach (var pictureBox in pictureBoxesIcons.Keys)
            {
                pictureBox.MouseLeave += pictureBox_MouseLeave;
            }
        }

        #endregion

        #region initialload
        private void ModMakerMain_Load(object sender, EventArgs e)
        {
            this.panel5.Visible = false; 
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            this.panel8.Visible = false;
            this.panel9.Visible = false;
            this.panel10.Visible = false;
            this.panel11.Visible = false;
            this.panel12.Visible = false;

            Program.CreateModMakerRecicleBin();
        }

        #endregion

        #region essentialbuttons
        private void button2_Click(object sender, EventArgs e)
        {
            modclear();
            Program.DeleteModMakerRecycleBin();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(panel2.Width));
            if (panel1.Width > 86)
            {
                panel1.Width = 86;
                int n1 = 78;
                int n2 = 42;
                pictureBox2.Size = new System.Drawing.Size(n1, n2);
            }
            else
            {
                panel1.Width = 230;
                int n1 = 125;
                int n2 = 47;
                pictureBox2.Size = new System.Drawing.Size(n1, n2);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://linktr.ee/agrichex");
        }

        #endregion

        #region utils

        private void modclear()
        {
            Program.ModsIcon.Clear();

            Program.TraitsName.Clear();
            Program.TraitsValue.Clear();
            Program.TraitsCode.Clear();
            Program.TraitsIcon.Clear();
            Program.TraitsIconNameList.Clear();

            Program.TraitGroupName.Clear();
            Program.TraitGroupCode.Clear();
            Program.TraitGroupValues.Clear();
            Program.TraitGroupTypesFile.Clear();

            Program.WeaponIcon.Clear();
            Program.WeaponIconNameList.Clear();
            Program.WeaponSprite.Clear();
            Program.WeaponSpriteNameList.Clear();
            Program.WeaponCode.Clear();
            Program.WeaponCode2.Clear();

            Program.ItemIcon.Clear();
            Program.ItemIconNameList.Clear();
            Program.Itemcode.Clear();
            Program.Itemcode2.Clear();

            Program.InvasionsCode.Clear();
            Program.InvasionsIcon.Clear();
            Program.InvasionsIconNameList.Clear();
            Program.InvasionsName.Clear();

            Program.TabCode.Clear();
            Program.TabCode0.Clear();
            Program.TabCode1.Clear();
            Program.TabCode2.Clear();
            Program.TabCreator.Clear();
            Program.TabIconNameList.Clear();
            Program.TabIcon.Clear();
            Program.TabDescription.Clear();

            Program.ButtonCounter = 72;
            Program.ButtonIndex = 0;
            Program.Position2 = "-18";
            Program.ButtonPositionCounter = 0;

            Program.UnitButtonCode.Clear();
            Program.UnitButtonIconNameList.Clear();
            Program.UnitButtonIcon.Clear();

            Program.KingdomTagCode.Clear();
            Program.KingdomTagName.Clear();
            Program.KingdomTagTrueName.Clear();

            Program.SwimSprite.Clear();
            Program.SwimNameList.Clear();
            Program.SwimName.Clear();
            Program.WalkSprite.Clear();
            Program.WalkNameList.Clear();
            Program.WalkName.Clear();
            Program.UnitIcon.Clear();
            Program.UnitIconNameList.Clear();
            Program.UnitCode0.Clear();
            Program.UnitCode1.Clear();
            Program.UnitName.Clear();

            Program.ProjectileCode.Clear();
            Program.ProjectileIcon.Clear();
            Program.ProjectileIconNameList.Clear();
            Program.ProjectileName.Clear();
        }
        private void Panel3Show()
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(label10);
            this.panel3.Controls.Add(label11);
            this.panel3.Controls.Add(label12);
            this.panel3.Controls.Add(textBox1);
            this.panel3.Controls.Add(textBox2);
            this.panel3.Controls.Add(comboBox1);
            this.panel3.Controls.Add(button1);
            this.panel3.Controls.Add(button3);
            this.panel3.Controls.Add(button4);
            this.panel3.Controls.Add(panel4);
            this.panel4.Controls.Add(pictureBox12);
            this.panel3.Controls.Add(panel5);
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            this.panel8.Visible = false;
            this.panel9.Visible = false;
            this.panel10.Visible = false;
            this.panel11.Visible = false;
            this.panel12.Visible = false;
        }

        private void DockSet(bool Set)
        {
            if (Set)
            {
                this.panel5.Dock = DockStyle.None;
                this.panel6.Dock = DockStyle.None;
                this.panel7.Dock = DockStyle.None;
                this.panel8.Dock = DockStyle.None;
                this.panel9.Dock = DockStyle.None;
                this.panel10.Dock = DockStyle.None;
                this.panel11.Dock = DockStyle.None;
                this.panel12.Dock = DockStyle.None;
            }
            else
            {

            }
        }

        private void IconMod(string IconFolder)
        {
            string directoryTraitsImages = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "IconsMods", $"{IconFolder}");
            pictureBox12.ImageLocation = Path.Combine(directoryTraitsImages, "icon" + ".png");
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;

            string iconmodnamefilter = comboBox1.Text;
            string[] separator = iconmodnamefilter.Split('\\');
            string[] iconmodnamefilter2 = separator[separator.Length - 1].Split('.');
            comboBox1.Text = iconmodnamefilter2[0];
        }

        #endregion

        #region picturesbuttons
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 86)
            {
                DockSet(true);
                Panel3Show();
            }
            else if (panel1.Width > 86)
            {
                panel1.Width = 86;
                int n1 = 78;
                int n2 = 42;
                pictureBox2.Size = new System.Drawing.Size(n1, n2);
                DockSet(true);
                Panel3Show();
            }
            else if (panel1.Width < 86)
            {
                panel1.Width = 86;
                int n1 = 78;
                int n2 = 42;
                pictureBox2.Size = new System.Drawing.Size(n1, n2);
                DockSet(true);
                Panel3Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel5);
            this.panel5.Dock = DockStyle.Fill;
            this.panel5.Visible = true;
            UmTraits umtraits = new UmTraits()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(umtraits);
            umtraits.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel6);
            this.panel6.Dock = DockStyle.Fill;
            this.panel6.Visible = true;
            UmEquipments umequipments = new UmEquipments()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel6.Controls.Add(umequipments);
            umequipments.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel7);
            this.panel7.Dock = DockStyle.Fill;
            this.panel7.Visible = true;
            UmActions umactions = new UmActions()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel7.Controls.Add(umactions);
            umactions.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel8);
            this.panel8.Dock = DockStyle.Fill;
            this.panel8.Visible = true;
            UmUnits umunits = new UmUnits()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel8.Controls.Add(umunits);
            umunits.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel9);
            this.panel9.Dock = DockStyle.Fill;
            this.panel9.Visible = true;
            UmDiverse umdiverse = new UmDiverse()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel9.Controls.Add(umdiverse);
            umdiverse.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel10);
            this.panel10.Dock = DockStyle.Fill;
            this.panel10.Visible = true;
            UmTab umtab = new UmTab()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel10.Controls.Add(umtab);
            umtab.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel11);
            this.panel11.Dock = DockStyle.Fill;
            this.panel11.Visible = true;
            UmModMain ummodmain = new UmModMain()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel11.Controls.Add(ummodmain);
            ummodmain.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(panel12);
            this.panel12.Dock = DockStyle.Fill;
            this.panel12.Visible = true;
            Credits credits = new Credits()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel12.Controls.Add(credits);
            credits.Show();
        }

        #endregion

        #region createmod
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && Program.ModsIcon.Count != 0)
            {
                //
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
                string newFolder = textBox1.Text;
                string newFolder2 = downloadsPath + newFolder;
                string newFolder3 = newFolder2;

                if (!Directory.Exists(newFolder2))
                {
                    Directory.CreateDirectory(newFolder2);
                }
                else
                {
                    MessageBox.Show("Mod Folder Already Exists");
                }

                //

                for (int i = 0; i < Program.ModsIcon.Count; i++)
                {
                    string icontraitraitBase64 = Program.ModsIcon[i];
                    string iconmodnamee = "icon.png";
                    byte[] imagemBytesTrait = Convert.FromBase64String(icontraitraitBase64);

                    string iconModFilePath = Path.Combine(newFolder3, iconmodnamee);
                    File.WriteAllBytes(iconModFilePath, imagemBytesTrait);
                }

                //

                //

                string modname1 = textBox1.Text;
                string[] modname2;
                string newmodname = modname1;
                if (modname1.Contains(" "))
                {
                    modname2 = modname1.Split(' ');
                    newmodname = modname2[0] + modname2[1];

                }
                else
                {

                }

                string jsonFileName = "mod.json";
                string jsonFileee = Path.Combine(newFolder3, jsonFileName);

                using (StreamWriter jsonw = File.CreateText(jsonFileee))
                {
                    string json0 = textBox1.Text;
                    string json05 = textBox2.Text;
                    string json1 = "{\n" +
                    "  \"name\": " + $"\"{newmodname}\"" + ",\n" +
                    "  \"author\": \"ModMaker\",\n" +
                    "  \"version\": \"0.0.1\",\n" +
                    "  \"startPoint\": \"Main.cs\",\n" +
                    "  \"description\": " + $"\"{json05}\"" + ",\n" +
                    "  \"iconPath\": \"icon.png\",\n" +
                    "  \"targetGameBuild\": 558\n" +
                    "}";
                    string json2 = json1;

                    jsonw.WriteLine(json2);
                }

                //

                string AssembliesFolder = "Assemblies";
                string creationAssemblies = Path.Combine(newFolder2, AssembliesFolder);

                if (!Directory.Exists(creationAssemblies))
                {
                    Directory.CreateDirectory(creationAssemblies);
                }

                string assembliesdll = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Assemblys", "0.22.9", "Assembly-CSharp.dll");
                string Filedestination = Path.Combine(creationAssemblies, "Assembly-CSharp.dll");
                File.Copy(assembliesdll, Filedestination);

                //

                string CodeFolder = "Code";
                string creationCode = Path.Combine(newFolder2, CodeFolder);

                if (!Directory.Exists(creationCode))
                {
                    Directory.CreateDirectory(creationCode);
                }

                //

                string Main = Path.Combine(creationCode, "Main.cs");
                if (!File.Exists(Main))
                {
                    using (StreamWriter mainw = File.CreateText(Main))
                    {
                        string main1 = "using System;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using ReflectionUtility;\n" +
                        "using HarmonyLib;\n" +
                        "using System.Collections;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Threading;\n" +
                        "using life;\n" +
                        "using System.Linq;\n" +
                        "using System.Text;\n" +
                        "using System.Threading.Tasks;\n" +
                        "using static Config;\n" +
                        "using System.Reflection;\n" +
                        "using UnityEngine.Tilemaps;\n" +
                        "using System.IO;\n";

                        string main2 = " \n" + "namespace " + newmodname + "{\n" +
                        "    [ModEntry]\n" +
                        "    class Main : MonoBehaviour{\n" +
                        "        #region\n" +
                        "        public static Main instance;\n" +
                        "        #endregion\n" +
                        "        internal static Harmony harmony;\n" +
                        "        void Awake(){\n" +
                        "         Debug.Log($\"{Mod.Info.Name} loaded!\");\n" +
                        "         Debug.Log(\"Mod Made by ModMaker\");\n";

                        string main3 = "         TraitGroup.init();\n" +
                        "         Traits.init();\n" +
                        "         Items.init();\n" +
                        "         Units.init();\n" +
                        "         Invasions.init();\n" +
                        "         Tab.init();\n" +
                        "         Buttons.init();\n" +
                        "        }\n" +
                        "    }\n" +
                        "}";

                        string main4 = main1 + main2 + main3;

                        mainw.WriteLine(main4);
                    }
                }
                else
                {
                    MessageBox.Show("Main file already exists!");
                }

                //

                string traitFile = Path.Combine(creationCode, "Traits.cs");

                if (!File.Exists(traitFile))
                {
                    using (StreamWriter traitw = File.CreateText(traitFile))
                    {

                        string trait1 = "using System;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using ReflectionUtility;\n" +
                        "using HarmonyLib;\n" +
                        "using System.Collections;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Threading;\n" +
                        "using life;\n" +
                        "using System.Linq;\n" +
                        "using System.Text;\n" +
                        "using System.Threading.Tasks;\n" +
                        "using static Config;\n" +
                        "using System.Reflection;\n" +
                        "using UnityEngine.Tilemaps;\n" +
                        "using System.IO;\n";

                        string trait2 = " \n" +
                        "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Traits\n" +
                        "    {\n" +
                        "        //Traits\n" +
                        "        public static void init()\n" +
                        "        { \n" +
                        "        //Generated by ModMaker\n";

                        string truetrait = string.Join(" ", Program.TraitsCode);

                        string traitactions = string.Join(" ", Program.ActionBank);

                        string traitactions1 = " \n" +
                        "        }\n" +
                        "        public static bool NoneAttackSomeoneAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneRegularAction(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneGetAttackedAction(BaseSimObject pSelf, BaseSimObject pAttackedBy = null, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneDeathAction(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        "        \n";

                        string trait3 = " \n" +
                        "        }\n" +
                        "        public static void addTraitToLocalizedLibrary(string id, string description)\n" +
                        "        {\n" +
                        "        string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, \"language\") as string;\n" +
                        "        Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, \"localizedText\") as Dictionary<string, string>;\n" +
                        "        localizedText.Add(\"trait_\" + id, id);\n" +
                        "        localizedText.Add(\"trait_\" + id + \"_info\", description);\n" +
                        "        }\n" +
                        "    }\n" +
                        "}";

                        string trait4 = trait1 + trait2 + truetrait + traitactions + traitactions1 + trait3;

                        traitw.WriteLine(trait4);
                    }
                }
                else
                {
                    MessageBox.Show("Trait file already exists!");
                }

                //

                string traitGroupFile = Path.Combine(creationCode, "TraitsGroups.cs");

                if (!File.Exists(traitGroupFile))
                {
                    using (StreamWriter traitgroupw = File.CreateText(traitGroupFile))
                    {
                        string traitgroup1 = "using System;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Linq;\n" +
                        "using System.Text;\n" +
                        "using System.Threading.Tasks;\n" +
                        "using ReflectionUtility;\n";

                        string traitgroup2 = " \n" + "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class TraitGroup\n" +
                        "    {\n" +
                        " \n";

                        string truetraitgrouptypefile = string.Join(" ", Program.TraitGroupTypesFile);

                        string traitgroup2emeio = " \n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        "        //Generated by ModMaker\n";

                        string truetraitgroup = string.Join(" ", Program.TraitGroupCode);

                        string traitgroup4 = " \n" +
                        "        }\n" +
                        "        private static void addTraitGroupToLocalizedLibrary(string id, string name)\n" +
                        "        {\n" +
                        "            string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, \"language\") as string;\n" +
                        "            Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, \"localizedText\") as Dictionary<string, string>;\n" +
                        "            localizedText.Add(\"trait_group_\" + id, name);\n" +
                        "        }\n" +
                        "    }\n" +
                        "}";

                        string traitgroup5 = traitgroup1 + traitgroup2 + truetraitgrouptypefile + traitgroup2emeio + truetraitgroup + traitgroup4;

                        traitgroupw.WriteLine(traitgroup5);
                    }
                }
                else
                {
                    MessageBox.Show("TraitGroup file already exists!");
                }

                //


                //

                string itemsFile = Path.Combine(creationCode, "Items.cs");

                if (!File.Exists(itemsFile))
                {
                    using (StreamWriter itemw = File.CreateText(itemsFile))
                    {
                        string items1 = "using System;\n" +
                        "using NCMS;\n" +
                        "using UnityEngine;\n" +
                        "using ReflectionUtility;\n" +
                        "using System.Text;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Linq;\n" +
                        "using System.Text;\n" +
                        "using HarmonyLib;\n" +
                        "using NCMS.Utils;\n" +
                        " \n";

                        string items2 = "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Items\n" +
                        "    {\n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        " \n" +
                        "          craftitems();\n" +
                        "          //Generated by ModMaker\n";

                        string weaponcodes1 = string.Join(" ", Program.WeaponCode);

                        string itemscode1 = string.Join(" ", Program.Itemcode);

                        string items3 = " \n" +
                        "          static void craftitems() {\n" +
                        " \n" +
                        "          Race human = AssetManager.raceLibrary.get(\"human\");\n" +
                        "          Race orc = AssetManager.raceLibrary.get(\"orc\");\n" +
                        "          Race dwarf = AssetManager.raceLibrary.get(\"dwarf\");\n" +
                        "          Race elf = AssetManager.raceLibrary.get(\"elf\");\n" +
                        " \n";

                        string weaponcodes2 = string.Join(" ", Program.WeaponCode2);

                        string itemscode2 = string.Join(" ", Program.Itemcode2);

                        string projectiles = string.Join(" ", Program.ProjectileCode);

                        string weaponactionss = "         }\n";

                        string weaponactions = string.Join(" ", Program.ActionBank2);

                        string weaponactions1 = " \n" +
                        "        }\n" +
                        "        public static bool NoneAttackSomeoneAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneRegularAction(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneGetAttackedAction(BaseSimObject pSelf, BaseSimObject pAttackedBy = null, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        " \n" +
                        "        }\n" +
                        "        public static bool NoneDeathAction(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                        "        {\n" +
                        " \n" +
                        "             return false;\n" +
                        "        \n";

                        string items4 = " \n" +
                        "            }\n" +
                        "            static void addWeaponsSprite(string id, string material)\n" +
                        "            {\n" +
                        "              var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, \"dictItems\") as Dictionary<string, Sprite>;\n" +
                        "              var sprite = Resources.Load<Sprite>(\"Weapons/w_\"" + " + id +" + " \"_\" " + "+ " + "material);\n" +
                        "              dictItems.Add(sprite.name, sprite);\n" +
                        "            }\n" +
                        "        }\n" +
                        "    }";

                        string items5 = items1 + items2 + weaponcodes1 + itemscode1 + items3 + weaponcodes2 + itemscode2 + projectiles + weaponactionss + weaponactions + weaponactions1 + items4;

                        itemw.WriteLine(items5);
                    }
                }
                else
                {
                    MessageBox.Show("Items file already exists!");
                }

                //

                //

                string invasionsFile = Path.Combine(creationCode, "Invasions.cs");

                if (!File.Exists(invasionsFile))
                {
                    using (StreamWriter invasionsw = File.CreateText(invasionsFile))
                    {
                        string invasion1 = "using System;\n" +
                        "using System;\n" +
                        "using System.IO;\n" +
                        "using System.Linq;\n" +
                        "using System.Collections.Generic;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using ReflectionUtility;\n" +
                        "using HarmonyLib;\n" +
                        "using System.Reflection;\n" +
                        " \n";

                        string invasion2 = "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Invasions\n" +
                        "    {\n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        " \n" +
                        "          //Generated by ModMaker\n" +
                        " \n";

                        string invasioncode = string.Join(" ", Program.InvasionsCode);

                        string invasion3 = " \n" +
                        "        }\n" +
                        "    }\n" +
                        "}";
                        string invasion4 = invasion1 + invasion2 + invasioncode + invasion3;

                        invasionsw.WriteLine(invasion4);
                    }
                }
                else
                {
                    MessageBox.Show("Invasions file already exists!");
                }

                //

                //

                string tabFile = Path.Combine(creationCode, "Tab.cs");

                if (!File.Exists(tabFile))
                {
                    using (StreamWriter tabsw = File.CreateText(tabFile))
                    {
                        string tab1 = "using System;\n" +
                        "using System.Text;\n" +
                        "using System.Threading.Tasks;\n" +
                        "using System.Collections;\n" +
                        "using System.Collections.Generic;\n" +
                        "using System.Linq;\n" +
                        "using System.Reflection;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using UnityEngine.Events;\n" +
                        "using UnityEngine.EventSystems;\n" +
                        "using UnityEngine.UI;\n" +
                        "using ReflectionUtility;\n" +
                        " \n";

                        string tab2 = "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Tab\n" +
                        "    {\n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        " \n" +
                        "          //Generated by ModMaker\n" +
                        " \n" +
                        "    }\n";

                        string tabcode = string.Join(" ", Program.TabCode);

                        string tab3 = "    }\n" +
                                 "}\n";

                        string tab4 = tab1 + tab2 + tabcode + tab3;

                        tabsw.WriteLine(tab4);
                    }
                }
                else
                {
                    MessageBox.Show("Tab file already exists!");
                }

                //

                //
                string unitsFile = Path.Combine(creationCode, "Units.cs");

                if (!File.Exists(unitsFile))
                {
                    using (StreamWriter unitssw = File.CreateText(unitsFile))
                    {
                        string units1 = "using System;\n" +
                        "using System.IO;\n" +
                        "using System.Linq;\n" +
                        "using System.Collections.Generic;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using ReflectionUtility;\n" +
                        "using HarmonyLib;\n" +
                        "using System.Reflection;\n" +
                        " \n";

                        string units2 = "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Units\n" +
                        "    {\n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        "          //Generated by ModMaker\n" +
                        " \n";

                        string kingdomtagcode = string.Join(" ", Program.KingdomTagCode);

                        string space = " \n";

                        string unitscode0 = string.Join(" ", Program.UnitCode0);

                        string units3 = "        }\n" +
                        " \n";

                        string unitscode1 = string.Join(" ", Program.UnitCode1);

                        string units4 = " \n" +
                        "    }\n" +
                        "}";
                        string units5 = units1 + units2 + kingdomtagcode + space + unitscode0 + space + units3 + unitscode1 + units4;

                        unitssw.WriteLine(units5);
                    }
                }
                else
                {
                    MessageBox.Show("Units file already exists!");
                }
                //

                //
                string buttonFile = Path.Combine(creationCode, "Buttons.cs");

                if (!File.Exists(buttonFile))
                {
                    using (StreamWriter buttonsw = File.CreateText(buttonFile))
                    {
                        string button1 = "using System;\n" +
                        "using System.IO;\n" +
                        "using System.Linq;\n" +
                        "using System.Collections;\n" +
                        "using System.Collections.Generic;\n" +
                        "using NCMS;\n" +
                        "using NCMS.Utils;\n" +
                        "using UnityEngine;\n" +
                        "using UnityEngine.Events;\n" +
                        "using UnityEngine.EventSystems;\n" +
                        "using UnityEngine.UI;\n" +
                        "using ReflectionUtility;\n" +
                        "using System.Reflection;\n" +
                        "using HarmonyLib;\n" +
                        "using Newtonsoft.Json;\n" +
                        "using static Config;\n" +
                        " \n";

                        string button2 = "namespace " + $"{newmodname}\n" +
                        "{\n" +
                        "    class Buttons\n" +
                        "    {\n" +
                        "        public static void init()\n" +
                        "        {\n" +
                        "          //Generated by ModMaker\n";

                        string tabcode0 = string.Join(" ", Program.TabCode0);

                        string button3 = " \n" +
                        "        }\n" +
                        "        private static void loadButtons()\n" +
                        "        {\n";

                        string tabcode1 = string.Join(" ", Program.TabCode1);

                        string unitbuttoncode = string.Join(" ", Program.UnitButtonCode);

                        string tabcode2 = string.Join(" ", Program.TabCode2);

                        string button4 = " \n" +
                        "		}\n" +
                        "		public static bool callSpawnUnit(WorldTile pTile, string pPowerID)\n" +
                        "		{\n" +
                        "            AssetManager.powers.CallMethod(\"spawnUnit\", pTile, pPowerID);\n" +
                        "            return true;\n" +
                        "		}\n" +
                        "		private static PowersTab getPowersTab(string id)\n" +
                        "		{\n" +
                        "            GameObject gameObject = GameObjects.FindEvenInactive(\"Tab_\" + id);\n" +
                        "            return gameObject.GetComponent<PowersTab>();\n" +
                        "		}\n" +
                        "    }\n" +
                        "}\n";

                        string button5 = button1 + button2 + tabcode0 + button3 + tabcode1 + unitbuttoncode + tabcode2 + button4;

                        buttonsw.WriteLine(button5);
                    }
                }
                else
                {
                    MessageBox.Show("Buttons file already exists!");
                }
                //

                //

                string gameresourcesfolder = "GameResources";

                string creationGameResource = Path.Combine(newFolder2, gameresourcesfolder);

                if (!Directory.Exists(creationGameResource))
                {
                    Directory.CreateDirectory(creationGameResource);
                }
                else
                {
                    MessageBox.Show("GameResources folder already exists!");
                }

                //

                //
                string embededresourcesfolder = "EmbededResources";

                string creationEmbededResources = Path.Combine(newFolder2, embededresourcesfolder);

                if (!Directory.Exists(creationEmbededResources))
                {
                    Directory.CreateDirectory(creationEmbededResources);
                }
                else
                {
                    MessageBox.Show("EmbededResources folder already exists!");
                }

                string unitsfolder = "Units";

                string creationUnits = Path.Combine(creationEmbededResources, unitsfolder);

                if (!Directory.Exists(creationUnits))
                {
                    Directory.CreateDirectory(creationUnits);
                }
                else
                {
                    MessageBox.Show("Units folder already exists!");
                }

                if (Program.UnitButtonIcon != null && Program.UnitButtonIcon.Count > 0)
                {
                    for (int i = 0; i < Program.UnitButtonIcon.Count; i++)
                    {
                        string iconunitunitbuttonBase64 = Program.UnitButtonIcon[i];
                        byte[] imagemBytesUnitButton = Convert.FromBase64String(iconunitunitbuttonBase64);

                        string iconUnitButtonFilePath = Path.Combine(creationUnits, Path.GetFileName(Program.UnitButtonIconNameList[i]));
                        File.WriteAllBytes(iconUnitButtonFilePath, imagemBytesUnitButton);
                    }
                }
                //

                //

                string uifolder = "ui";

                string creationUiFolder = Path.Combine(creationGameResource, uifolder);

                if (!Directory.Exists(creationUiFolder))
                {
                    Directory.CreateDirectory(creationUiFolder);

                }
                else
                {

                }

                //

                //

                string Iconsfolder = "Icons";

                string creationIconsFolder = Path.Combine(creationUiFolder, Iconsfolder);

                if (!Directory.Exists(creationIconsFolder))
                {
                    Directory.CreateDirectory(creationIconsFolder);

                }
                else
                {

                }

                //

                //

                if (Program.TraitsIcon != null && Program.TraitsIcon.Count > 0)
                {
                    for (int i = 0; i < Program.TraitsIcon.Count; i++)
                    {
                        string icontraitraitBase64 = Program.TraitsIcon[i];
                        byte[] imagemBytesTrait = Convert.FromBase64String(icontraitraitBase64);

                        string iconTraitFilePath = Path.Combine(creationIconsFolder, Path.GetFileName(Program.TraitsIconNameList[i]));
                        File.WriteAllBytes(iconTraitFilePath, imagemBytesTrait);
                    }
                }

                if (Program.InvasionsIcon != null && Program.InvasionsIcon.Count > 0)
                {
                    for (int i = 0; i < Program.InvasionsIcon.Count; i++)
                    {
                        string iconinvasioninvasionBase64 = Program.InvasionsIcon[i];
                        byte[] imagemBytesInvasion = Convert.FromBase64String(iconinvasioninvasionBase64);

                        string iconInvasionFilePath = Path.Combine(creationIconsFolder, Path.GetFileName(Program.InvasionsIconNameList[i]));
                        File.WriteAllBytes(iconInvasionFilePath, imagemBytesInvasion);
                    }
                }

                if (Program.TabIcon != null && Program.TabIcon.Count > 0)
                {
                    for (int i = 0; i < Program.TabIcon.Count; i++)
                    {
                        string icontabtabBase64 = Program.TabIcon[i];
                        byte[] imagemBytesTab = Convert.FromBase64String(icontabtabBase64);

                        string iconTabFilePath = Path.Combine(creationIconsFolder, Path.GetFileName(Program.TabIconNameList[i]));
                        File.WriteAllBytes(iconTabFilePath, imagemBytesTab);
                    }
                }

                if (Program.UnitIcon != null && Program.UnitIcon.Count > 0)
                {
                    for (int i = 0; i < Program.UnitIcon.Count; i++)
                    {
                        string iconunitunitBase64 = Program.UnitIcon[i];
                        byte[] imagemBytesUnit = Convert.FromBase64String(iconunitunitBase64);

                        string iconUnitFilePath = Path.Combine(creationIconsFolder, Path.GetFileName(Program.UnitIconNameList[i]));
                        File.WriteAllBytes(iconUnitFilePath, imagemBytesUnit);
                    }
                }

                //

                //

                string directoryDownloadss = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin";
                string modmakeractorfolder = Path.Combine(directoryDownloadss, "actors");
                string actorfolder = Path.Combine(directoryDownloadss, newFolder, creationGameResource, "actors");
                string modmakereffectsfolderr = Path.Combine(directoryDownloadss, "effects");
                string effectsfolder = Path.Combine(directoryDownloadss, newFolder, creationGameResource, "effects");
                Directory.Move(modmakeractorfolder, actorfolder);
                Directory.Move(modmakereffectsfolderr, effectsfolder);

                //

                //

                //acharaqui

                //

                //

                string gameresourcesfolderreplace = "GameResourcesReplace";

                string creationGameResourcesReplace = Path.Combine(newFolder2, gameresourcesfolderreplace);

                if (!Directory.Exists(creationGameResourcesReplace))
                {
                    Directory.CreateDirectory(creationGameResourcesReplace);
                }
                else
                {
                    MessageBox.Show("GameResourcesReplace folder already exists!");
                }

                //


                //

                string uifolder2 = "ui";

                string creationUiFolder2 = Path.Combine(creationGameResourcesReplace, uifolder2);

                if (!Directory.Exists(creationUiFolder2))
                {
                    Directory.CreateDirectory(creationUiFolder2);

                }
                else
                {
                    MessageBox.Show("Ui folder already exists!");
                }

                //

                //

                string Iconsfolder2 = "Icons";

                string creationIconsFolder2 = Path.Combine(creationUiFolder2, Iconsfolder2);

                if (!Directory.Exists(creationIconsFolder2))
                {
                    Directory.CreateDirectory(creationIconsFolder2);

                }
                else
                {
                    MessageBox.Show("Icons folder already exists!");
                }

                //

                //

                string itemsfolder2 = "items";

                string creationitemsFolder2 = Path.Combine(creationIconsFolder2, itemsfolder2);

                if (!Directory.Exists(creationitemsFolder2))
                {
                    Directory.CreateDirectory(creationitemsFolder2);

                }
                else
                {
                    MessageBox.Show("Items folder already exists!");
                }

                //

                //

                for (int i = 0; i < Program.WeaponIcon.Count; i++)
                {
                    string iconweaponBase64 = Program.WeaponIcon[i];
                    byte[] imagemBytesWeaponIcon = Convert.FromBase64String(iconweaponBase64);

                    string iconWeaponFilePath = Path.Combine(creationitemsFolder2, Path.GetFileName(Program.WeaponIconNameList[i]));
                    File.WriteAllBytes(iconWeaponFilePath, imagemBytesWeaponIcon);
                }

                for (int i = 0; i < Program.ItemIcon.Count; i++)
                {
                    string iconitemsBase64 = Program.ItemIcon[i];
                    byte[] imagemBytesItemsIcon = Convert.FromBase64String(iconitemsBase64);

                    string iconitemsFilePath = Path.Combine(creationitemsFolder2, Path.GetFileName(Program.ItemIconNameList[i]));
                    File.WriteAllBytes(iconitemsFilePath, imagemBytesItemsIcon);
                }

                //

                //

                string Weaponsfolder = "Weapons";

                string creationWeaponsFolder = Path.Combine(creationGameResource, Weaponsfolder);

                if (!Directory.Exists(creationWeaponsFolder))
                {
                    Directory.CreateDirectory(creationWeaponsFolder);

                }
                else
                {
                    MessageBox.Show("Weapons folder already exists!");
                }

                //

                //

                for (int i = 0; i < Program.WeaponSprite.Count; i++)
                {
                    string spriteweaponBase64 = Program.WeaponSprite[i];
                    byte[] imagemBytesSpriteWeapon = Convert.FromBase64String(spriteweaponBase64);

                    string spriteWeaponFilePath = Path.Combine(creationWeaponsFolder, Path.GetFileName(Program.WeaponSpriteNameList[i]));
                    File.WriteAllBytes(spriteWeaponFilePath, imagemBytesSpriteWeapon);
                }

                //

                //

                string jsonFileName2 = "sprites.json";
                string jsonFileee2 = Path.Combine(creationWeaponsFolder, jsonFileName2);

                using (StreamWriter jsonw2 = File.CreateText(jsonFileee2))
                {
                    string json3 = "{\n" +
                    "    \"Default\": {\n" +
                    "    \"PivotX\": 0.5,\n" +
                    "    \"PivotY\": 0.2,\n" +
                    "    \"RectX\": 0,\n" +
                    "    \"RectY\": 0,\n" +
                    "    \"PixelsPerUnit\": 1\n" +
                    "  }\n" +
                    "}";
                    string json4 = json3;

                    jsonw2.WriteLine(json4);
                }

                //

                //string pastaTemporaria = Path.Combine(downloadsPath, "Delete This");
                //Directory.Delete(pastaTemporaria, true);
                //File.Delete(diretorioWeaponsIcon);
                //File.Delete(diretorioWeaponsSprite);

                //

                MessageBox.Show("Your Mod Has Been Created Successfully!");

                modclear();

                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;
                pictureBox12.Image = null;

                Program.DeleteModMakerRecycleBin();

                Program.CreateModMakerRecicleBin();

                string folderDownloads = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                if (Directory.Exists(folderDownloads))
                {
                    Process.Start("explorer.exe", folderDownloads);
                }
                else
                {
                    MessageBox.Show("The Downloads folder was not found on your system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Write a Name, Description And choose an Icon For The Mod First!");
            }
        }

        

        #endregion

        #region others
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Mod Icon | The name of the selected image should be \"icon\"";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox12.Image = Image.FromFile(pathImage);
                    pictureBox12.ImageLocation = openFileDialog.FileName;
                    pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox1.Text = fileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Image == null)
            {
                MessageBox.Show("No Icon Selected.");
                return;
            }
            else
            {
                string iconmodBase64;
                using (MemoryStream iconmodsave = new MemoryStream())
                {
                    pictureBox12.Image.Save(iconmodsave, ImageFormat.Png);
                    iconmodBase64 = Convert.ToBase64String(iconmodsave.ToArray());
                }

                Program.ModsIcon.Add(iconmodBase64);
                MessageBox.Show("Mod Icon Created Successfully!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Icon = comboBox1.Text;

            if (!string.IsNullOrEmpty(Icon))
            {
                IconMod(Icon);
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            foreach (var pictureBox in pictureBoxesGifs.Keys)
            {
                if (pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)))
                {
                    pictureBox.Image = new System.Drawing.Bitmap(pictureBoxesGifs[pictureBox]);
                }
            }
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBoxesIcons.ContainsKey(pictureBox))
            {
                pictureBox.Image = new System.Drawing.Bitmap(pictureBoxesIcons[pictureBox]);
            }
        }
        #endregion
    }
}