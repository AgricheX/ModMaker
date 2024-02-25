using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod_Maker
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InicialMenu());
        }
        #region utils
        public static void CreateModMakerRecicleBin()
        {
            string DownloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
            string NewFolders = "Mod Maker Recycle Bin";
            string NewFolder2 = DownloadsPath + NewFolders;
            string actorsfolder = "actors";
            string effectsfolder = "effects";
            string projectilesfolder = "projectiles";
            string creationactorsFolder = Path.Combine(NewFolder2, actorsfolder);
            string creationeffectsfolder = Path.Combine(NewFolder2, effectsfolder);
            string creationprojectilesfolder = Path.Combine(creationeffectsfolder, projectilesfolder);

            if (!Directory.Exists(NewFolder2))
            {
                Directory.CreateDirectory(NewFolder2);
            }
            if (!Directory.Exists(creationactorsFolder))
            {
                Directory.CreateDirectory(creationactorsFolder);

            }
            if (!Directory.Exists(creationeffectsfolder))
            {
                Directory.CreateDirectory(creationeffectsfolder);

            }
            if (!Directory.Exists(creationprojectilesfolder))
            {
                Directory.CreateDirectory(creationprojectilesfolder);

            }
        }

        public static void DeleteModMakerRecycleBin()
        {
            string downloadsPaths = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
            string newFolders = "Mod Maker Recycle Bin";
            string newFolders2 = downloadsPaths + newFolders;
            Directory.Delete(newFolders2, true);
        }
        #endregion

        #region modinfo

        #region maininfos
        public static List<string> ModsIcon { get; set; } = new List<string>();
        #endregion

        #region traits
        public static List<string> TraitsName { get; set; } = new List<string>();
        public static List<string> TraitsValue { get; set; } = new List<string>();
        public static List<string> TraitsCode { get; set; } = new List<string>();
        public static List<string> TraitsIcon { get; set; } = new List<string>();
        public static List<string> TraitsIconNameList { get; set; } = new List<string>();
        #endregion

        #region traitsgroup
        public static List<string> TraitGroupName { get; set; } = new List<string>();
        public static List<string> TraitGroupCode { get; set; } = new List<string>();
        public static List<string> TraitGroupValues { get; set; } = new List<string>();
        public static List<string> TraitGroupTypesFile { get; set; } = new List<string>();
        #endregion

        #region weapons
        public static List<string> WeaponIcon { get; set; } = new List<string>();
        public static List<string> WeaponIconNameList { get; set; } = new List<string>();
        public static List<string> WeaponSprite { get; set; } = new List<string>();
        public static List<string> WeaponSpriteNameList { get; set; } = new List<string>();
        public static List<string> WeaponCode { get; set; } = new List<string>();
        public static List<string> WeaponCode2 { get; set; } = new List<string>();
        #endregion

        #region items
        public static List<string> ItemIcon { get; set; } = new List<string>();
        public static List<string> ItemIconNameList { get; set; } = new List<string>();
        public static List<string> Itemcode { get; set; } = new List<string>();
        public static List<string> Itemcode2 { get; set; } = new List<string>();
        #endregion

        #region actions
        public static List<string> ActionBank { get; set; } = new List<string>();
        public static List<string> ActionBank2 { get; set; } = new List<string>();
        public static List<string> Action1 { get; set; } = new List<string>();
        public static List<string> Action2 { get; set; } = new List<string>();
        public static List<string> Action3 { get; set; } = new List<string>();
        public static List<string> Action4 { get; set; } = new List<string>();
        #endregion

        #region invasions
        public static List<string> InvasionsCode { get; set; } = new List<string>();
        public static List<string> InvasionsIcon { get; set; } = new List<string>();
        public static List<string> InvasionsIconNameList { get; set; } = new List<string>();
        public static List<string> InvasionsName { get; set; } = new List<string>();
        #endregion

        #region tab
        public static List<string> TabCode { get; set; } = new List<string>();
        public static List<string> TabCode0 { get; set; } = new List<string>();
        public static List<string> TabCode1 { get; set; } = new List<string>();
        public static List<string> TabCode2 { get; set; } = new List<string>();
        public static List<string> TabCreator { get; set; } = new List<string>();
        public static List<string> TabIconNameList { get; set; } = new List<string>();
        public static List<string> TabIcon { get; set; } = new List<string>();
        public static List<string> TabDescription { get; set; } = new List<string>();
        #endregion

        #region tabbuttons
        public static int ButtonCounter { get; set; } = 72;
        public static int[] ButtonIncrements { get; set; } = { 36, 36, 72, 38, 36, 36, 36, 36, 38, 36, 36, 36, 36, 72, 38, 36, 36, 36, 36, 38, 36, 36 };
        public static int ButtonIndex { get; set; } = 0;
        public static string Position2 { get; set; } = "-18";
        public static int ButtonPositionCounter { get; set; } = 0;

        public static List<string> UnitButtonCode { get; set; } = new List<string>();
        public static List<string> UnitButtonIconNameList { get; set; } = new List<string>();
        public static List<string> UnitButtonIcon { get; set; } = new List<string>();
        #endregion

        #region kingdomstag
        public static List<string> KingdomTagCode { get; set; } = new List<string>();
        public static List<string> KingdomTagName { get; set; } = new List<string>();
        public static List<string> KingdomTagTrueName { get; set; } = new List<string>();
        #endregion

        #region units
        public static List<string> SwimSprite { get; set; } = new List<string>();
        public static List<string> SwimNameList { get; set; } = new List<string>();
        public static List<string> SwimName { get; set; } = new List<string>();
        public static List<string> WalkSprite { get; set; } = new List<string>();
        public static List<string> WalkNameList { get; set; } = new List<string>();
        public static List<string> WalkName { get; set; } = new List<string>();
        public static List<string> UnitIcon { get; set; } = new List<string>();
        public static List<string> UnitIconNameList { get; set; } = new List<string>();
        public static List<string> UnitCode0 { get; set; } = new List<string>();
        public static List<string> UnitCode1 { get; set; } = new List<string>();
        public static List<string> UnitName { get; set; } = new List<string>();
        #endregion

        #region projectiles
        public static List<string> ProjectileCode { get; set; } = new List<string>();
        public static List<string> ProjectileIcon { get; set; } = new List<string>();
        public static List<string> ProjectileIconNameList { get; set; } = new List<string>();
        public static List<string> ProjectileName { get; set; } = new List<string>();
        #endregion

        #endregion
    }
}