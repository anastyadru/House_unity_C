using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 10f;
    public float autoRotationTime = 30f;

    private bool isAutoRotating = false;
    private float autoRotationTimer = 0f;
    
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
        
    }

    private void HandleMouseInput()
    {

    }

    public void StartAutoRotation()
    {

    }

    public void StopAutoRotation()
    {

    }

}