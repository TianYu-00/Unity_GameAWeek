using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Variables
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock cursor // hide
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse input position
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //do the rotations
        xRotation -= mouseY; //decrease xrotation based on mouse Y //when increasing, rotation is flipped
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limit the rotation by using clamp
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //apply the rotation


        playerBody.Rotate(Vector3.up * mouseX);

    }
}
