using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeCamera : MonoBehaviour
{
    private ARCameraManager _cameraManager;

    void Start()
    {
        _cameraManager = GetComponentInChildren<ARCameraManager>();
    }

    public void ChangeDirection()
    {
        _cameraManager.requestedFacingDirection = _cameraManager.currentFacingDirection == CameraFacingDirection.User ? CameraFacingDirection.World : CameraFacingDirection.User;
    }
}