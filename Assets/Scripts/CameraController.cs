using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    public float panBorderThickness = 10f;
    void Update()
    {

        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        // camera movement wasd and mouse
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        // if (Input.GetKey("s") || Input.mousePosition.y <= Screen.height - panBorderThickness) // using this will constantly pull down
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        // if (Input.GetKey("a") || Input.mousePosition.x <= Screen.width -panBorderThickness) // using this will constantly pull left
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime; // multiplied by 1000 to increase the speed, without 1000 it is VERY slow scrolling
        // pos.y -= scroll * scrollSpeed * Time.deltaTime; // without 1000 VERY slow
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
