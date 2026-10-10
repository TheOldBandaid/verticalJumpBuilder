using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField, Range(0f, 1f)]
    private float parallaxFactor = 0.2f;

    private Vector3 previousCameraPosition;

    private void Start()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (cameraTransform != null)
            previousCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        if (cameraTransform == null)
            return;

        Vector3 cameraDelta =
            cameraTransform.position - previousCameraPosition;

        transform.position += cameraDelta * (1f - parallaxFactor);

        previousCameraPosition = cameraTransform.position;
    }
}
