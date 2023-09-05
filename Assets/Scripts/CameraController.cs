using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{

    public Transform Plane;
    public Transform cameraTransform;
    public enum CameraMode { Automatic, Manual };
    public CameraMode currentCameraMode = CameraMode.Automatic;
    public float cameraRotationTime = 1f;
    public float cameraMovementSpeed = 30f;
    public Texture2D automaticCameraModeTexture;
    public Texture2D manualCameraModeTexture;
    
    private Vector3 targetPosition;
    private bool isMoving = false;
    private float timeSinceRotation = 0f;
    
    void Start()
    {
        if (currentCameraMode == CameraMode.Automatic)
        {
            cameraTransform.LookAt(Plane.transform.position);
            DOTween.To(() => 0f, x => cameraTransform.RotateAround(Plane.position, Vector3.up, x), -360f, cameraRotationTime).SetLoops(-1, LoopType.Restart);
        }
        else if (currentCameraMode == CameraMode.Manual)
        {
            targetPosition = cameraTransform.position;
        }
    } 

    void Update()
    {
        if (currentCameraMode == CameraMode.Manual)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetPosition = new Vector3(Plane.transform.position.x - 10f, cameraTransform.position.y, Plane.transform.position.z);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPosition = new Vector3(Plane.transform.position.x + 10f, cameraTransform.position.y, Plane.transform.position.z);
                isMoving = true;
            }

            if (isMoving)
            {
                cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, cameraMovementSpeed * Time.deltaTime);
                if (Vector3.Distance(cameraTransform.position, targetPosition) < 0.1f)
                {
                    isMoving = false;
                }
            }
            cameraTransform.LookAt(Plane.transform.position);
        }
        else if (currentCameraMode == CameraMode.Automatic)
        {
            timeSinceRotation += Time.deltaTime;
            if (timeSinceRotation >= 30f)
            {
                timeSinceRotation = 0f;
                DOTween.To(() => 0f, x => cameraTransform.RotateAround(Plane.position, Vector3.up, x), -360f, cameraRotationTime).SetLoops(-1, LoopType.Restart);
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
                targetPosition = cameraTransform.position;
            }
        }
    }

}