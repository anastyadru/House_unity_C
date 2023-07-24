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
    
    private Vector3 targetPosition;
    
    void Start()
    {
        if (currentCameraMode == CameraMode.Automatic)
        {
            camera.transform.LookAt(house.transform.position);
            camera.transform.DORotate(new Vector3(0f, -360f, 0f), cameraRotationTime, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        }
        else if (currentCameraMode == CameraMode.Manual)
        {
            targetPosition = camera.transform.position;
        }
    } 

    void Update()
    {
        if (currentCameraMode == CameraMode.Manual)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetPosition = new Vector3(house.transform.position.x - 10f, camera.transform.position.y, house.transform.position.z);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPosition = new Vector3(house.transform.position.x + 10f, camera.transform.position.y, house.transform.position.z);
            }
            
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 50), currentCameraMode == CameraMode.Automatic ? automaticCameraModeTexture : manualCameraModeTexture))
        {
            currentCameraMode = currentCameraMode == CameraMode.Automatic ? CameraMode.Manual : CameraMode.Automatic;
            if (currentCameraMode == CameraMode.Manual)
            {
                targetPosition = camera.transform.position;
            }
        }
    }

}