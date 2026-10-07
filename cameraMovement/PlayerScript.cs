using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer faceRen;
    [SerializeField] private Sprite face, hitFace;
    [SerializeField] private Transform bodyTransform;

    public float launchForceMult = 0.1f;
    public float maxDragDist = 250f;
    public float maxBodyScale = 2f;

    private bool isStopped = true;
    private bool isDragging = false;
    private Vector2 startPos;
    private Vector2 currentPos;

    private Vector3 bodyScale;
    private Vector3 bodyPosition;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0f;
        rb.angularDrag = 0f;

        if (bodyTransform != null)
        {
            bodyScale = bodyTransform.localScale;
        }

        StopPlayer();
    }

    void Update()
    {
        if (isStopped)
        {
            HandleDragInput();
        }
    }

    private void StopPlayer()
    {
        isStopped = true;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;

        if (faceRen != null && face != null)
        {
            faceRen.sprite = face;
        }

        ResetBodyVisual();
    }

    private void HandleDragInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startPos = Input.mousePosition;
            currentPos = Vector2.zero;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            currentPos = (Vector2)Input.mousePosition - startPos;
            currentPos = Vector2.ClampMagnitude(currentPos, maxDragDist);
            UpdateBodyVisual(currentPos);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            if (currentPos.magnitude > 15f)
            {
                LaunchPlayer(currentPos);
            }
            else
            {
                ResetBodyVisual();
            }
        }
    }

    private void UpdateBodyVisual(Vector2 dragVector)
    {
        if (bodyTransform == null) return;

        if (dragVector.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(dragVector.y, dragVector.x) * Mathf.Rad2Deg;
            bodyTransform.rotation = Quaternion.Euler(0, 0, angle  + 90f);
            float progress = dragVector.magnitude / maxDragDist;
            float newScaleY = Mathf.Lerp(bodyScale.y, bodyScale.y * maxBodyScale, progress);

            bodyTransform.localScale = new Vector3(bodyScale.x, newScaleY, bodyScale.z);
            float bodyLength = Mathf.Abs(newScaleY);
            bodyTransform.localPosition = bodyPosition;
        }
        else { return; }
    }

    private void ResetBodyVisual()
    {
        if (bodyTransform == null) return;
        bodyTransform.localScale = bodyScale;
        bodyTransform.localRotation = Quaternion.identity;
        bodyTransform.localPosition = bodyPosition;
    }

    private void LaunchPlayer(Vector2 dragVector)
    {
        isStopped = false;
        rb.isKinematic = false;

        Vector2 launchDirection = - dragVector.normalized;
        float force = dragVector.magnitude * launchForceMult;

        rb.AddForce(launchDirection * force, ForceMode2D.Impulse);

        ResetBodyVisual();
    }



    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
       if (otherCollider.CompareTag("block"))
        {
            StopPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (faceRen != null && hitFace != null)
        {
            faceRen.sprite = hitFace;
        }

    }

}
