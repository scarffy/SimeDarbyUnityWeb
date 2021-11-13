using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Compass : MonoBehaviour
{
    public Transform cameraTransform;   // Y value
    public GameObject compass;  // z value

    [Space]
    [SerializeField] float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 compassRotation = compass.transform.eulerAngles;
        compassRotation.z = cameraTransform.eulerAngles.y + offset;
        compass.transform.eulerAngles = compassRotation;
    }
}
