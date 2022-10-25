using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float scrollSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        var mousePos = Input.mousePosition; //We need to get the new position every frame

        //if mouse is 50 pixels and less from the left side of the
        //screen, we move the camera in that direction at scrollSpeed
        if (mousePos.x < 50 && gameObject.transform.position.x >= -40)
            gameObject.transform.Translate(-scrollSpeed, 0, 0);

        //if 50px or less from the right side, move right at scrollSpeeed
        if (mousePos.x > Screen.width - 50 && gameObject.transform.position.x <= 0)
            gameObject.transform.Translate(scrollSpeed, 0, 0);

        //move up
        if (mousePos.y < 50 && gameObject.transform.position.z >= -26)
            gameObject.transform.Translate(0, -scrollSpeed * Mathf.Cos(30 * Mathf.Deg2Rad), -scrollSpeed * Mathf.Cos(60 * Mathf.Deg2Rad));

        //move down
        if (mousePos.y > Screen.height - 50 && gameObject.transform.position.z <= 70)
            gameObject.transform.Translate(0, scrollSpeed * Mathf.Cos(30 * Mathf.Deg2Rad), scrollSpeed * Mathf.Cos(60 * Mathf.Deg2Rad));
    }
}
