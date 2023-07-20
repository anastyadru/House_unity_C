using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform house;
    public Transform camera;
    public enum CameraMode { Automatic, Manual };
    public CameraMode currentCameraMode;
    public float cameraRotationSpeed = 1f;
    public float cameraRotationTime = 30f;
    public float cameraMovementSpeed = 1f;
    public Texture2D automaticCameraModeTexture;
    public Texture2D manualCameraModeTexture;
    
    void Start()
    {
        if (currentCameraMode == CameraMode.Automatic)
        {
            camera.transform.LookAt(house.transform.position);
            camera.transform.DORotate(new Vector3(0f, -360f, 0f), cameraRotationTime, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        }
    }

    void Update()
    {
        
    }

}