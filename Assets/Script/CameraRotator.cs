using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera;
    [Range(0.1f, 5f)]
    [Tooltip("How sensitive the mouse drag to camera rotation")]
    public float mouseRotateSpeed = 0.8f;
    [Range(0.01f, 100)]
    [Tooltip("How sensitive the touch drag to camera rotation")]
    public float touchRotateSpeed = 17.5f;
    [Tooltip("Smaller positive value means smoother rotation, 1 means no smooth apply")]
    public float slerpValue = 0.25f;
    public enum RotateMethod { Mouse, Touch };
    [Tooltip("How do you like to rotate the camera")]
    public RotateMethod rotateMethod = RotateMethod.Mouse;
    private Vector2 swipeDirection; //swipe delta vector2
    private Quaternion cameraRot; // store the quaternion after the slerp operation
    private Touch touch;
    public float distanceBetweenCameraAndTarget;
    public float minXRotAngle = -80; //min angle around x axis
    public float maxXRotAngle = 80; // max angle around x axis
                                     //Mouse rotation related
    [SerializeField] private float rotX; // around x
    [SerializeField] private float rotY; // around y

    private Vector3 dir;
    private Quaternion newQ;

    [Space(10)]
    public float minDistance = 3;
    public float maxDistance = 10;

    [Space(20)]
    public float ScrollSpeed = 10;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        distanceBetweenCameraAndTarget = Vector3.Distance(mainCamera.transform.position, target.position);

        //rotX = 40;
        //rotY = 0;
        newQ = Quaternion.Euler(rotX, rotY, 0);
        dir = new Vector3(-4703, -202, -distanceBetweenCameraAndTarget);
        cameraRot = Quaternion.Slerp(cameraRot, newQ, slerpValue);
        mainCamera.transform.position = target.position + cameraRot * dir;
        mainCamera.transform.LookAt(target.position);

        //SetCamPos();
    }
    // Update is called once per frame
    void Update()
    {
        if (rotateMethod == RotateMethod.Mouse)
        {
            if (Input.GetMouseButton(0))
            {
                rotX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed; // around X
                rotY += Input.GetAxis("Mouse X") * mouseRotateSpeed;
            }
            if (rotX < minXRotAngle)
            {
                rotX = minXRotAngle;
            }
            else if (rotX > maxXRotAngle)
            {
                rotX = maxXRotAngle;
            }

            //distCam -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            if (distanceBetweenCameraAndTarget >= minDistance && distanceBetweenCameraAndTarget <= maxDistance)
            {
                distanceBetweenCameraAndTarget -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            }
            if (distanceBetweenCameraAndTarget < minDistance)
            {
                distanceBetweenCameraAndTarget = minDistance;
            }
            else if (distanceBetweenCameraAndTarget > maxDistance)
            {
                distanceBetweenCameraAndTarget = maxDistance;
            }
        }
        else if (rotateMethod == RotateMethod.Touch)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("Touch Began");
                }
                else if (touch.phase == TouchPhase.Moved) // the problem lies in we are still rotating object even if we move our finger toward another direction
                {
                    swipeDirection += touch.deltaPosition * Time.deltaTime * touchRotateSpeed;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Touch Ended");
                }
            }
            if (swipeDirection.y < minXRotAngle)
            {
                swipeDirection.y = minXRotAngle;
            }
            else if (swipeDirection.y > maxXRotAngle)
            {
                swipeDirection.y = maxXRotAngle;
            }
        }
    }

    private void LateUpdate()
    {
        dir = new Vector3(0, 0, -distanceBetweenCameraAndTarget); //assign value to the distance between the maincamera and the target
        //Quaternion newQ; // value equal to the delta change of our mouse or touch position
        if (rotateMethod == RotateMethod.Mouse)
        {
            newQ = Quaternion.Euler(rotX, rotY, 0); //We are setting the rotation around X, Y, Z axis respectively
        }
        else
        {
            newQ = Quaternion.Euler(swipeDirection.y, -swipeDirection.x, 0);
        }

        cameraRot = Quaternion.Slerp(cameraRot, newQ, slerpValue); //let cameraRot value gradually reach newQ which corresponds to our touch
        mainCamera.transform.position = target.position + cameraRot * dir;
        mainCamera.transform.LookAt(target.position);
    }
    public void SetCamPos()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        mainCamera.transform.position = new Vector3(0, 0, -distanceBetweenCameraAndTarget);
    }
}