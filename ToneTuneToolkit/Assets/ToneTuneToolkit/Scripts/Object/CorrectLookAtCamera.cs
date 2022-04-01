/// <summary>
/// Copyright (c) 2021 MirzkisD1Ex0 All rights reserved.
/// Code Version 1.0
/// </summary>

using UnityEngine;

namespace ToneTuneToolkit.Object
{
  /// <summary>
  /// 使物体永远朝向且正对相机
  /// </summary>
  public class CorrectLookAtCamera : MonoBehaviour
  {
    private Vector3 targetPosition;
    private Vector3 targetQuaternion;

    private void Update()
    {
      // Debug.DrawLine(transform.position, Camera.main.transform.position, Color.green);
      targetPosition = transform.position + Camera.main.transform.rotation * Vector3.forward;
      targetQuaternion = Camera.main.transform.rotation * Vector3.up;
      transform.LookAt(targetPosition, targetQuaternion);
    }
  }
}