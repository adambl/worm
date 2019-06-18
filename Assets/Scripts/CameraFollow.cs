using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed = 1f;

    private Func<Vector3> GetCameraFollowPositionFunc;

    public void Setup(Func<Vector3> getCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = getCameraFollowPositionFunc;
    }

    public void Update()
    {
        //Application.targetFrameRate = 5;
        Vector3 followPosition = GetCameraFollowPositionFunc();
        Transform t = GetComponent<Transform>();
        followPosition.z = t.position.z;

        Vector3 moveDirection = (followPosition - t.position).normalized;
        float distance = Vector3.Distance(followPosition, t.position);
        if (distance > 0) {
            Vector3 newPosition =  moveDirection* distance *cameraMoveSpeed * Time.deltaTime;
            if (Vector3.Distance(newPosition, followPosition) > distance)
            {
                newPosition = followPosition;
            }
            t.position = newPosition;
        }
    }
}
