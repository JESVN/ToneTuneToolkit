/// <summary>
/// Copyright (c) 2021 MirzkisD1Ex0 All rights reserved.
/// Code Version 1.0
/// </summary>

using UnityEngine;
using System.Diagnostics;
using System.Text;
using ToneTuneToolkit.Common;

namespace ToneTuneToolkit.WOL
{
  /// <summary>
  /// 设备冷启动
  ///
  /// 需要电脑支持WOL
  /// 需要在Bios中设置
  /// 需要在设备管理器中对网卡设置可唤醒
  /// </summary>
  public class WakeOnLan : MonoBehaviour
  {
    public static WakeOnLan Instance;

    private static string targetMAC;
    private static string targetIP;
    private static string targetMask;
    private static string targetPort;

    private void Awake()
    {
      Instance = this;
    }

    private void Start()
    {
      this.Presetting();
    }

    private void Presetting()
    {
      targetMAC = TextLoader.GetJson(WakeOnLanHandler.WOLConfigPath, WakeOnLanHandler.TargetMACName);
      targetIP = TextLoader.GetJson(WakeOnLanHandler.WOLConfigPath, WakeOnLanHandler.TargetIPName);
      targetMask = TextLoader.GetJson(WakeOnLanHandler.WOLConfigPath, WakeOnLanHandler.TargetMaskName);
      targetPort = TextLoader.GetJson(WakeOnLanHandler.WOLConfigPath, WakeOnLanHandler.TargetPortName);
      return;
    }

    /// <summary>
    /// 冷启动
    /// </summary>
    /// <param name="mac"></param>
    /// <param name="ip"></param>
    /// <param name="mask"></param>
    /// <param name="port"></param>
    private static void ColdStartDevice(string mac, string ip, string mask, string port = "7")
    {
      string command = (WakeOnLanHandler.WOLAppPath + "wolcmd " + mac + " " + ip + " " + mask + " " + port).Replace(@"/", @"\");

      Process p = new Process();
      ProcessStartInfo psi = new ProcessStartInfo();
      psi.FileName = "cmd.exe";
      psi.UseShellExecute = false;
      psi.RedirectStandardError = true;
      psi.RedirectStandardInput = true;
      psi.RedirectStandardOutput = true;
      psi.CreateNoWindow = true;

      p.StartInfo = psi;
      p.Start();

      p.StandardInput.WriteLine(command);
      p.StandardInput.AutoFlush = true;
      p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
      p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
      return;
    }

    /// <summary>
    /// 偷懒方法
    /// </summary>
    public static void LaunchWakeOnLan()
    {
      ColdStartDevice(targetMAC, targetIP, targetMask, targetPort);
      return;
    }
  }
}