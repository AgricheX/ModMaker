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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Mod_Maker
{
    public partial class UmEquipments : Form
    {
        #region InitializeComponent
        public UmEquipments()
        {
            InitializeComponent();
        }

        private void UmEquipments_Load(object sender, EventArgs e)
        {
            comboBox7.MouseClick += comboBox7_MouseClick;
            comboBox6.MouseClick += comboBox6_MouseClick;
            comboBox4.MouseClick += comboBox4_MouseClick;
        }

        #endregion

        #region createweapon
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && comboBox1.Text != "" && comboBox8.Text != "" && (radioButton3.Checked || radioButton4.Checked))
                {
                    string weaponname = textBox1.Text;
                    string weaponmaterial = comboBox2.Text;

                    string[] weaponnamee;
                    string newweaponnamee = weaponname;
                    if (weaponname.Contains(" "))
                    {
                        weaponnamee = weaponname.Split(' ');
                        newweaponnamee = weaponnamee[0] + weaponnamee[1];
                    }
                    string trueweaponname = newweaponnamee;

                    string weapontitle = textBox2.Text;
                    string weaponvalueequipament = textBox3.Text;
                    string weaponhealth = textBox4.Text;
                    string weaponmaxage = textBox5.Text;
                    string weapondamage = textBox6.Text;
                    string weaponspeed = textBox7.Text;
                    string weaponarmor = textBox8.Text;
                    string weaponattackspeed = textBox9.Text;
                    string weapondodge = textBox10.Text;
                    string weaponaccuracy = textBox11.Text;
                    string weaponrange = textBox12.Text;
                    string weapontarget = textBox13.Text;
                    string weaponscale = textBox14.Text;
                    string weaponmaxcities = textBox15.Text;

                    string weaponfertility = textBox16.Text;
                    string weaponmaxchildren = textBox17.Text;
                    string weaponcriticalchance = textBox18.Text;
                    string weaponknowback = textBox19.Text;
                    string weaponknowbackreduction = textBox20.Text;
                    string weaponinteligence = textBox21.Text;
                    string weaponwarfare = textBox22.Text;
                    string weapondiplomacy = textBox23.Text;
                    string weaponstewardship = textBox24.Text;
                    string weaponopinion = textBox25.Text;
                    string weaponloyalty = textBox26.Text;
                    string weaponmaxcitysize = textBox27.Text;

                    string weaponslash = comboBox3.Text;
                    string weaponrequitech = comboBox5.Text;
                    string weaponregularaction = comboBox6.Text;
                    string weaponattackaction = comboBox7.Text;

                    string weaponcode1 = " \n" +
                    $"          ItemAsset {trueweaponname} = AssetManager.items.clone(\"{trueweaponname}\", \"sword\");\n" +
                    $"          {trueweaponname}.id = \"{trueweaponname}\";\n" +
                    $"          {trueweaponname}.name_templates = Toolbox.splitStringIntoList(new string[]\n" +
                    "          {\n" +
                    "          \"sword_name#30\",\n" +
                    "          \"sword_name_king#3\",\n" +
                    "          \"weapon_name_city\",\n" +
                    "          \"weapon_name_kingdom\",\n" +
                    "          \"weapon_name_culture\",\n" +
                    "          \"weapon_name_enemy_king\",\n" +
                    "          \"weapon_name_enemy_kingdom\"\n" +
                    "          });\n" +
                    $"          {trueweaponname}.materials = List.Of<string>(new string[]" + "{" + $"\"{weaponmaterial}\"" + "});\n" +
                    "          " + trueweaponname + ".base_stats[S.fertility] = " + weaponfertility + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.max_children] = " + weaponmaxchildren + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.max_age] = " + weaponmaxage + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.attack_speed] = " + weaponattackspeed + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.damage] = " + weapondamage + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.speed] = " + weaponspeed + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.health] = " + weaponhealth + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.accuracy] = " + weaponaccuracy + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.range] = " + weaponrange + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.armor] = " + weaponarmor + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.scale] = " + weaponscale + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.dodge] = " + weapondodge + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.targets] = " + weapontarget + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.critical_chance] = " + weaponcriticalchance + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.knockback] = " + weaponknowback + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.knockback_reduction] = " + weaponknowbackreduction + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.intelligence] = " + weaponinteligence + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.warfare] = " + weaponwarfare + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.diplomacy] = " + weapondiplomacy + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.stewardship] = " + weaponstewardship + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.opinion] = " + weaponopinion + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.loyalty_traits] = " + weaponloyalty + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.cities] = " + weaponmaxcities + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.zone_range] = " + weaponmaxcitysize + ";\n" +
                    $"          {trueweaponname}.equipment_value = {weaponvalueequipament};\n" +
                    $"          {trueweaponname}.path_slash_animation = \"effects/slashes/slash_{weaponslash}\";\n" +
                    $"          {trueweaponname}.tech_needed = \"{weaponrequitech}\";\n" +
                    $"          {trueweaponname}.equipmentType = EquipmentType.Weapon;\n" +
                    $"          {trueweaponname}.name_class = \"item_class_weapon\";\n" +
                    "          " + trueweaponname + $".action_special_effect = new WorldAction({weaponregularaction});\n" +
                    "          " + trueweaponname + $".action_attack_target = new AttackAction({weaponattackaction});\n" +
                    $"          AssetManager.items.list.AddItem({trueweaponname});\n" +
                    $"          Localization.addLocalization(\"item_{trueweaponname}\", \"{weapontitle}\");\n" +
                    $"          addWeaponsSprite({trueweaponname}.id, {trueweaponname}.materials[0]);\n" +
                    " \n";

                    string weaponcodee3 = " \n" +
                    $"          orc.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          human.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          dwarf.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          elf.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    " \n";

                    if (Program.WeaponCode.Contains(weaponcode1))
                    {
                        int count = 1;
                        string tempName = $"{weaponcode1}{count}";

                        while (Program.WeaponCode.Contains(tempName))
                        {
                            count++;
                            tempName = $"{weaponcode1}_{count}";
                        }

                        weaponcode1 = tempName;
                    }

                    if (Program.WeaponCode2.Contains(weaponcodee3))
                    {
                        int count = 1;
                        string tempName = $"{weaponcodee3}{count}";

                        while (Program.WeaponCode2.Contains(tempName))
                        {
                            count++;
                            tempName = $"{weaponcodee3}_{count}";
                        }

                        weaponcodee3 = tempName;
                    }

                    Program.WeaponCode.Add(weaponcode1);
                    if (radioButton3.Checked)
                    {
                        Program.WeaponCode2.Add(weaponcodee3);
                    }

                    //

                    string diretorioWeaponsImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                    string newFolder = "Weapons";
                    string newFolder2 = diretorioWeaponsImagens + newFolder;
                    Directory.CreateDirectory(newFolder2);
                    string diretorioWeaponsIcon = Path.Combine(newFolder2, "icon_" + trueweaponname + "_" + weaponmaterial + ".png");
                    string diretorioWeaponsSprite = Path.Combine(newFolder2, "w_" + trueweaponname + "_" + weaponmaterial + ".png");

                    string weaponicondiretory = pictureBox1.ImageLocation;
                    string weaponspritediretory = pictureBox2.ImageLocation;

                    File.Copy(weaponicondiretory, diretorioWeaponsIcon);
                    File.Copy(weaponspritediretory, diretorioWeaponsSprite);

                    pictureBox1.Image = Image.FromFile(diretorioWeaponsIcon);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox2.Image = Image.FromFile(diretorioWeaponsSprite);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("No Icon Selected.");
                        return;
                    }
                    else
                    {
                        string WeaponiconBase64;
                        string iconweaponnameeee = diretorioWeaponsIcon;
                        Program.WeaponIconNameList.Add(iconweaponnameeee);
                        using (MemoryStream iconweaponsave = new MemoryStream())
                        {
                            pictureBox1.Image.Save(iconweaponsave, ImageFormat.Png);
                            WeaponiconBase64 = Convert.ToBase64String(iconweaponsave.ToArray());
                        }
                        Program.WeaponIcon.Add(WeaponiconBase64);
                    }

                    if (pictureBox2.Image == null)
                    {
                        MessageBox.Show("No Sprite Selected.");
                        return;
                    }
                    else
                    {
                        string WeaponspriteBase64;
                        string spriteweaponnameeee = diretorioWeaponsSprite;
                        Program.WeaponSpriteNameList.Add(spriteweaponnameeee);
                        using (MemoryStream spriteweaponsave = new MemoryStream())
                        {
                            pictureBox2.Image.Save(spriteweaponsave, ImageFormat.Png);
                            WeaponspriteBase64 = Convert.ToBase64String(spriteweaponsave.ToArray());
                        }
                        Program.WeaponSprite.Add(WeaponspriteBase64);
                    }

                    MessageBox.Show("The Weapon Were Successfully Saved!");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Text = "0";
                    textBox4.Text = "0";
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
                    textBox17.Text = "0";
                    textBox18.Text = "0.0";
                    textBox19.Text = "0.0";
                    textBox20.Text = "0.0";
                    textBox21.Text = "0";
                    textBox22.Text = "0";
                    textBox23.Text = "0";
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    textBox26.Text = "0";
                    textBox27.Text = "0";

                    comboBox1.Text = string.Empty;
                    comboBox8.Text = string.Empty;
                    pictureBox1.Image.Dispose();
                    pictureBox2.Image.Dispose();
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }
                else
                {
                    MessageBox.Show("Fill in All Blanks First!");
                }
            }
            else if (radioButton2.Checked)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && comboBox1.Text != "" && comboBox8.Text != "" && (radioButton3.Checked || radioButton4.Checked))
                {
                    string weaponname = textBox1.Text;
                    string weaponmaterial = comboBox2.Text;

                    string[] weaponnamee;
                    string newweaponnamee = weaponname;
                    if (weaponname.Contains(" "))
                    {
                        weaponnamee = weaponname.Split(' ');
                        newweaponnamee = weaponnamee[0] + weaponnamee[1];

                    }
                    string trueweaponname = newweaponnamee;

                    string weapontitle = textBox2.Text;
                    string weaponvalueequipament = textBox3.Text;
                    string weaponhealth = textBox4.Text;
                    string weaponmaxage = textBox5.Text;
                    string weapondamage = textBox6.Text;
                    string weaponspeed = textBox7.Text;
                    string weaponarmor = textBox8.Text;
                    string weaponattackspeed = textBox9.Text;
                    string weapondodge = textBox10.Text;
                    string weaponaccuracy = textBox11.Text;
                    string weaponrange = textBox12.Text;
                    string weapontarget = textBox13.Text;
                    string weaponscale = textBox14.Text;
                    string weaponmaxcities = textBox15.Text;

                    string weaponfertility = textBox16.Text;
                    string weaponmaxchildren = textBox17.Text;
                    string weaponcriticalchance = textBox18.Text;
                    string weaponknowback = textBox19.Text;
                    string weaponknowbackreduction = textBox20.Text;
                    string weaponinteligence = textBox21.Text;
                    string weaponwarfare = textBox22.Text;
                    string weapondiplomacy = textBox23.Text;
                    string weaponstewardship = textBox24.Text;
                    string weaponopinion = textBox25.Text;
                    string weaponloyalty = textBox26.Text;
                    string weaponmaxcitysize = textBox27.Text;

                    string weaponslash = comboBox3.Text;
                    string weaponprojetil = comboBox4.Text;
                    string weaponrequitech = comboBox5.Text;
                    string weaponregularaction = comboBox6.Text;
                    string weaponattackaction = comboBox7.Text;

                    string weaponcodee2 = " \n" +
                    $"          ItemAsset {trueweaponname} = AssetManager.items.clone(\"{trueweaponname}\", \"bow\");\n" +
                    $"          {trueweaponname}.id = \"{trueweaponname}\";\n" +
                    $"          {trueweaponname}.name_templates = Toolbox.splitStringIntoList(new string[]\n" +
                    "          {\n" +
                    "          \"bow_name#30\",\n" +
                    "          \"sword_name_king#3\",\n" +
                    "          \"weapon_name_city\",\n" +
                    "          \"weapon_name_kingdom\",\n" +
                    "          \"weapon_name_culture\",\n" +
                    "          \"weapon_name_enemy_king\",\n" +
                    "          \"weapon_name_enemy_kingdom\"\n" +
                    "          });\n" +
                    $"          {trueweaponname}.materials = List.Of<string>(new string[]" + "{" + $"\"{weaponmaterial}\"" + "});\n" +
                    $"          {trueweaponname}.projectile = \"{weaponprojetil}\";\n" +
                    "          " + trueweaponname + ".base_stats[S.fertility] = " + weaponfertility + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.max_children] = " + weaponmaxchildren + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.max_age] = " + weaponmaxage + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.attack_speed] = " + weaponattackspeed + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.damage] = " + weapondamage + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.speed] = " + weaponspeed + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.health] = " + weaponhealth + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.accuracy] = " + weaponaccuracy + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.range] = " + weaponrange + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.armor] = " + weaponarmor + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.scale] = " + weaponscale + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.dodge] = " + weapondodge + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.targets] = " + weapontarget + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.critical_chance] = " + weaponcriticalchance + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.knockback] = " + weaponknowback + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.knockback_reduction] = " + weaponknowbackreduction + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.intelligence] = " + weaponinteligence + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.warfare] = " + weaponwarfare + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.diplomacy] = " + weapondiplomacy + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.stewardship] = " + weaponstewardship + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.opinion] = " + weaponopinion + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.loyalty_traits] = " + weaponloyalty + "f;\n" +
                    "          " + trueweaponname + ".base_stats[S.cities] = " + weaponmaxcities + ";\n" +
                    "          " + trueweaponname + ".base_stats[S.zone_range] = " + weaponmaxcitysize + ";\n" +
                    $"          {trueweaponname}.equipment_value = {weaponvalueequipament};\n" +
                    $"          {trueweaponname}.path_slash_animation = \"effects/slashes/slash_{weaponslash}\";\n" +
                    $"          {trueweaponname}.tech_needed = \"{weaponrequitech}\";\n" +
                    $"          {trueweaponname}.equipmentType = EquipmentType.Weapon;\n" +
                    $"          {trueweaponname}.name_class = \"item_class_weapon\";\n" +
                    "          " + trueweaponname + $".action_special_effect = new WorldAction({weaponregularaction});\n" +
                    "          " + trueweaponname + $".action_attack_target = new AttackAction({weaponattackaction});\n" +
                    $"          AssetManager.items.list.AddItem({trueweaponname});\n" +
                    $"          Localization.addLocalization(\"item_{trueweaponname}\", \"{weapontitle}\");\n" +
                    $"          addWeaponsSprite({trueweaponname}.id, {trueweaponname}.materials[0]);\n" +
                    " \n";

                    string weaponcodee3 = " \n" +
                    $"          orc.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          human.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          dwarf.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    $"          elf.preferred_weapons.Add(\"{trueweaponname}\");\n" +
                    " \n";

                    if (Program.WeaponCode.Contains(weaponcodee2))
                    {
                        int count = 1;
                        string tempName = $"{weaponcodee2}{count}";

                        while (Program.WeaponCode.Contains(tempName))
                        {
                            count++;
                            tempName = $"{weaponcodee2}_{count}";
                        }

                        weaponcodee2 = tempName;
                    }

                    if (Program.WeaponCode2.Contains(weaponcodee3))
                    {
                        int count = 1;
                        string tempName = $"{weaponcodee3}{count}";

                        while (Program.WeaponCode2.Contains(tempName))
                        {
                            count++;
                            tempName = $"{weaponcodee3}_{count}";
                        }

                        weaponcodee3 = tempName;
                    }

                    Program.WeaponCode.Add(weaponcodee2);
                    if (radioButton3.Checked)
                    {
                        Program.WeaponCode2.Add(weaponcodee3);
                    }

                    //

                    string diretorioWeaponsImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                    string newFolder = "Weapons";
                    string newFolder2 = diretorioWeaponsImagens + newFolder;
                    Directory.CreateDirectory(newFolder2);
                    string diretorioWeaponsIcon = Path.Combine(newFolder2, "icon_" + trueweaponname + "_" + weaponmaterial + ".png");
                    string diretorioWeaponsSprite = Path.Combine(newFolder2, "w_" + trueweaponname + "_" + weaponmaterial + ".png");

                    string weaponicondiretory = pictureBox1.ImageLocation;
                    string weaponspritediretory = pictureBox2.ImageLocation;

                    File.Copy(weaponicondiretory, diretorioWeaponsIcon);
                    File.Copy(weaponspritediretory, diretorioWeaponsSprite);

                    pictureBox1.Image = Image.FromFile(diretorioWeaponsIcon);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox2.Image = Image.FromFile(diretorioWeaponsSprite);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("No Icon Selected.");
                        return;
                    }
                    else
                    {
                        string WeaponiconBase64;
                        string iconweaponnameeee = diretorioWeaponsIcon;
                        Program.WeaponIconNameList.Add(iconweaponnameeee);
                        using (MemoryStream iconweaponsave = new MemoryStream())
                        {
                            pictureBox1.Image.Save(iconweaponsave, ImageFormat.Png);
                            WeaponiconBase64 = Convert.ToBase64String(iconweaponsave.ToArray());
                        }
                        Program.WeaponIcon.Add(WeaponiconBase64);
                    }

                    if (pictureBox2.Image == null)
                    {
                        MessageBox.Show("No Sprite Selected.");
                        return;
                    }
                    else
                    {
                        string WeaponspriteBase64;
                        string spriteweaponnameeee = diretorioWeaponsSprite;
                        Program.WeaponSpriteNameList.Add(spriteweaponnameeee);
                        using (MemoryStream spriteweaponsave = new MemoryStream())
                        {
                            pictureBox2.Image.Save(spriteweaponsave, ImageFormat.Png);
                            WeaponspriteBase64 = Convert.ToBase64String(spriteweaponsave.ToArray());
                        }
                        Program.WeaponSprite.Add(WeaponspriteBase64);
                    }

                    MessageBox.Show("The Weapon Were Successfully Saved!");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Text = "0";
                    textBox4.Text = "0";
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
                    textBox17.Text = "0";
                    textBox18.Text = "0.0";
                    textBox19.Text = "0.0";
                    textBox20.Text = "0.0";
                    textBox21.Text = "0";
                    textBox22.Text = "0";
                    textBox23.Text = "0";
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    textBox26.Text = "0";
                    textBox27.Text = "0";

                    comboBox1.Text = string.Empty;
                    comboBox8.Text = string.Empty;
                    pictureBox1.Image.Dispose();
                    pictureBox2.Image.Dispose();
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }
                else
                {
                    MessageBox.Show("Fill in All Blanks First!");
                }
            }
            else
            {
                MessageBox.Show("Choose Weapon Type!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Weapon Icon";
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Weapon Sprite";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(pathImage);
                    pictureBox2.ImageLocation = openFileDialog.FileName;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox8.Text = fileName;
                }
            }
        }

        #endregion

        #region createitem
        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Item Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoImagem = openFileDialog.FileName;
                    pictureBox3.Image = Image.FromFile(caminhoImagem);
                    pictureBox3.ImageLocation = openFileDialog.FileName;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(caminhoImagem);
                    comboBox9.Text = fileName;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox54.Text != "" && textBox53.Text != "" && comboBox13.Text != "" && comboBox12.Text != "" && comboBox11.Text != "" && comboBox10.Text != "" && (radioButton6.Checked || radioButton5.Checked))
            {
                string itemname = textBox54.Text;
                string itemtitle = textBox53.Text;

                string itemnametemplate = comboBox13.Text;
                string itemmaterial = comboBox12.Text;
                string itemtype = comboBox11.Text;
                string itemrequitech = comboBox10.Text;

                string itemvalueequipament = textBox52.Text;
                string itemhealth = textBox51.Text;
                string itemmaxage = textBox50.Text;
                string itemdamage = textBox49.Text;
                string itemspeed = textBox48.Text;
                string itemarmor = textBox47.Text;
                string itemattackspeed = textBox46.Text;
                string itemdodge = textBox45.Text;
                string itemaccuracy = textBox44.Text;
                string itemrange = textBox43.Text;
                string itemtarget = textBox42.Text;
                string itemscale = textBox41.Text;
                string itemmaxcities = textBox40.Text;

                string itemfertility = textBox39.Text;
                string itemmaxchildren = textBox38.Text;
                string itemcriticalchance = textBox37.Text;
                string itemknowback = textBox36.Text;
                string itemknowbackreduction = textBox35.Text;
                string iteminteligence = textBox34.Text;
                string itemwarfare = textBox33.Text;
                string itemdiplomacy = textBox32.Text;
                string itemstewardship = textBox31.Text;
                string itemopinion = textBox30.Text;
                string itemloyalty = textBox29.Text;
                string itemmaxcitysize = textBox28.Text;

                string itemequipament = "_equipment";
                string itemacessory = "_accessory";

                string[] itemnamee;
                string newitemnamee = itemname;
                if (itemname.Contains(" "))
                {
                    itemnamee = itemname.Split(' ');
                    newitemnamee = itemnamee[0] + itemnamee[1];

                }
                string trueitemname = newitemnamee;

                string itemcodee3 = " \n" +
                $"          orc.preferred_weapons.Add(\"{trueitemname}\");\n" +
                $"          human.preferred_weapons.Add(\"{trueitemname}\");\n" +
                $"          dwarf.preferred_weapons.Add(\"{trueitemname}\");\n" +
                $"          elf.preferred_weapons.Add(\"{trueitemname}\");\n" +
                " \n";

                string itemcode1 = $" \n" +
                $"          ItemAsset {trueitemname} = AssetManager.items.clone(\"{trueitemname}\", \"{itemequipament}\");\n" +
                $"          {trueitemname}.id = \"{trueitemname}\";\n" +
                "          " + trueitemname + ".base_stats[S.fertility] = " + itemfertility + "f;\n" +
                "          " + trueitemname + ".base_stats[S.max_children] = " + itemmaxchildren + "f;\n" +
                "          " + trueitemname + ".base_stats[S.max_age] = " + itemmaxage + "f;\n" +
                "          " + trueitemname + ".base_stats[S.attack_speed] = " + itemattackspeed + ";\n" +
                "          " + trueitemname + ".base_stats[S.damage] = " + itemdamage + ";\n" +
                "          " + trueitemname + ".base_stats[S.speed] = " + itemspeed + "f;\n" +
                "          " + trueitemname + ".base_stats[S.health] = " + itemhealth + ";\n" +
                "          " + trueitemname + ".base_stats[S.accuracy] = " + itemaccuracy + "f;\n" +
                "          " + trueitemname + ".base_stats[S.range] = " + itemrange + ";\n" +
                "          " + trueitemname + ".base_stats[S.armor] = " + itemarmor + ";\n" +
                "          " + trueitemname + ".base_stats[S.scale] = " + itemscale + "f;\n" +
                "          " + trueitemname + ".base_stats[S.dodge] = " + itemdodge + "f;\n" +
                "          " + trueitemname + ".base_stats[S.targets] = " + itemtarget + "f;\n" +
                "          " + trueitemname + ".base_stats[S.critical_chance] = " + itemcriticalchance + "f;\n" +
                "          " + trueitemname + ".base_stats[S.knockback] = " + itemknowback + "f;\n" +
                "          " + trueitemname + ".base_stats[S.knockback_reduction] = " + itemknowbackreduction + "f;\n" +
                "          " + trueitemname + ".base_stats[S.intelligence] = " + iteminteligence + ";\n" +
                "          " + trueitemname + ".base_stats[S.warfare] = " + itemwarfare + ";\n" +
                "          " + trueitemname + ".base_stats[S.diplomacy] = " + itemdiplomacy + ";\n" +
                "          " + trueitemname + ".base_stats[S.stewardship] = " + itemstewardship + ";\n" +
                "          " + trueitemname + ".base_stats[S.opinion] = " + itemopinion + "f;\n" +
                "          " + trueitemname + ".base_stats[S.loyalty_traits] = " + itemloyalty + "f;\n" +
                "          " + trueitemname + ".base_stats[S.cities] = " + itemmaxcities + ";\n" +
                "          " + trueitemname + ".base_stats[S.zone_range] = " + itemmaxcitysize + ";\n" +
                $"          {trueitemname}.equipmentType = EquipmentType.{itemtype};\n" +
                $"          {trueitemname}.name_class = \"item_class_armor\";\n" +
                $"          {trueitemname}.name_templates = List.Of<string>(new string[]" + "{ " + $"\"{itemnametemplate}\"" + " });\n" +
                $"          {trueitemname}.materials = List.Of<string>(new string[]" + "{ " + $"\"{itemmaterial}\"" + " });\n" +
                $"          {trueitemname}.tech_needed = \"{itemrequitech}\";\n" +
                $"          {trueitemname}.equipment_value = {itemvalueequipament};\n" +
                $"          AssetManager.items.list.AddItem({trueitemname});\n" +
                $"          Localization.addLocalization(\"item_{trueitemname}\", \"{itemtitle}\");\n" +
                $" \n";

                string itemcodee2 = $" \n" +
                $"          ItemAsset {trueitemname} = AssetManager.items.clone(\"{trueitemname}\", \"{itemacessory}\");\n" +
                $"          {trueitemname}.id = \"{trueitemname}\";\n" +
                "          " + trueitemname + ".base_stats[S.fertility] = " + itemfertility + "f;\n" +
                "          " + trueitemname + ".base_stats[S.max_children] = " + itemmaxchildren + "f;\n" +
                "          " + trueitemname + ".base_stats[S.max_age] = " + itemmaxage + "f;\n" +
                "          " + trueitemname + ".base_stats[S.attack_speed] = " + itemattackspeed + ";\n" +
                "          " + trueitemname + ".base_stats[S.damage] = " + itemdamage + ";\n" +
                "          " + trueitemname + ".base_stats[S.speed] = " + itemspeed + "f;\n" +
                "          " + trueitemname + ".base_stats[S.health] = " + itemhealth + ";\n" +
                "          " + trueitemname + ".base_stats[S.accuracy] = " + itemaccuracy + "f;\n" +
                "          " + trueitemname + ".base_stats[S.range] = " + itemrange + ";\n" +
                "          " + trueitemname + ".base_stats[S.armor] = " + itemarmor + ";\n" +
                "          " + trueitemname + ".base_stats[S.scale] = " + itemscale + "f;\n" +
                "          " + trueitemname + ".base_stats[S.dodge] = " + itemdodge + "f;\n" +
                "          " + trueitemname + ".base_stats[S.targets] = " + itemtarget + "f;\n" +
                "          " + trueitemname + ".base_stats[S.critical_chance] = " + itemcriticalchance + "f;\n" +
                "          " + trueitemname + ".base_stats[S.knockback] = " + itemknowback + "f;\n" +
                "          " + trueitemname + ".base_stats[S.knockback_reduction] = " + itemknowbackreduction + "f;\n" +
                "          " + trueitemname + ".base_stats[S.intelligence] = " + iteminteligence + ";\n" +
                "          " + trueitemname + ".base_stats[S.warfare] = " + itemwarfare + ";\n" +
                "          " + trueitemname + ".base_stats[S.diplomacy] = " + itemdiplomacy + ";\n" +
                "          " + trueitemname + ".base_stats[S.stewardship] = " + itemstewardship + ";\n" +
                "          " + trueitemname + ".base_stats[S.opinion] = " + itemopinion + "f;\n" +
                "          " + trueitemname + ".base_stats[S.loyalty_traits] = " + itemloyalty + "f;\n" +
                "          " + trueitemname + ".base_stats[S.cities] = " + itemmaxcities + ";\n" +
                "          " + trueitemname + ".base_stats[S.zone_range] = " + itemmaxcitysize + ";\n" +
                $"          {trueitemname}.equipmentType = EquipmentType.{itemtype};\n" +
                $"          {trueitemname}.name_templates = List.Of<string>(new string[]" + "{ " + $"\"{itemnametemplate}\"" + " });\n" +
                $"          {trueitemname}.materials = List.Of<string>(new string[]" + "{ " + $"\"{itemmaterial}\"" + " });\n" +
                $"          {trueitemname}.tech_needed = \"{itemrequitech}\";\n" +
                $"          {trueitemname}.equipment_value = {itemvalueequipament};\n" +
                $"          AssetManager.items.list.AddItem({trueitemname});\n" +
                $"          Localization.addLocalization(\"item_{trueitemname}\", \"{itemtitle}\");\n" +
                $" \n";

                if (Program.Itemcode.Contains(itemcode1))
                {
                    int count = 1;
                    string tempName = $"{itemcode1}{count}";

                    while (Program.Itemcode.Contains(tempName))
                    {
                        count++;
                        tempName = $"{itemcode1}_{count}";
                    }

                    itemcode1 = tempName;
                }

                if (Program.Itemcode.Contains(itemcodee2))
                {
                    int count = 1;
                    string tempName = $"{itemcodee2}{count}";

                    while (Program.Itemcode.Contains(tempName))
                    {
                        count++;
                        tempName = $"{itemcodee2}_{count}";
                    }

                    itemcodee2 = tempName;
                }

                if (Program.Itemcode2.Contains(itemcodee3))
                {
                    int count = 1;
                    string tempName = $"{itemcodee3}{count}";

                    while (Program.Itemcode2.Contains(tempName))
                    {
                        count++;
                        tempName = $"{itemcodee3}_{count}";
                    }

                    itemcodee3 = tempName;
                }

                if (comboBox11.Text == "Helmet")
                {
                    Program.Itemcode.Add(itemcode1);
                }

                if (comboBox11.Text == "Armor")
                {
                    Program.Itemcode.Add(itemcode1);
                }

                if (comboBox11.Text == "Boots")
                {
                    Program.Itemcode.Add(itemcode1);
                }

                if (comboBox11.Text == "Ring")
                {
                    Program.Itemcode.Add(itemcodee2);
                }

                if (comboBox11.Text == "Amulet")
                {
                    Program.Itemcode.Add(itemcodee2);
                }

                if (radioButton6.Checked)
                {
                    Program.Itemcode2.Add(itemcodee3);
                }

                //

                string diretorioitemImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                string newFolder = "Items";
                string newFolder2 = diretorioitemImagens + newFolder;
                Directory.CreateDirectory(newFolder2);
                string diretorioItemIcon = Path.Combine(newFolder2, "icon_" + trueitemname + "_" + itemmaterial + ".png");

                string itemicondiretory = pictureBox3.ImageLocation;

                File.Copy(itemicondiretory, diretorioItemIcon);

                pictureBox3.Image = Image.FromFile(diretorioItemIcon);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                if (pictureBox3.Image == null)
                {
                    MessageBox.Show("No Icon Selected.");
                    return;
                }
                else
                {
                    string ItemiconBase64;
                    string iconItemnameeee = diretorioItemIcon;
                    Program.ItemIconNameList.Add(iconItemnameeee);
                    using (MemoryStream iconitemsave = new MemoryStream())
                    {
                        pictureBox3.Image.Save(iconitemsave, ImageFormat.Png);
                        ItemiconBase64 = Convert.ToBase64String(iconitemsave.ToArray());
                    }
                    Program.ItemIcon.Add(ItemiconBase64);
                }

                MessageBox.Show("The Item Were Successfully Saved!");

                textBox54.Clear();
                textBox53.Clear();
                textBox52.Text = "0";
                textBox51.Text = "0";
                textBox50.Text = "0";
                textBox49.Text = "0";
                textBox48.Text = "0";
                textBox47.Text = "0";
                textBox46.Text = "0";
                textBox45.Text = "0";
                textBox44.Text = "0";
                textBox43.Text = "0";
                textBox42.Text = "0";
                textBox41.Text = "0.0";
                textBox40.Text = "0";

                textBox39.Text = "0.0";
                textBox38.Text = "0";
                textBox37.Text = "0.0";
                textBox36.Text = "0.0";
                textBox35.Text = "0.0";
                textBox34.Text = "0";
                textBox33.Text = "0";
                textBox32.Text = "0";
                textBox31.Text = "0";
                textBox30.Text = "0";
                textBox29.Text = "0";
                textBox28.Text = "0";

                comboBox9.Text = string.Empty;
                pictureBox3.Image = null;
                radioButton6.Checked = false;
                radioButton5.Checked = false;
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        #endregion

        #region comboBoxesMouseClick
        private void comboBox6_MouseClick(object sender, MouseEventArgs e)
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
                        if (!comboBox6.Items.Contains(act2))
                        {
                            comboBox6.Items.Add(act2);
                        }
                    }
                }
            }
        }

        private void comboBox7_MouseClick(object sender, MouseEventArgs e)
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
                        if (!comboBox7.Items.Contains(act1))
                        {
                            comboBox7.Items.Add(act1);
                        }
                    }
                }
            }
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.ProjectileName.Count == 0)
                {

                }
                else
                {
                    foreach (string pjt1 in Program.ProjectileName)
                    {
                        if (!comboBox4.Items.Contains(pjt1))
                        {
                            comboBox4.Items.Add(pjt1);
                        }
                    }
                }
            }
        }
        #endregion

        #region imagestopicturebox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ace - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Ace_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Yoru - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Yoru_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Katana - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Katana_steel" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "An08 - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_An08_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "AxeOP - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_AxeOP_iron" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Club - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Club_wood" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "DivineSword - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_DivineSword_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Enma - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Enma_mythril" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "GreatSword - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_GreatSword_steel" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Hassaikai - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Hassaikai_mythril" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "InfernalTrident - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_InfernalTrident_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Murakumogiri - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Murakumogiri_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "SandaiKitetsu - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_SandaiKitetsu_steel" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "An16 - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_An16_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Bazooka - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Bazooka_wood" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "DivineStaff - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_DivineStaff_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Slingshot - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Slingshot_wood" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "XBeast - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_XBeast_wood" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Musket - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_MusketOP9_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "M4 - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_M4_steel" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "Pistol - Icon")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsIcon");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Pistol_adamantine" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.Text == "")
            {
                pictureBox1.Image = null;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "Ace - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Ace_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Yoru - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Yoru_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Katana - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Katana_steel" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "An08 - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_An08_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "AxeOP - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_AxeOP_iron" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Club - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Club_wood" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "DivineSword - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_DivineSword_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Enma - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Enma_mythril" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "GreatSword - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_GreatSword_steel" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Hassaikai - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Hassaikai_mythril" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "InfernalTrident - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_InfernalTrident_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Murakumogiri - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Murakumogiri_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "SandaiKitetsu - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_SandaiKitetsu_steel" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "An16 - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_An16_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Bazooka - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Bazooka_wood" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "DivineStaff - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_DivineStaff_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Slingshot - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Slingshot_wood" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "XBeast - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_XBeast_wood" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Musket - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_MusketOP9_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "M4 - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_M4_steel" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "Pistol - Sprite")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Weapons", "WeaponsSprite");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "w_Pistol_adamantine" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox8.Text == "")
            {
                pictureBox2.Image = null;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text == "KriegArmor")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_KriegArmor_steel" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "Mugiwara")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_Mugiwara_iron" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "SanjiRS1")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_SanjiRS1_mythril" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "SanjiRS2")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_SanjiRS2_mythril" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "SanjiRS3")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_SanjiRS3_mythril" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "JapanArmy1")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_JapaneseMilitaryClothingHelmet_leather" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "JapanArmy2")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_JapaneseMilitaryClothingArmor_leather" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "JapanArmy3")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "Items");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "icon_JapaneseMilitaryClothingBoots_leather" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox9.Text == "")
            {
                pictureBox3.Image = null;
            }
        }
        #endregion

        #region radionbuttons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label5.Enabled = false;
                label5.Visible = false;
                comboBox4.Enabled = false;
                comboBox4.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label5.Enabled = true;
                label5.Visible = true;
                comboBox4.Enabled = true;
                comboBox4.Visible = true;
            }
        }
        #endregion
    }
}