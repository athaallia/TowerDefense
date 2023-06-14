using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float minY = 10f;
    public float maxY = 80f;

    public bool doMovement = true;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = false;

        if (!doMovement)
            return;

        if (Input.GetKey(KeyCode.W)|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 position = transform.position;
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
