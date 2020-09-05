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

    public void EnableFreeCam()
    {
        var maxPriority = 0;
        CinemachineVirtualCamera maxCam = null;
        
        
        foreach (var cam in Cameras)
        {
            if (cam.Priority > maxPriority)
            {
                maxCam = cam;
                maxPriority = cam.Priority;
            }
        }

        var freeCamera = Cameras[2];
        freeCamera.transform.position = maxCam.transform.position;
        EnableCamera(2);
    }

    public void ResetFreeCamera()
    {
        var freeCamera = Cameras[2];
        freeCamera.transform.position = Cameras[0].transform.position;
        var comp = freeCamera.GetCinemachineComponent<CinemachineComposer>();
        comp.m_TrackedObjectOffset = Vector3.up * 0.7f;
    }
}
