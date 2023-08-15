using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform house;
    public Transform cameraTransform;
    public enum CameraMode { Automatic, Manual };
    public CameraMode currentCameraMode;
    public float cameraRotationTime = 30f;
    public float cameraMovementSpeed = 1f;
    public Texture2D automaticCameraModeTexture;
    public Texture2D manualCameraModeTexture;
    
    private Vector3 targetPosition;
    private bool isMoving = false;
    
    void Start()
    {
        if (currentCameraMode == CameraMode.Automatic)
        {
            cameraTransform.LookAt(house.transform.position);
            DOTween.To(() => 0f, x => cameraTransform.RotateAround(house.position, Vector3.up, x), -360f, cameraRotationTime).SetLoops(-1, LoopType.Restart);
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
                targetPosition = new Vector3(house.transform.position.x - 10f, GetComponent<Camera>().transform.position.y, house.transform.position.z);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetPosition = new Vector3(house.transform.position.x + 10f, GetComponent<Camera>().transform.position.y, house.transform.position.z);
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
            cameraTransform.LookAt(house.transform.position);
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