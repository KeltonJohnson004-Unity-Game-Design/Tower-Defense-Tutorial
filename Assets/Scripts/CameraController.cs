
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness;
    public float scrollSpeed = 5f;
    public float minX = 10f;
    public float maxX = 80f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = 10f;
    public float maxZ = 80f;

    private bool doMovement = true;
    private void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if(!doMovement)
        {
            return;
        }
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (transform.position.z > minZ)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if ( transform.position.x < maxX)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (transform.position.z < maxZ)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (transform.position.x > minX)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * 2000 * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
