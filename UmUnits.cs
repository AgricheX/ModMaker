using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod_Maker
{
    public partial class UmUnits : Form
    {
        #region InitializeComponent
        public UmUnits()
        {
            InitializeComponent();
        }

        private List<string> TraitUnits = new List<string>();
        private List<string> SpellUnits = new List<string>();
        private List<string> FriendlyTag = new List<string>();
        private List<string> EnemyTag = new List<string>();

        private void UmUnits_Load(object sender, EventArgs e)
        {
            comboBox49.MouseClick += comboBox49_MouseClick;
        }

        #endregion

        #region createkingdomtag
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string NewKingdomTagName = textBox2.Text;
                string[] NewKingdomTagNamee;
                string NewNewKingdomTagNamee = NewKingdomTagName;
                if (NewKingdomTagName.Contains(" "))
                {
                    NewKingdomTagNamee = NewKingdomTagName.Split(' ');
                    NewNewKingdomTagNamee = NewKingdomTagNamee[0] + NewKingdomTagNamee[1];

                }
                string TrueKingdomTagName = NewNewKingdomTagNamee + "Kingdom";

                string friendlytag = comboBox50.Text;
                if (comboBox50.Text == "")
                {
                    MessageBox.Show("Choose a FriendlyTag First!");
                }
                else if (comboBox50.Text == "NoneFriendLyTag")
                {
                    string nonefriendlytag = " ";
                    FriendlyTag.Add(nonefriendlytag);
                    MessageBox.Show("FriendlyTag Save Successfully!");
                }
                else if (comboBox50.Text != "NoneFriendLyTag" && comboBox50.Text != "")
                {
                    string friendlytagcode = $"          {TrueKingdomTagName}.addFriendlyTag(\"{friendlytag}\");";
                    FriendlyTag.Add(friendlytagcode);
                    MessageBox.Show("FriendlyTag Save Successfully!");
                }
            }
            else
            {
                MessageBox.Show("Write a KingdomTag Name First!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string NewKingdomTagName = textBox2.Text;
                string[] NewKingdomTagNamee;
                string NewNewKingdomTagNamee = NewKingdomTagName;
                if (NewKingdomTagName.Contains(" "))
                {
                    NewKingdomTagNamee = NewKingdomTagName.Split(' ');
                    NewNewKingdomTagNamee = NewKingdomTagNamee[0] + NewKingdomTagNamee[1];

                }
                string TrueKingdomTagName = NewNewKingdomTagNamee + "Kingdom";

                string enemytag = comboBox51.Text;
                if (comboBox51.Text == "")
                {
                    MessageBox.Show("Choose a EnemyTag First!");
                }
                else if (comboBox51.Text == "NoneEnemyTag")
                {
                    string noneenemytag = " ";
                    EnemyTag.Add(noneenemytag);
                    MessageBox.Show("EnemyTag Save Successfully!");
                }
                else if (comboBox51.Text != "NoneEnemyTag" && comboBox51.Text != "")
                {
                    string enemytagcode = $"          {TrueKingdomTagName}.addEnemyTag(\"{enemytag}\");";
                    EnemyTag.Add(enemytagcode);
                    MessageBox.Show("EnemyTag Save Successfully!");
                }
            }
            else
            {
                MessageBox.Show("Write a KingdomTag Name First!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (FriendlyTag.Count == 0 && EnemyTag.Count == 0)
                {
                    MessageBox.Show("Choose a FriendlyTag or a EnemyTag First!");
                }
                else
                {
                    string NewKingdomTagName = textBox2.Text;
                    string[] NewKingdomTagNamee;
                    string NewNewKingdomTagNamee = NewKingdomTagName;
                    if (NewKingdomTagName.Contains(" "))
                    {
                        NewKingdomTagNamee = NewKingdomTagName.Split(' ');
                        NewNewKingdomTagNamee = NewKingdomTagNamee[0] + NewKingdomTagNamee[1];

                    }
                    string TrueKingdomTagName = NewNewKingdomTagNamee + "Kingdom";
                    string TrueKingdomName = NewNewKingdomTagNamee;

                    string ufriendlytag = string.Join(Environment.NewLine, FriendlyTag);
                    string uenemytag = string.Join(Environment.NewLine, EnemyTag);

                    string kingdomtagcode = $"          KingdomAsset {TrueKingdomTagName} = new KingdomAsset();\n" +
                    $"          {TrueKingdomTagName}.id = \"{TrueKingdomName}\";\n" +
                    $"          {TrueKingdomTagName}.mobs = true;\n" +
                    $"          {TrueKingdomTagName}.addTag(\"{TrueKingdomName}\");\n" +
                    $"          {TrueKingdomTagName}.addFriendlyTag(\"{TrueKingdomName}\");\n" +
                    $"{ufriendlytag}\n" +
                    $"{uenemytag}\n" +
                    $"          AssetManager.kingdoms.add({TrueKingdomTagName});\n" +
                    $"          MapBox.instance.kingdoms.CallMethod(\"newHiddenKingdom\", {TrueKingdomTagName});\n";

                    if (Program.KingdomTagCode.Contains(kingdomtagcode))
                    {
                        int count = 1;
                        string tempName = $"{TrueKingdomTagName}{count}";

                        string tempNameCode = $"{kingdomtagcode}{count}";

                        while (Program.KingdomTagCode.Contains(tempNameCode))
                        {
                            count++;
                            tempName = $"{TrueKingdomTagName}_{count}";
                            tempNameCode = $"{kingdomtagcode}_{count}";
                        }
                        TrueKingdomTagName = tempName;

                        kingdomtagcode = tempNameCode;
                    }
                    Program.KingdomTagCode.Add(kingdomtagcode);
                    Program.KingdomTagName.Add(TrueKingdomTagName);
                    Program.KingdomTagTrueName.Add(TrueKingdomName);

                    comboBox45.Items.Add(TrueKingdomName);
                    comboBox46.Items.Add(TrueKingdomName);
                    comboBox50.Items.Add(TrueKingdomName);
                    comboBox51.Items.Add(TrueKingdomName);

                    MessageBox.Show("KingdomTag Created Successfully!");

                    textBox2.Clear();
                    FriendlyTag.Clear();
                    EnemyTag.Clear();
                }
            }
            else
            {
                MessageBox.Show("Write a KingdomTag Name First!");
            }
        }
        #endregion

        #region unitimages
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Swim";
                openFileDialog.Filter = "Sprites (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(pathImage);
                    pictureBox1.ImageLocation = openFileDialog.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox47.Text = fileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No Swim Sprite Selected.");
                return;
            }
            else
            {
                int swimcounter = Program.SwimCounter;
                int spritescounter = Program.UnitsSpritesCounter;
                spritescounter++;
                Program.UnitsSpritesCounter = spritescounter;

                string directorySwimImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                string newFolder = "Swim" + spritescounter;
                string newFolder2 = Path.Combine(directorySwimImagens, newFolder);

                Directory.CreateDirectory(newFolder2);

                string diretorioSwimSpriteImage = Path.Combine(newFolder2, "swim_" + swimcounter + ".png");
                string SwimSpriteName = "swim_" + swimcounter;
                string SwimSpriteNameList = "swim_" + swimcounter + ".png";
                comboBox47.Text = "swim_" + swimcounter + ".png";
                string swimspritediretory = pictureBox1.ImageLocation;

                File.Copy(swimspritediretory, diretorioSwimSpriteImage);
                pictureBox1.Image = Image.FromFile(diretorioSwimSpriteImage);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                Program.SwimName.Add(SwimSpriteName);
                Program.SwimNameList.Add(SwimSpriteNameList);

                string swimspriteBase64;
                using (MemoryStream swimspritesave = new MemoryStream())
                {
                    pictureBox1.Image.Save(swimspritesave, ImageFormat.Png);
                    swimspriteBase64 = Convert.ToBase64String(swimspritesave.ToArray());
                }
                Program.SwimSprite.Add(swimspriteBase64);

                MessageBox.Show("Swim Sprite Save Successfully!");

                comboBox47.Text = string.Empty;
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                swimcounter++;
                Program.SwimCounter = swimcounter;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Walk";
                openFileDialog.Filter = "Sprites (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(pathImage);
                    pictureBox2.ImageLocation = openFileDialog.FileName;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox48.Text = fileName;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No Walk Sprite Selected.");
                return;
            }
            else
            {
                int walkcounter = Program.WalkCounter;
                int walkspritecounter = Program.UnitsSpritesCounter;
                walkspritecounter++;
                Program.UnitsSpritesCounter = walkspritecounter;

                string directoryWalkImagens = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\";
                string newFolder = "Walk" + walkspritecounter;
                string newFolder2 = Path.Combine(directoryWalkImagens, newFolder);
                    
                Directory.CreateDirectory(newFolder2);

                string diretorioWalkSpriteImage = Path.Combine(newFolder2, "walk_" + walkcounter + ".png");
                string WalkSpriteName = "walk_" + walkcounter;
                string WalkSpriteNameList = "walk_" + walkcounter + ".png";
                comboBox48.Text = "walk_" + walkcounter + ".png";
                string walkspritediretory = pictureBox2.ImageLocation;

                File.Copy(walkspritediretory, diretorioWalkSpriteImage);
                pictureBox2.Image = Image.FromFile(diretorioWalkSpriteImage);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                Program.WalkName.Add(WalkSpriteName);
                Program.WalkNameList.Add(WalkSpriteNameList);
                string walkspriteBase64;
                using (MemoryStream walkspritesave = new MemoryStream())
                {
                    pictureBox2.Image.Save(walkspritesave, ImageFormat.Png);
                    walkspriteBase64 = Convert.ToBase64String(walkspritesave.ToArray());
                }
                Program.WalkSprite.Add(walkspriteBase64);

                MessageBox.Show("Walk Sprite Save Successfully!");

                comboBox48.Text = string.Empty;
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
                walkcounter++;
                Program.WalkCounter = walkcounter;
            }
        }
        #endregion

        #region utils
        private void button6_Click(object sender, EventArgs e)
        {
            string traitchoosed = comboBox49.Text;
            if (comboBox49.Text == "")
            {
                MessageBox.Show("Choose a Trait First!");
            }
            else if (comboBox49.Text == "NoneTrait")
            {
                string unittrait = " ";
                TraitUnits.Add(unittrait);
                MessageBox.Show("Trait Choosed Save Successfully!");
            }
            else if (comboBox49.Text != "")
            {
                string traitchoosedcode = $"            AssetManager.actor_library.CallMethod(\"addTrait\", \"{traitchoosed}\");";
                TraitUnits.Add(traitchoosedcode);
                MessageBox.Show("Trait Choosed Save Successfully!");
            }
        }

        private void comboBox49_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Program.TraitsName.Count == 0)
                {

                }
                else
                {
                    foreach (string traitname in Program.TraitsName)
                    {
                        if (!comboBox49.Items.Contains(traitname))
                        {
                            comboBox49.Items.Add(traitname);
                        }
                    }
                }
            }
        }

        #endregion

        #region createunits
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && comboBox8.Text != "" && comboBox9.Text != "" && comboBox10.Text != "" && comboBox11.Text != "" && comboBox12.Text != "" && comboBox13.Text != "" && comboBox14.Text != "" && comboBox15.Text != "" && comboBox16.Text != "" && comboBox17.Text != "" && comboBox18.Text != "" && comboBox19.Text != "" && comboBox20.Text != "" && comboBox21.Text != "" && comboBox22.Text != "" && comboBox23.Text != "" && comboBox24.Text != "" && comboBox25.Text != "" && comboBox26.Text != "" && comboBox27.Text != "" && comboBox28.Text != "" && comboBox29.Text != "" && comboBox30.Text != "" && comboBox31.Text != "" && comboBox32.Text != "" && comboBox33.Text != "" && comboBox34.Text != "" && comboBox35.Text != "" && comboBox36.Text != "" && comboBox37.Text != "" && comboBox38.Text != "" && comboBox39.Text != "" && comboBox40.Text != "" && comboBox41.Text != "" && comboBox42.Text != "" && comboBox43.Text != "" && comboBox44.Text != "" && comboBox45.Text != "" && comboBox46.Text != "" && comboBox49.Text != "" && (radioButton1.Checked || radioButton2.Checked) && Program.SwimSprite.Count != 0 && Program.WalkSprite.Count != 0 && pictureBox3.Image != null)
            {
                if (radioButton1.Checked)
                {
                    string NewUnitName = textBox1.Text;
                    string[] NewUnitNamee;
                    string NewNewUnitNamee = NewUnitName;
                    if (NewUnitName.Contains(" "))
                    {
                        NewUnitNamee = NewUnitName.Split(' ');
                        NewNewUnitNamee = NewUnitNamee[0] + NewUnitNamee[1];

                    }
                    string TrueUnitName = NewNewUnitNamee;

                    string CanBeKilledByStuff = comboBox1.Text;
                    string CanBeKilledByLifeEraser = comboBox2.Text;
                    string CanAttackBuildings = comboBox3.Text;
                    string Unit = comboBox4.Text;
                    string CanBeMovedByPowers = comboBox5.Text;
                    string CanBeHurtByPowers = comboBox6.Text;
                    string CanTurnIntoZombie = comboBox7.Text;

                    string ActorSize = comboBox12.Text;
                    string CanBeInspected = comboBox13.Text;
                    string HideOnMinimap = comboBox14.Text;
                    string UseItems = comboBox15.Text;
                    string TakeItems = comboBox16.Text;
                    string NeedFood = comboBox17.Text;
                    string DietMeat = comboBox18.Text;
                    string InspectHome = comboBox19.Text;
                    string DisableJumpAnimation = comboBox20.Text;
                    string DeathAnimationAngle = comboBox21.Text;

                    string HasSoul = comboBox22.Text;
                    string SwampCreature = comboBox23.Text;
                    string OceanCreature = comboBox24.Text;
                    string LandCreature = comboBox25.Text;
                    string CanTurnIntoDemonInAgeOfChaos = comboBox26.Text;
                    string CanTurnIntoIceOne = comboBox27.Text;
                    string CanTurnIntoTumorMonster = comboBox28.Text;
                    string CanTurnIntoMush = comboBox29.Text;
                    string Job = comboBox30.Text;

                    string DieInLava = comboBox31.Text;
                    string DieOnBlocks = comboBox32.Text;
                    string DieOnGround = comboBox33.Text;
                    string DieByLightning = comboBox34.Text;
                    string DamagedByOcean = comboBox35.Text;
                    string DamagedByRain = comboBox36.Text;
                    string Flying = comboBox37.Text;
                    string VeryHighFlyer = comboBox38.Text;

                    string HideFavoriteIcon = comboBox41.Text;
                    string CanEditTraits = comboBox42.Text;
                    string CanBeKilledByDivineLight = comboBox43.Text;
                    string IgnoredByInfinityCoin = comboBox44.Text;
                    string Race = comboBox45.Text;
                    string Kingdom = comboBox46.Text;

                    string maxage = textBox3.Text;
                    string health = textBox5.Text;
                    string damage = textBox6.Text;
                    string speed = textBox7.Text;
                    string armor = textBox8.Text;
                    string attackspeed = textBox9.Text;
                    string criticalchance = textBox10.Text;
                    string knockback = textBox11.Text;
                    string knockbackreduction = textBox12.Text;
                    string accuracy = textBox13.Text;
                    string range = textBox14.Text;
                    string targets = textBox15.Text;
                    string dodge = textBox16.Text;

                    string swimspritess = string.Join(",", Program.SwimName);
                    string walkspritess = string.Join(",", Program.WalkName);
                    string traitschoosed = string.Join(Environment.NewLine, TraitUnits);
                    string spellschoosed = string.Join(",", SpellUnits.Select(s => "\"" + s + "\""));
                    string IconName = Path.GetFileNameWithoutExtension(pictureBox3.ImageLocation);

                    string unitcode0 = $"        create_{TrueUnitName}();\n" +
                    " \n" +
                    $"        NameGeneratorAsset {TrueUnitName}Name = new NameGeneratorAsset();\n" +
                    $"        {TrueUnitName}Name.id = \"{TrueUnitName}\";\n" +
                    $"        {TrueUnitName}Name.part_groups.Add(\"{TrueUnitName}\");\n" +
                    $"        {TrueUnitName}Name.templates.Add(\"part_group\");\n" +
                    $"        AssetManager.nameGenerator.add({TrueUnitName}Name);\n" +
                    " \n";

                    string unitcode1 = $"         public static void create_{TrueUnitName}()\n" +
                    "          {\n" +
                    $"            var {TrueUnitName} = AssetManager.actor_library.clone(\"{TrueUnitName}\", \"_mob\");\n" +
                    $"            {TrueUnitName}.nameLocale = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.nameTemplate = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.job = \"{Job}\";\n" +
                    $"            {TrueUnitName}.race = \"{Race}\";\n" +
                    $"            {TrueUnitName}.kingdom = \"{Kingdom}\";\n" +
                    $"            {TrueUnitName}.skeletonID = \"skeleton_cursed\";\n" +
                    $"            {TrueUnitName}.zombieID = \"zombie\";\n" +
                    $"            {TrueUnitName}.icon = \"{IconName}\";\n" +
                    $"            {TrueUnitName}.animation_swim = \"{swimspritess}\";\n" +
                    $"            {TrueUnitName}.animation_walk = \"{walkspritess}\";\n" +
                    $"            {TrueUnitName}.texture_path = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.run_to_water_when_on_fire = true;\n" +
                    $"            {TrueUnitName}.canBeKilledByStuff = {CanBeKilledByStuff};\n" +
                    $"            {TrueUnitName}.canBeKilledByLifeEraser = {CanBeKilledByLifeEraser};\n" +
                    $"            {TrueUnitName}.canAttackBuildings = {CanAttackBuildings};\n" +
                    $"            {TrueUnitName}.canBeMovedByPowers = {CanBeMovedByPowers};\n" +
                    $"            {TrueUnitName}.canBeHurtByPowers = {CanBeHurtByPowers};\n" +
                    $"            {TrueUnitName}.canTurnIntoZombie = {CanTurnIntoZombie};\n" +
                    $"            {TrueUnitName}.canBeInspected = {CanBeInspected};\n" +
                    $"            {TrueUnitName}.hideOnMinimap = {HideOnMinimap};\n" +
                    $"            {TrueUnitName}.use_items = {UseItems};\n" +
                    $"            {TrueUnitName}.take_items = {TakeItems};\n" +
                    $"            {TrueUnitName}.needFood = {NeedFood};\n" +
                    $"            {TrueUnitName}.diet_meat = {DietMeat};\n" +
                    $"            {TrueUnitName}.inspect_home = {InspectHome};\n" +
                    $"            {TrueUnitName}.disableJumpAnimation = {DisableJumpAnimation};\n" +
                    $"            {TrueUnitName}.has_soul = {HasSoul};\n" +
                    $"            {TrueUnitName}.swampCreature = {SwampCreature};\n" +
                    $"            {TrueUnitName}.oceanCreature = {OceanCreature};\n" +
                    $"            {TrueUnitName}.landCreature = {LandCreature};\n" +
                    $"            {TrueUnitName}.can_turn_into_demon_in_age_of_chaos = {CanTurnIntoDemonInAgeOfChaos};\n" +
                    $"            {TrueUnitName}.canTurnIntoIceOne = {CanTurnIntoIceOne};\n" +
                    $"            {TrueUnitName}.canTurnIntoTumorMonster = {CanTurnIntoTumorMonster};\n" +
                    $"            {TrueUnitName}.canTurnIntoMush = {CanTurnIntoMush};\n" +
                    $"            {TrueUnitName}.dieInLava = {DieInLava};\n" +
                    $"            {TrueUnitName}.dieOnBlocks = {DieOnBlocks};\n" +
                    $"            {TrueUnitName}.dieOnGround = {DieOnGround};\n" +
                    $"            {TrueUnitName}.dieByLightning = {DieByLightning};\n" +
                    $"            {TrueUnitName}.damagedByOcean = {DamagedByOcean};\n" +
                    $"            {TrueUnitName}.damagedByRain = {DamagedByRain};\n" +
                    $"            {TrueUnitName}.flying = {Flying};\n" +
                    $"            {TrueUnitName}.very_high_flyer = {VeryHighFlyer};\n" +
                    $"            {TrueUnitName}.hideFavoriteIcon = {HideFavoriteIcon};\n" +
                    $"            {TrueUnitName}.can_edit_traits = {CanEditTraits};\n" +
                    $"            {TrueUnitName}.canBeKilledByDivineLight = {CanBeKilledByDivineLight};\n" +
                    $"            {TrueUnitName}.ignoredByInfinityCoin = {IgnoredByInfinityCoin};\n" +
                    $"            {TrueUnitName}.actorSize = ActorSize.{ActorSize};\n" +
                    $"            {TrueUnitName}.attack_spells = List.Of<string>(new string[]{{{spellschoosed}}});\n" +
                    $"            {TrueUnitName}.action_liquid = new WorldAction(ActionLibrary.swimToIsland);\n" +
                    $"            {TrueUnitName}.base_stats[S.max_age] = {maxage}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.health] = {health};\n" +
                    $"            {TrueUnitName}.base_stats[S.damage] = {damage};\n" +
                    $"            {TrueUnitName}.base_stats[S.speed] = {speed}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.armor] = {armor};\n" +
                    $"            {TrueUnitName}.base_stats[S.attack_speed] = {attackspeed};\n" +
                    $"            {TrueUnitName}.base_stats[S.critical_chance] = {criticalchance}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.knockback] = {knockback}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.knockback_reduction] = {knockbackreduction}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.accuracy] = {accuracy}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.range] = {range};\n" +
                    $"            {TrueUnitName}.base_stats[S.targets] = {targets}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.dodge] = {dodge}f;\n" +
                    $"            AssetManager.actor_library.add({TrueUnitName});\n" +
                    $"            AssetManager.actor_library.CallMethod(\"loadShadow\", {TrueUnitName});\n" +
                    $"{traitschoosed}\n" +
                    $"            Localization.addLocalization({TrueUnitName}.nameLocale, {TrueUnitName}.nameLocale);\n" +
                    "          }\n";

                    if (Program.UnitCode0.Contains(unitcode0))
                    {
                        int count = 1;
                        string tempName = $"{unitcode0}{count}";

                        while (Program.UnitCode0.Contains(tempName))
                        {
                            count++;
                            tempName = $"{unitcode0}_{count}";
                        }

                        unitcode0 = tempName;
                    }

                    if (Program.UnitCode1.Contains(unitcode1))
                    {
                        int count = 1;
                        string tempName = $"{unitcode1}{count}";

                        while (Program.UnitCode1.Contains(tempName))
                        {
                            count++;
                            tempName = $"{unitcode1}_{count}";
                        }

                        unitcode1 = tempName;
                    }

                    string UnitIconName = Path.GetFileName(pictureBox3.ImageLocation);
                    Program.UnitIconNameList.Add(UnitIconName);
                    string uniticonBase64;
                    using (MemoryStream uniticonsave = new MemoryStream())
                    {
                        pictureBox3.Image.Save(uniticonsave, ImageFormat.Png);
                        uniticonBase64 = Convert.ToBase64String(uniticonsave.ToArray());
                    }
                    Program.UnitIcon.Add(uniticonBase64);

                    string unitfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\actors\";
                    string actorfoldername = $"{TrueUnitName}";
                    string createactorfolder = unitfolder + actorfoldername;
                    Directory.CreateDirectory(createactorfolder);

                    if (Program.SwimSprite != null && Program.SwimSprite.Count > 0)
                    {
                        for (int i = 0; i < Program.SwimSprite.Count; i++)
                        {
                            string iconunitunitBase64 = Program.SwimSprite[i];
                            byte[] imagemBytesUnit = Convert.FromBase64String(iconunitunitBase64);

                            string iconUnitFilePath = Path.Combine(createactorfolder, Path.GetFileName(Program.SwimNameList[i]));
                            File.WriteAllBytes(iconUnitFilePath, imagemBytesUnit);
                        }
                    }

                    if (Program.WalkSprite != null && Program.WalkSprite.Count > 0)
                    {
                        for (int i = 0; i < Program.WalkSprite.Count; i++)
                        {
                            string iconunitunitBase64 = Program.WalkSprite[i];
                            byte[] imagemBytesUnit = Convert.FromBase64String(iconunitunitBase64);

                            string iconUnitFilePath = Path.Combine(createactorfolder, Path.GetFileName(Program.WalkNameList[i]));
                            File.WriteAllBytes(iconUnitFilePath, imagemBytesUnit);
                        }
                    }

                    Program.UnitCode0.Add(unitcode0);
                    Program.UnitCode1.Add(unitcode1);
                    Program.UnitName.Add(TrueUnitName);

                    MessageBox.Show("The Unit Were Successfully Saved!");

                    textBox1.Clear();
                    textBox3.Text = "1";
                    textBox5.Text = "1";
                    textBox6.Text = "1";
                    textBox7.Text = "1";
                    textBox8.Text = "1";
                    textBox9.Text = "1";
                    textBox10.Text = "0.1";
                    textBox11.Text = "0.1";
                    textBox12.Text = "0.1";
                    textBox13.Text = "1";
                    textBox14.Text = "1";
                    textBox15.Text = "1";
                    textBox16.Text = "1";

                    comboBox53.Text = string.Empty;
                    pictureBox3.Image.Dispose();
                    pictureBox3.Image = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;

                    TraitUnits.Clear();
                    SpellUnits.Clear();
                    Program.SwimName.Clear();
                    Program.WalkName.Clear();
                    Program.SwimCounter = 0;
                    Program.WalkCounter = 0;
                }
                else if (radioButton2.Checked)
                {
                    string NewUnitName = textBox1.Text;
                    string[] NewUnitNamee;
                    string NewNewUnitNamee = NewUnitName;
                    if (NewUnitName.Contains(" "))
                    {
                        NewUnitNamee = NewUnitName.Split(' ');
                        NewNewUnitNamee = NewUnitNamee[0] + NewUnitNamee[1];

                    }
                    string TrueUnitName = NewNewUnitNamee;

                    string CanBeKilledByStuff = comboBox1.Text;
                    string CanBeKilledByLifeEraser = comboBox2.Text;
                    string CanAttackBuildings = comboBox3.Text;
                    string Unit = comboBox4.Text;
                    string CanBeMovedByPowers = comboBox5.Text;
                    string CanBeHurtByPowers = comboBox6.Text;
                    string CanTurnIntoZombie = comboBox7.Text;

                    string ActorSize = comboBox12.Text;
                    string CanBeInspected = comboBox13.Text;
                    string HideOnMinimap = comboBox14.Text;
                    string UseItems = comboBox15.Text;
                    string TakeItems = comboBox16.Text;
                    string NeedFood = comboBox17.Text;
                    string DietMeat = comboBox18.Text;
                    string InspectHome = comboBox19.Text;
                    string DisableJumpAnimation = comboBox20.Text;
                    string DeathAnimationAngle = comboBox21.Text;

                    string HasSoul = comboBox22.Text;
                    string SwampCreature = comboBox23.Text;
                    string OceanCreature = comboBox24.Text;
                    string LandCreature = comboBox25.Text;
                    string CanTurnIntoDemonInAgeOfChaos = comboBox26.Text;
                    string CanTurnIntoIceOne = comboBox27.Text;
                    string CanTurnIntoTumorMonster = comboBox28.Text;
                    string CanTurnIntoMush = comboBox29.Text;
                    string Job = comboBox30.Text;

                    string DieInLava = comboBox31.Text;
                    string DieOnBlocks = comboBox32.Text;
                    string DieOnGround = comboBox33.Text;
                    string DieByLightning = comboBox34.Text;
                    string DamagedByOcean = comboBox35.Text;
                    string DamagedByRain = comboBox36.Text;
                    string Flying = comboBox37.Text;
                    string VeryHighFlyer = comboBox38.Text;

                    string HideFavoriteIcon = comboBox41.Text;
                    string CanEditTraits = comboBox42.Text;
                    string CanBeKilledByDivineLight = comboBox43.Text;
                    string IgnoredByInfinityCoin = comboBox44.Text;
                    string Race = comboBox45.Text;
                    string Kingdom = comboBox46.Text;

                    string maxage = textBox3.Text;
                    string health = textBox5.Text;
                    string damage = textBox6.Text;
                    string speed = textBox7.Text;
                    string armor = textBox8.Text;
                    string attackspeed = textBox9.Text;
                    string criticalchance = textBox10.Text;
                    string knockback = textBox11.Text;
                    string knockbackreduction = textBox12.Text;
                    string accuracy = textBox13.Text;
                    string range = textBox14.Text;
                    string targets = textBox15.Text;
                    string dodge = textBox16.Text;

                    string swimspritess = string.Join(",", Program.SwimName);
                    string walkspritess = string.Join(",", Program.WalkName);
                    string traitschoosed = string.Join(Environment.NewLine, TraitUnits);
                    string IconName = Path.GetFileNameWithoutExtension(pictureBox3.ImageLocation);

                    string unitcode0 = $"        create_{TrueUnitName}();\n" +
                    " \n" +
                    $"        NameGeneratorAsset {TrueUnitName}Name = new NameGeneratorAsset();\n" +
                    $"        {TrueUnitName}Name.id = \"{TrueUnitName}\";\n" +
                    $"        {TrueUnitName}Name.part_groups.Add(\"{TrueUnitName}\");\n" +
                    $"        {TrueUnitName}Name.templates.Add(\"part_group\");\n" +
                    $"        AssetManager.nameGenerator.add({TrueUnitName}Name);\n";

                    string unitcode1 = $"         public static void create_{TrueUnitName}()\n" +
                    "          {\n" +
                    $"            var {TrueUnitName} = AssetManager.actor_library.clone(\"{TrueUnitName}\", \"_mob\");\n" +
                    $"            {TrueUnitName}.nameLocale = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.nameTemplate = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.job = \"{Job}\";\n" +
                    $"            {TrueUnitName}.race = \"{Race}\";\n" +
                    $"            {TrueUnitName}.kingdom = \"{Kingdom}\";\n" +
                    $"            {TrueUnitName}.skeletonID = \"skeleton_cursed\";\n" +
                    $"            {TrueUnitName}.zombieID = \"zombie\";\n" +
                    $"            {TrueUnitName}.icon = \"{IconName}\";\n" +
                    $"            {TrueUnitName}.animation_swim = \"{swimspritess}\";\n" +
                    $"            {TrueUnitName}.animation_walk = \"{walkspritess}\";\n" +
                    $"            {TrueUnitName}.texture_path = \"{TrueUnitName}\";\n" +
                    $"            {TrueUnitName}.run_to_water_when_on_fire = true;\n" +
                    $"            {TrueUnitName}.canBeKilledByStuff = {CanBeKilledByStuff};\n" +
                    $"            {TrueUnitName}.canBeKilledByLifeEraser = {CanBeKilledByLifeEraser};\n" +
                    $"            {TrueUnitName}.canAttackBuildings = {CanAttackBuildings};\n" +
                    $"            {TrueUnitName}.canBeMovedByPowers = {CanBeMovedByPowers};\n" +
                    $"            {TrueUnitName}.canBeHurtByPowers = {CanBeHurtByPowers};\n" +
                    $"            {TrueUnitName}.canTurnIntoZombie = {CanTurnIntoZombie};\n" +
                    $"            {TrueUnitName}.canBeInspected = {CanBeInspected};\n" +
                    $"            {TrueUnitName}.hideOnMinimap = {HideOnMinimap};\n" +
                    $"            {TrueUnitName}.use_items = {UseItems};\n" +
                    $"            {TrueUnitName}.take_items = {TakeItems};\n" +
                    $"            {TrueUnitName}.needFood = {NeedFood};\n" +
                    $"            {TrueUnitName}.diet_meat = {DietMeat};\n" +
                    $"            {TrueUnitName}.inspect_home = {InspectHome};\n" +
                    $"            {TrueUnitName}.disableJumpAnimation = {DisableJumpAnimation};\n" +
                    $"            {TrueUnitName}.has_soul = {HasSoul};\n" +
                    $"            {TrueUnitName}.swampCreature = {SwampCreature};\n" +
                    $"            {TrueUnitName}.oceanCreature = {OceanCreature};\n" +
                    $"            {TrueUnitName}.landCreature = {LandCreature};\n" +
                    $"            {TrueUnitName}.can_turn_into_demon_in_age_of_chaos = {CanTurnIntoDemonInAgeOfChaos};\n" +
                    $"            {TrueUnitName}.canTurnIntoIceOne = {CanTurnIntoIceOne};\n" +
                    $"            {TrueUnitName}.canTurnIntoTumorMonster = {CanTurnIntoTumorMonster};\n" +
                    $"            {TrueUnitName}.canTurnIntoMush = {CanTurnIntoMush};\n" +
                    $"            {TrueUnitName}.dieInLava = {DieInLava};\n" +
                    $"            {TrueUnitName}.dieOnBlocks = {DieOnBlocks};\n" +
                    $"            {TrueUnitName}.dieOnGround = {DieOnGround};\n" +
                    $"            {TrueUnitName}.dieByLightning = {DieByLightning};\n" +
                    $"            {TrueUnitName}.damagedByOcean = {DamagedByOcean};\n" +
                    $"            {TrueUnitName}.damagedByRain = {DamagedByRain};\n" +
                    $"            {TrueUnitName}.flying = {Flying};\n" +
                    $"            {TrueUnitName}.very_high_flyer = {VeryHighFlyer};\n" +
                    $"            {TrueUnitName}.hideFavoriteIcon = {HideFavoriteIcon};\n" +
                    $"            {TrueUnitName}.can_edit_traits = {CanEditTraits};\n" +
                    $"            {TrueUnitName}.canBeKilledByDivineLight = {CanBeKilledByDivineLight};\n" +
                    $"            {TrueUnitName}.ignoredByInfinityCoin = {IgnoredByInfinityCoin};\n" +
                    $"            {TrueUnitName}.actorSize = ActorSize.{ActorSize};\n" +
                    $"            {TrueUnitName}.action_liquid = new WorldAction(ActionLibrary.swimToIsland);\n" +
                    $"            {TrueUnitName}.base_stats[S.max_age] = {maxage}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.health] = {health};\n" +
                    $"            {TrueUnitName}.base_stats[S.damage] = {damage};\n" +
                    $"            {TrueUnitName}.base_stats[S.speed] = {speed}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.armor] = {armor};\n" +
                    $"            {TrueUnitName}.base_stats[S.attack_speed] = {attackspeed};\n" +
                    $"            {TrueUnitName}.base_stats[S.critical_chance] = {criticalchance}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.knockback] = {knockback}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.knockback_reduction] = {knockbackreduction}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.accuracy] = {accuracy}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.range] = {range};\n" +
                    $"            {TrueUnitName}.base_stats[S.targets] = {targets}f;\n" +
                    $"            {TrueUnitName}.base_stats[S.dodge] = {dodge}f;\n" +
                    $"            AssetManager.actor_library.add({TrueUnitName});\n" +
                    $"            AssetManager.actor_library.CallMethod(\"loadShadow\", {TrueUnitName});\n" +
                    $"{traitschoosed}\n" +
                    $"            Localization.addLocalization({TrueUnitName}.nameLocale, {TrueUnitName}.nameLocale);\n" +
                    "          }\n";

                    if (Program.UnitCode0.Contains(unitcode0))
                    {
                        int count = 1;
                        string tempName = $"{unitcode0}{count}";

                        while (Program.UnitCode0.Contains(tempName))
                        {
                            count++;
                            tempName = $"{unitcode0}_{count}";
                        }

                        unitcode0 = tempName;
                    }

                    if (Program.UnitCode1.Contains(unitcode1))
                    {
                        int count = 1;
                        string tempName = $"{unitcode1}{count}";

                        while (Program.UnitCode1.Contains(tempName))
                        {
                            count++;
                            tempName = $"{unitcode1}_{count}";
                        }

                        unitcode1 = tempName;
                    }

                    string UnitIconName = pictureBox3.ImageLocation;
                    Program.UnitIconNameList.Add(UnitIconName);
                    string uniticonBase64;
                    using (MemoryStream uniticonsave = new MemoryStream())
                    {
                        pictureBox3.Image.Save(uniticonsave, ImageFormat.Png);
                        uniticonBase64 = Convert.ToBase64String(uniticonsave.ToArray());
                    }
                    Program.UnitIcon.Add(uniticonBase64);

                    string unitfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Mod Maker Recycle Bin\actors\";
                    string actorfoldername = $"{TrueUnitName}";
                    string createactorfolder = unitfolder + actorfoldername;
                    Directory.CreateDirectory(createactorfolder);

                    if (Program.SwimSprite != null && Program.SwimSprite.Count > 0)
                    {
                        for (int i = 0; i < Program.SwimSprite.Count; i++)
                        {
                            string iconunitunitBase64 = Program.SwimSprite[i];
                            byte[] imagemBytesUnit = Convert.FromBase64String(iconunitunitBase64);

                            string iconUnitFilePath = Path.Combine(createactorfolder, Path.GetFileName(Program.SwimNameList[i]));
                            File.WriteAllBytes(iconUnitFilePath, imagemBytesUnit);
                        }
                    }

                    if (Program.WalkSprite != null && Program.WalkSprite.Count > 0)
                    {
                        for (int i = 0; i < Program.WalkSprite.Count; i++)
                        {
                            string iconunitunitBase64 = Program.WalkSprite[i];
                            byte[] imagemBytesUnit = Convert.FromBase64String(iconunitunitBase64);

                            string iconUnitFilePath = Path.Combine(createactorfolder, Path.GetFileName(Program.WalkNameList[i]));
                            File.WriteAllBytes(iconUnitFilePath, imagemBytesUnit);
                        }
                    }

                    Program.UnitCode0.Add(unitcode0);
                    Program.UnitCode1.Add(unitcode1);
                    Program.UnitName.Add(TrueUnitName);

                    MessageBox.Show("The Unit Were Successfully Saved!");

                    textBox1.Clear();
                    textBox3.Text = "1";
                    textBox5.Text = "1";
                    textBox6.Text = "1";
                    textBox7.Text = "1";
                    textBox8.Text = "1";
                    textBox9.Text = "1";
                    textBox10.Text = "0.1";
                    textBox11.Text = "0.1";
                    textBox12.Text = "0.1";
                    textBox13.Text = "1";
                    textBox14.Text = "1";
                    textBox15.Text = "1";
                    textBox16.Text = "1";

                    comboBox53.Text = string.Empty;
                    pictureBox3.Image.Dispose();
                    pictureBox3.Image = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;

                    TraitUnits.Clear();
                    SpellUnits.Clear();
                    Program.SwimName.Clear();
                    Program.WalkName.Clear();
                    Program.SwimCounter = 0;
                    Program.WalkCounter = 0;
                }
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        #endregion

        #region radionbuttons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label46.Enabled = true;
            comboBox52.Enabled = true;
            button10.Enabled = true;

            label46.Visible = true;
            comboBox52.Visible = true;
            button10.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label46.Enabled = false;
            comboBox52.Enabled = false;
            button10.Enabled = false;

            label46.Visible = false;
            comboBox52.Visible = false;
            button10.Visible = false;
        }
        #endregion

        #region buttons
        private void button10_Click(object sender, EventArgs e)
        {
            
            if (comboBox52.Text == "")
            {
                MessageBox.Show("Choose a Spell First!");
            }
            else
            {
                string spellchoosed = comboBox52.Text;
                SpellUnits.Add(spellchoosed);
                MessageBox.Show("Spell Choosed Save Successfully!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Custom Icon";
                openFileDialog.Filter = "Images (*.png)|*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathImage = openFileDialog.FileName;
                    pictureBox3.Image = Image.FromFile(pathImage);
                    pictureBox3.ImageLocation = openFileDialog.FileName;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                    string fileName = Path.GetFileName(pathImage);
                    comboBox53.Text = fileName;
                }
            }
        }
        #endregion

        #region imagestopicturebox
        private void comboBox47_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox47.Text == "swim_0")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "swim_0" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox47.Text == "swim_1")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "swim_1" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox47.Text == "swim_2")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "swim_2" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox47.Text == "swim_3")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox1.ImageLocation = Path.Combine(diretorioWeaponsImagens, "swim_3" + ".png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox47.Text == "")
            {
                pictureBox1.Image = null;
            }
        }

        private void comboBox48_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox48.Text == "walk_0")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "walk_0" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox48.Text == "walk_1")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "walk_1" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox48.Text == "walk_2")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "walk_2" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox48.Text == "walk_3")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox2.ImageLocation = Path.Combine(diretorioWeaponsImagens, "walk_3" + ".png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox48.Text == "")
            {
                pictureBox2.Image = null;
            }
        }

        private void comboBox53_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox53.Text == "EdwardNewGate")
            {
                string diretorioWeaponsImagens = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bank", "Mods", "EdwardNewGate");
                pictureBox3.ImageLocation = Path.Combine(diretorioWeaponsImagens, "iconedwardnewgate" + ".png");
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox53.Text == "")
            {
                pictureBox3.Image = null;
            }
        }
        #endregion
    }
}