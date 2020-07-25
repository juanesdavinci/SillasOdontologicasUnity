using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera[] Cameras;
    public List<GameObject> Tags;

    public void EnableCamera(int Camera)
    {
        // reset all cameras
        foreach (var cam in Cameras)
        {
            cam.Priority = 1;
        }

        Cameras[Camera].Priority = 10;

        foreach (var ta in Tags)
        {
            ta.SetActive(false);
        }
    }
}
