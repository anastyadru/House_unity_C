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
        autoRotationTimer += Time.deltaTime;
        float angle = autoRotationTimer / autoRotationTime * 360f;
        transform.DORotate(new Vector3(0f, -angle, 0f), autoRotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
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