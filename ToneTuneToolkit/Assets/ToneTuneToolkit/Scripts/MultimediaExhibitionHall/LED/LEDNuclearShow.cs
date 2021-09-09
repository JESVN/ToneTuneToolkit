/// <summary>
/// Copyright (c) 2021 MirzkisD1Ex0 All rights reserved.
/// Code Version 1.0
/// </summary>

using UnityEngine;
using UnityEngine.UI;

namespace ToneTuneToolkit.LED
{
  /// <summary>
  /// 核弹秀
  /// </summary>
  public class LEDNuclearShow : MonoBehaviour
  {
    private GameObject nuclearGO;
    private Image nImC;
    private Button nBuC;
    private Color color = Color.white;
    private bool isShowing = false;

    private void Start()
    {
      nuclearGO = GameObject.Find("Button - Nuclear");
      nImC = nuclearGO.GetComponent<Image>();
      nBuC = nuclearGO.GetComponent<Button>();

      nBuC.onClick.AddListener(StartNuclear);
    }

    /// <summary>
    /// 
    /// </summary>
    private void StartNuclear()
    {
      if (!isShowing)
      {
        InvokeRepeating("RandomColor", 0, .1f);
      }
      else
      {
        CancelInvoke();
        nImC.color = new Color(0, 0, 0, 0);
      }
      isShowing = !isShowing;
      return;
    }

    private void RandomColor()
    {
      color = new Color(Random.Range(0f, 255f) / 255, Random.Range(0f, 255f) / 255, Random.Range(0f, 255f) / 255, 1);
      nImC.color = color;

      LEDCommandCenter.Instance.SLDimColor("#" + ColorUtility.ToHtmlStringRGB(color));
      return;
    }
  }
}