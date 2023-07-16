using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target; // объект, на который смотрит камера
    public float rotationSpeed = 1f; // скорость вращения камеры
    public float autoRotationTime = 30f; // время одного оборота в автоматическом режиме

    private bool isAutoRotating = false; // флаг автоматического вращения камеры
    private float autoRotationTimer = 0f; // таймер автоматического вращения камеры
}
