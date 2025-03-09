using System;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public CelestialObject planet;
    public float cameraDistance = 5f;

    void Update()
    {
        transform.position = target.position + ((target.up - target.forward) * cameraDistance);

        Vector3 distance = target.position - planet.transform.position;
        Vector3 direction = distance.normalized;
        Vector3 bodyUp = target.up;
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, direction) * transform.rotation;
        Vector3 eulerRotation = targetRotation.eulerAngles;
        eulerRotation.y = 0f;
        targetRotation = Quaternion.Euler(eulerRotation);

        transform.rotation = targetRotation;
        transform.LookAt(target, target.up);
    }
}
