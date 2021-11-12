using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Transform cameraTransform;   // Y value
    public GameObject compass;  // z value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 compassRotation = compass.transform.eulerAngles;
        compassRotation.z = cameraTransform.eulerAngles.y;
        compass.transform.eulerAngles = compassRotation;
    }
}
