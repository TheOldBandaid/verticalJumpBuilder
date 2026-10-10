using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class CamScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float verticalOffset = 2f;
    [SerializeField] private float smoothSpeed = 5f;
    private float startY;

    private Camera cam;
    private float fixedX;
    private float fixedZ;
    private bool restarting;

    private void Start()
    {
        cam = GetComponent<Camera>();

        if (cam == null)
            cam = Camera.main;

        fixedX = transform.position.x;
        fixedZ = transform.position.z;
        startY = transform.position.y;
    }

    private void LateUpdate()
    {
        if (target == null || cam == null || restarting)
            return;

        float targetY = Mathf.Max(target.position.y + verticalOffset, startY);

        Vector3 targetPosition = new Vector3(
            fixedX,
            targetY,
            fixedZ
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        Vector3 viewportPos = cam.WorldToViewportPoint(target.position);

        if (viewportPos.y < 0f || viewportPos.y > 3f)
        {
            restarting = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}