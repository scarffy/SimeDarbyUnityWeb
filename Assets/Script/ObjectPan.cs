using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPan : MonoBehaviour
{
    public Transform target;
    [SerializeField] float speed = 10f;

    Vector3 mousePosition;  // Get mouse position
        
    int ScreenX;    // Get current screen x size
    int ScreenY;    // Get cyrrent screen y size

    [SerializeField] bool restrictMovement = false;
    [SerializeField] float restrictMinX = 0f;
    [SerializeField] float restrictMaxX = 0f;
    [SerializeField] float restrictMinY = 0f;
    [SerializeField] float restrictMaxY = 0f;

    private void Start()
    {
        ScreenX = (Screen.width / 2);
        ScreenY = (Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            mousePosition = Input.mousePosition;

            if (restrictMovement)
                RestrictedMovement();
            else
                UnRestricterdMovement();
        }
    }

    void RestrictedMovement()
    {
        if(mousePosition.x > ScreenX && target.position.x < restrictMinX)
        {
            target.position += Vector3.right * Time.deltaTime * speed;
        }
        if (mousePosition.x < ScreenX && target.position.x > restrictMaxX)
        {
            target.position -= Vector3.right * Time.deltaTime * speed;
        }

        if (mousePosition.y > ScreenY && target.position.z < restrictMinY)
        {
            target.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (mousePosition.y < ScreenY && target.position.z > restrictMaxY)
        {
            target.position -= Vector3.forward * Time.deltaTime * speed;
        }
    }

    void UnRestricterdMovement()
    {
        if (mousePosition.x > ScreenX)
        {
            target.position += Vector3.right * Time.deltaTime * speed;
        }
        if (mousePosition.x < ScreenX)
        {
            target.position -= Vector3.right * Time.deltaTime * speed;
        }

        if (mousePosition.y > ScreenY)
        {
            target.position += Vector3.forward * Time.deltaTime * speed;
        }
        else if (mousePosition.y < ScreenY)
        {
            target.position -= Vector3.forward * Time.deltaTime * speed;
        }
    }
}
