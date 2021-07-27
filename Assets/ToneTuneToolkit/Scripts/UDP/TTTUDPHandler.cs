using UnityEngine;

namespace ToneTuneToolkit.UDP
{
  /// <summary>
  /// OK
  /// UDP工具助手
  /// 需要正确的配置文件
  /// TTTUDPCommunicator.Instance.SendMessageOut("Text");
  /// </summary>
  [RequireComponent(typeof(TTTManager))]
  [RequireComponent(typeof(TTTUDPCommunicator))]
  public class TTTUDPHandler : MonoBehaviour
  {
    // 可以挑选采用哪一个方案
    public enum UDPTypes
    {
      Default,
      LED
    }

    [SerializeField]
    private UDPTypes UDPType = UDPTypes.Default;

    #region Paths
    public static string UDPConfigPath = TTTManager.ConfigsPath + "/";
    #endregion

    #region KeyNames
    public static string LocalIPName = "Local IP";
    public static string LocalPortName = "Local Port";
    public static string TargetIPName = "Target IP";
    public static string TargetPortName = "Target Port";
    public static string DetectSpacingName = "Detect Spacing";
    #endregion

    private void Awake()
    {
      switch (UDPType)
      {
        default:
          UDPConfigPath += "udpconfig.json";
          break;
        case UDPTypes.Default:
          UDPConfigPath += "udpconfig.json";
          break;
        case UDPTypes.LED:
          UDPConfigPath += "ledconfig.json";
          break;
      }
      TTTManager.FileIntegrityCheck(UDPConfigPath);
    }
  }
}