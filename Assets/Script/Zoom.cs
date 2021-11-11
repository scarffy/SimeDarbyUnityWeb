using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    #region solution 1
    //public Transform target;

    //[SerializeField] float targetZoom;
    //[SerializeField] float zoomSpeed = 3f;
    //[SerializeField] float zoomLerpSpeed = 10f;

    //[SerializeField] float inputValue;
    //[SerializeField] float zoomMin, zoomMax;
    //float zPos;
    //public float scrollSensitivity = 5;

    //// Update is called once per frame
    //void Update()
    //{
    //    // transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

    //    inputValue -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

    //    zPos -= inputValue * scrollSensitivity;
    //    zPos = Mathf.Clamp(zPos, zoomMin, zoomMax);

    //    Vector3 result = transform.forward * zPos;
    //    transform.position = result;

    //    inputValue = 0;
    //}
    #endregion

    [SerializeField] float targetZoom;
    [SerializeField] float zoomFactor = 3f;
    [SerializeField] float zoomLerpSpeed = 10;

    [SerializeField] float zoomMin, zoomMax;

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        // How to clamp this mother fucker? without interfering with rotation and panning
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, zoomMin, zoomMax);

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
