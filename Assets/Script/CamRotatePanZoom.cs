using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotatePanZoom : MonoBehaviour
{
    public Transform target;
    public float maxOffsetDistance = 2000f; // How far can a cam go off
    public float orbitSpeed = 15f;
    public float panSpeed = .5f;
   
    private Vector3 targetOffset = Vector3.zero;
    private Vector3 targetPosition;

    //[Header("Zoom")]
    public float zoomSpeed = 10f;
   

    // Use this for initialization
    void Start()
    {
        if (target != null) transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = target.position + targetOffset;


        if (target != null)
        {
            targetPosition = target.position + targetOffset;

            // Left Mouse to Orbit
            if (Input.GetMouseButton(0))
            {
                transform.RotateAround(targetPosition, Vector3.up, Input.GetAxis("Mouse X") * orbitSpeed);
                float pitchAngle = Vector3.Angle(Vector3.up, transform.forward);
                float pitchDelta = -Input.GetAxis("Mouse Y") * orbitSpeed;
                // To restrict y angle
                float newAngle = Mathf.Clamp(pitchAngle + pitchDelta, 90f, 180f);
                pitchDelta = newAngle - pitchAngle;
                transform.RotateAround(targetPosition, transform.right, pitchDelta);
            }
            // Right Mouse To Pan
            if (Input.GetMouseButton(1))
            {
                Vector3 offset = transform.right * -Input.GetAxis("Mouse X") * panSpeed + transform.up * -Input.GetAxis("Mouse Y") * panSpeed;
                Vector3 newTargetOffset = Vector3.ClampMagnitude(targetOffset + offset, maxOffsetDistance);
                transform.position += newTargetOffset - targetOffset;
                targetOffset = newTargetOffset;
            }

            // transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            
            
        }
    }

    //public float zoomLevel;
    //public float sensitivity = 1f;
    //public float minZoom = -30f;
    //public float maxZoom = -15f;
    //float zoomPosition;
    void Zoom()
    {
        //// Scroll to Zoom
        //// This work but interfere with panning and rotate
        //zoomLevel += Input.mouseScrollDelta.y * sensitivity;
        //zoomLevel = Mathf.Clamp(zoomLevel, minZoom, maxZoom);
        /////
        //transform.position += target.position + (transform.forward * zoomPosition);
        //////
        //zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, zoomSpeed * Time.deltaTime);
        //transform.position = target.position + (transform.forward * zoomPosition);
    }
}
