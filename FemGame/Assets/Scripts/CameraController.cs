using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    float xRotation = 0f;
    public bool isCursor = false;

    [Header("Чувствительность мыши")]
    public float sensitivityMouse = 150f;

    public Transform Player;
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
     // Cursor.visible = false;
        CursorOFF();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityMouse;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);
        
      
    }

    //public void CursorON()
    //{
      

    //    Cursor.visible = true;
        

    //}
    public void CursorOFF()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
