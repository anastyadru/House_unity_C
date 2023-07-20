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
        target = GameObject.Find("House").transform;
    }

    void Update()
    {
        if (isAutoRotating)
        {
            AutoRotate();
        }
        else
        {
            HandleMouseInput();
        }
    }

    private void AutoRotate()
    {
        autoRotationTimer += Time.deltaTime;
        float angle = autoRotationTimer / autoRotationTime * 360f;
        transform.DORotate(new Vector3(0f, -angle, 0f), autoRotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.RotateAround(target.position, Vector3.up, mouseX * Time.deltaTime);
        transform.RotateAround(target.position, transform.right, -mouseY * Time.deltaTime);
        transform.LookAt(target);
    }

    public void StartAutoRotation()
    {
        isAutoRotating = true;
        autoRotationTimer = 0f;
        transform.DORotate(new Vector3(0f, -360f, 0f), autoRotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

    public void StopAutoRotation()
    {
        isAutoRotating = false;
        transform.DOKill();
    }

}