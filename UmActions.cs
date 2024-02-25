using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod_Maker
{
    public partial class UmActions : Form
    {
        #region InitializeComponent
        public UmActions()
        {
            InitializeComponent();
        }
        #endregion

        #region powers
        private string Powers(string action)
        {
            string power = " ";

            if (action == "NoneAction")
            {
                power += " ";
            }
            else if (action == "Spawn Napalm Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_napalm_flash\", pTile, null, null, 0f, -1f, -1f);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_tiny\", pTile, 0.15f, 0.3f);\n";
            }
            else if (action == "Spawn AntiMatter Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_antimatter_effect\", pTile, null, null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Atomic Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_nuke_flash\", pTile, \"atomicBomb\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Czar Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_nuke_flash\", pTile, \"czarBomba\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Grenade")
            {
                power += "MapAction.damageWorld(pTile, 5, AssetManager.terraform.get(\"grenade\"), null);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_small\", pTile, 0.1f, 0.15f);\n";
            }
            else if (action == "Spawn Bomb")
            {
                power += "EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_middle\", pTile, 0.45f, 0.6f);\n" +
                    "        MapAction.damageWorld(pTile, 10, AssetManager.terraform.get(\"bomb\"), null);\n";
            }
            else if (action == "Spawn Santa Bomb")
            {
                power += "MapAction.damageWorld(pTile, 10, AssetManager.terraform.get(\"santa_bomb\"), null);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_small\", pTile, 0.45f, 0.6f);\n";
            }
            else if (action == "Spawn Apply Force")
            {
                power += "World.world.applyForce(pTile, 3, 0.3f, true, true, 0, null, pTarget, null);\n";
            }
            else if (action == "Spawn Blood Rain")
            {
                power += "World.world.dropManager.spawn(pTile, \"bloodRain\", 15f, -1f);\n";
            }
            else if (action == "Spawn Curse")
            {
                power += "World.world.dropManager.spawn(pTile, \"curse\", 15f, -1f);\n";
            }
            else if (action == "Spawn Cure")
            {
                power += "World.world.dropManager.spawn(pTile, \"cure\", 15f, -1f);\n";
            }
            else if (action == "Spawn Shake")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n";
            }
            else if (action == "Spawn Earthquake")
            {
                power += "World.world.earthquakeManager.startQuake(pTile, EarthquakeType.RandomPower);\n";
            }
            else if (action == "Spawn Meteorite")
            {
                power += "EffectsLibrary.spawn(\"fx_meteorite\", pTarget.currentTile, \"meteorite_disaster\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Explosion Wave")
            {
                power += "EffectsLibrary.spawnExplosionWave(pTile.posV3, 3f, 0.5f);\n";
            }
            else if (action == "Spawn Lightning")
            {
                power += "MapBox.spawnLightningMedium(pTile, 0.15f);\n";
            }
            else if (action == "Spawn Burning Effect On Target")
            {
                power += "ActionLibrary.addBurningEffectOnTarget(null, pTarget, null);\n";
            }
            else if (action == "Spawn Fire Rain")
            {
                power += "ActionLibrary.castFire(null, pTarget, null);\n";
            }
            else if (action == "Spawn Random teleport")
            {
                power += "ActionLibrary.teleportRandom(null, pTarget, null);\n";
            }
            else if (action == "Spawn Poisoned Effect On Target")
            {
                power += "ActionLibrary.addPoisonedEffectOnTarget(null, pTarget, null);\n";
            }
            else if (action == "Spawn Tornado")
            {
                power += "ActionLibrary.castTornado(null, pTarget, null);\n";
            }
            else if (action == "Spawn Seed")
            {
                power += "DropsLibrary.useSeedOn(pTile, TopTileLibrary.grass_low, TopTileLibrary.grass_high);\n";
            }
            else if (action == "Spawn Grow Vegetation Random")
            {
                power += "BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false);\n";
            }
            else if (action == "Spawn Slowness Effect")
            {
                power += "pTarget.CallMethod(\"addStatusEffect\", \"slowness\", -1f);\n";
            }
            else if (action == "Spawn Frozen Effect")
            {
                power += "pTarget.CallMethod(\"addStatusEffect\", \"frozen\", 15f);\n";
            }
            else if (action == "Spawn Shield")
            {
                power += "pSelf.CallMethod(\"addStatusEffect\", \"shield\", 5f);";
            }

            return power;
        }

        private string GetPowers(string action)
        {
            string power = " ";

            if (action == "NoneAction")
            {
                power += " ";
            }
            else if (action == "Spawn Napalm Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_napalm_flash\", pTile, null, null, 0f, -1f, -1f);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_tiny\", pTile, 0.15f, 0.3f);\n";
            }
            else if (action == "Spawn AntiMatter Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_antimatter_effect\", pTile, null, null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Atomic Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_nuke_flash\", pTile, \"atomicBomb\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Czar Bomb")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n" +
                    "        EffectsLibrary.spawn(\"fx_nuke_flash\", pTile, \"czarBomba\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Grenade")
            {
                power += "MapAction.damageWorld(pTile, 5, AssetManager.terraform.get(\"grenade\"), null);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_small\", pTile, 0.1f, 0.15f);\n";
            }
            else if (action == "Spawn Bomb")
            {
                power += "EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_middle\", pTile, 0.45f, 0.6f);\n" +
                    "        MapAction.damageWorld(pTile, 10, AssetManager.terraform.get(\"bomb\"), null);\n";
            }
            else if (action == "Spawn Santa Bomb")
            {
                power += "MapAction.damageWorld(pTile, 10, AssetManager.terraform.get(\"santa_bomb\"), null);\n" +
                    "        EffectsLibrary.spawnAtTileRandomScale(\"fx_explosion_small\", pTile, 0.45f, 0.6f);\n";
            }
            else if (action == "Spawn Apply Force")
            {
                power += "World.world.applyForce(pTile, 3, 0.3f, true, true, 0, null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Blood Rain")
            {
                power += "World.world.dropManager.spawn(pTile, \"bloodRain\", 15f, -1f);\n";
            }
            else if (action == "Spawn Curse")
            {
                power += "World.world.dropManager.spawn(pTile, \"curse\", 15f, -1f);\n";
            }
            else if (action == "Spawn Cure")
            {
                power += "World.world.dropManager.spawn(pTile, \"cure\", 15f, -1f);\n";
            }
            else if (action == "Spawn Shake")
            {
                power += "World.world.startShake(0.3f, 0.01f, 2f, true, true);\n";
            }
            else if (action == "Spawn Earthquake")
            {
                power += "World.world.earthquakeManager.startQuake(pTile, EarthquakeType.RandomPower);\n";
            }
            else if (action == "Spawn Meteorite")
            {
                power += "EffectsLibrary.spawn(\"fx_meteorite\", pAttackedBy.currentTile, \"meteorite_disaster\", null, 0f, -1f, -1f);\n";
            }
            else if (action == "Spawn Explosion Wave")
            {
                power += "EffectsLibrary.spawnExplosionWave(pTile.posV3, 3f, 0.5f);\n";
            }
            else if (action == "Spawn Lightning")
            {
                power += "MapBox.spawnLightningMedium(pTile, 0.15f);\n";
            }
            else if (action == "Spawn Burning Effect On Target")
            {
                power += "ActionLibrary.addBurningEffectOnTarget(null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Fire Rain")
            {
                power += "ActionLibrary.castFire(null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Random teleport")
            {
                power += "ActionLibrary.teleportRandom(null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Poisoned Effect On Target")
            {
                power += "ActionLibrary.addPoisonedEffectOnTarget(null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Tornado")
            {
                power += "ActionLibrary.castTornado(null, pAttackedBy, null);\n";
            }
            else if (action == "Spawn Seed")
            {
                power += "DropsLibrary.useSeedOn(pTile, TopTileLibrary.grass_low, TopTileLibrary.grass_high);\n";
            }
            else if (action == "Spawn Grow Vegetation Random")
            {
                power += "BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false);\n";
            }
            else if (action == "Spawn Slowness Effect")
            {
                power += "pAttackedBy.CallMethod(\"addStatusEffect\", \"slowness\", -1f);\n";
            }
            else if (action == "Spawn Frozen Effect")
            {
                power += "pAttackedBy.CallMethod(\"addStatusEffect\", \"frozen\", 15f);\n";
            }
            else if (action == "Spawn Frozen Effect")
            {
                power += "pAttackedBy.CallMethod(\"addStatusEffect\", \"frozen\", 15f);\n";
            }
            else if (action == "Spawn Shield")
            {
                power += "pSelf.CallMethod(\"addStatusEffect\", \"shield\", 5f);";
            }

            return power;
        }
        #endregion

        #region createaction
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox88.Text != "" && textBox23.Text != "" && comboBox28.Text != "" && comboBox29.Text != "" && comboBox30.Text != "" && comboBox31.Text != "" && comboBox32.Text != "" && comboBox33.Text != "")
            {
                string AttackSomeoneActionName = textBox88.Text;
                string[] NewAttackSomeoneActionNamee;
                string NewNewAttackSomeoneActionNamee = AttackSomeoneActionName;
                if (AttackSomeoneActionName.Contains(" "))
                {
                    NewAttackSomeoneActionNamee = AttackSomeoneActionName.Split(' ');
                    NewNewAttackSomeoneActionNamee = NewAttackSomeoneActionNamee[0] + NewAttackSomeoneActionNamee[1];

                }
                string TrueAttackSomeoneActionName = NewNewAttackSomeoneActionNamee;

                string AttackSomeoneActionTime = textBox23.Text;
                string AttackSomeoneActionPower1 = Powers(comboBox28.Text);
                string AttackSomeoneActionPower2 = Powers(comboBox29.Text);
                string AttackSomeoneActionPower3 = Powers(comboBox30.Text);
                string AttackSomeoneActionPower4 = Powers(comboBox31.Text);
                string AttackSomeoneActionPower5 = Powers(comboBox32.Text);
                string AttackSomeoneActionPower6 = Powers(comboBox33.Text);

                string AttackSomeoneAction = " \n" +
                "        }\n" +
                $"        public static bool {TrueAttackSomeoneActionName}(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)\n" +
                "        {\n" +
                "        if(pTarget != null){\n" +
                "        Actor a = Reflection.GetField(pTarget.GetType(), pTarget, \"a\") as Actor;\n" +
                $"        if(Toolbox.randomChance({AttackSomeoneActionTime}f))" + "{\n" +
                $"        {AttackSomeoneActionPower1}\n" +
                $"        {AttackSomeoneActionPower2}\n" +
                $"        {AttackSomeoneActionPower3}\n" +
                $"        {AttackSomeoneActionPower4}\n" +
                $"        {AttackSomeoneActionPower5}\n" +
                $"        {AttackSomeoneActionPower6}\n" +
                "        }}\n" +
                "        return false;\n";

                Program.ActionBank.Add(AttackSomeoneAction);
                Program.ActionBank2.Add(AttackSomeoneAction);
                Program.Action1.Add(TrueAttackSomeoneActionName);

                MessageBox.Show("The Attack Someone Action Were Successfully Saved!");

                textBox88.Clear();
                textBox23.Text = "100.0";
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox89.Text != "" && textBox90.Text != "" && comboBox39.Text != "" && comboBox38.Text != "" && comboBox37.Text != "" && comboBox36.Text != "" && comboBox35.Text != "" && comboBox34.Text != "")
            {
                string RegularActionName = textBox89.Text;
                string[] NewRegularActionNamee;
                string NewNewRegularActionNamee = RegularActionName;
                if (RegularActionName.Contains(" "))
                {
                    NewRegularActionNamee = RegularActionName.Split(' ');
                    NewNewRegularActionNamee = NewRegularActionNamee[0] + NewRegularActionNamee[1];

                }
                string TrueRegularActionName = NewNewRegularActionNamee;

                string RegularActionTime = textBox90.Text;
                string RegularActionPower1 = Powers(comboBox39.Text);
                string RegularActionPower2 = Powers(comboBox38.Text);
                string RegularActionPower3 = Powers(comboBox37.Text);
                string RegularActionPower4 = Powers(comboBox36.Text);
                string RegularActionPower5 = Powers(comboBox35.Text);
                string RegularActionPower6 = Powers(comboBox34.Text);

                string RegularAction = " \n" +
                "        }\n" +
                $"        public static bool {TrueRegularActionName}(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                "        {\n" +
                "        Actor a = Reflection.GetField(pTarget.GetType(), pTarget, \"a\") as Actor;\n" +
                $"        if(Toolbox.randomChance({RegularActionTime}f))" + "{\n" +
                $"        {RegularActionPower1}\n" +
                $"        {RegularActionPower2}\n" +
                $"        {RegularActionPower3}\n" +
                $"        {RegularActionPower4}\n" +
                $"        {RegularActionPower5}\n" +
                $"        {RegularActionPower6}\n" +
                "        }\n" +
                "        return false;\n";

                Program.ActionBank.Add(RegularAction);
                Program.ActionBank2.Add(RegularAction);
                Program.Action2.Add(TrueRegularActionName);

                MessageBox.Show("The Regular Action Were Successfully Saved!");

                textBox89.Clear();
                textBox90.Text = "100.0";
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox91.Text != "" && textBox92.Text != "" && comboBox45.Text != "" && comboBox44.Text != "" && comboBox43.Text != "" && comboBox42.Text != "" && comboBox41.Text != "" && comboBox40.Text != "")
            {
                string GetAttackedActionName = textBox91.Text;
                string[] NewGetAttackedActionNamee;
                string NewNewGetAttackedActionNamee = GetAttackedActionName;
                if (GetAttackedActionName.Contains(" "))
                {
                    NewGetAttackedActionNamee = GetAttackedActionName.Split(' ');
                    NewNewGetAttackedActionNamee = NewGetAttackedActionNamee[0] + NewGetAttackedActionNamee[1];

                }
                string TrueGetAttackedActionName = NewNewGetAttackedActionNamee;

                string GetAttackedActionTime = textBox92.Text;
                string GetAttackedActionPower1 = GetPowers(comboBox45.Text);
                string GetAttackedActionPower2 = GetPowers(comboBox44.Text);
                string GetAttackedActionPower3 = GetPowers(comboBox43.Text);
                string GetAttackedActionPower4 = GetPowers(comboBox42.Text);
                string GetAttackedActionPower5 = GetPowers(comboBox41.Text);
                string GetAttackedActionPower6 = GetPowers(comboBox40.Text);

                string GetAttackedAction = " \n" +
                "        }\n" +
                $"        public static bool {TrueGetAttackedActionName}(BaseSimObject pSelf, BaseSimObject pAttackedBy = null, WorldTile pTile = null)\n" +
                "        {\n" +
                $"        if(Toolbox.randomChance({GetAttackedActionTime}f))" + "{\n" +
                $"        {GetAttackedActionPower1}\n" +
                $"        {GetAttackedActionPower2}\n" +
                $"        {GetAttackedActionPower3}\n" +
                $"        {GetAttackedActionPower4}\n" +
                $"        {GetAttackedActionPower5}\n" +
                $"        {GetAttackedActionPower6}\n" +
                "        }\n" +
                "        return false;\n";

                Program.ActionBank.Add(GetAttackedAction);
                Program.Action3.Add(TrueGetAttackedActionName);

                MessageBox.Show("The Get Attacked Action Were Successfully Saved!");

                textBox91.Clear();
                textBox92.Text = "100.0";
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox93.Text != "" && textBox94.Text != "" && comboBox51.Text != "" && comboBox50.Text != "" && comboBox49.Text != "" && comboBox48.Text != "" && comboBox47.Text != "" && comboBox46.Text != "")
            {
                string DeathActionName = textBox93.Text;
                string[] NewDeathActionNamee;
                string NewNewDeathActionNamee = DeathActionName;
                if (DeathActionName.Contains(" "))
                {
                    NewDeathActionNamee = DeathActionName.Split(' ');
                    NewNewDeathActionNamee = NewDeathActionNamee[0] + NewDeathActionNamee[1];

                }
                string TrueDeathActionName = NewNewDeathActionNamee;

                string DeathActionTime = textBox94.Text;
                string DeathActionPower1 = Powers(comboBox51.Text);
                string DeathActionPower2 = Powers(comboBox50.Text);
                string DeathActionPower3 = Powers(comboBox49.Text);
                string DeathActionPower4 = Powers(comboBox48.Text);
                string DeathActionPower5 = Powers(comboBox47.Text);
                string DeathActionPower6 = Powers(comboBox46.Text);

                string DeathAction = " \n" +
                "        }\n" +
                $"        public static bool {TrueDeathActionName}(BaseSimObject pTarget, WorldTile pTile = null)\n" +
                "        {\n" +
                "        Actor a = Reflection.GetField(pTarget.GetType(), pTarget, \"a\") as Actor;\n" +
                $"        if(Toolbox.randomChance({DeathActionTime}f))" + "{\n" +
                $"        {DeathActionPower1}\n" +
                $"        {DeathActionPower2}\n" +
                $"        {DeathActionPower3}\n" +
                $"        {DeathActionPower4}\n" +
                $"        {DeathActionPower5}\n" +
                $"        {DeathActionPower6}\n" +
                "        }\n" +
                "        return false;\n";

                Program.ActionBank.Add(DeathAction);
                Program.Action4.Add(TrueDeathActionName);

                MessageBox.Show("The Death Action Successfully Saved!");

                textBox93.Clear();
                textBox94.Text = "100.0";
            }
            else
            {
                MessageBox.Show("Fill in All Blanks First!");
            }
        }
        #endregion
    }
}