using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    public void SetFollow(Transform transform)
    {
        cinemachineVirtualCamera.Follow = transform;
    }

}
