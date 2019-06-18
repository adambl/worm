using System;
using UnityEngine;

public class GameController: MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform playerTransform;
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position);
    }
}
