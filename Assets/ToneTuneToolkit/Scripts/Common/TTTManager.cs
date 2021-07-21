using UnityEngine;
using System.IO;

namespace ToneTuneToolkit
{
    /// <summary>
    /// OK
    /// MANAGER!
    /// </summary>
    [RequireComponent(typeof(TTTTipTools))]
    [RequireComponent(typeof(TextReader))]
    public class TTTManager : MonoBehaviour
    {
        #region Paths
        private static string MainPath = Application.streamingAssetsPath + "/ToneTuneToolkit/";
        public static string ConfigsPath = MainPath + "/configs/";
        public static string DataPath = MainPath + "/data/";
        #endregion

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            FolderIntegrityCheck(MainPath);
            FolderIntegrityCheck(ConfigsPath);
            FolderIntegrityCheck(DataPath);
        }

        /// <summary>
        /// 文件夹完整性检查
        /// </summary>
        /// <param name="url"></param>
        public static bool FolderIntegrityCheck(string url)
        {
            if (File.Exists(url))
            {
                return true;
            }
            Directory.CreateDirectory(url);
            return false;
        }

        /// <summary>
        /// 文件完整性检查
        /// </summary>
        /// <param name="url"></param>
        public static bool FileIntegrityCheck(string url)
        {
            if (File.Exists(url))
            {
                return true;
            }
            FileInfo fi = new FileInfo(url);
            StreamWriter sw = fi.CreateText();
            sw.Close();
            sw.Dispose();
            return false;
        }
    }
}