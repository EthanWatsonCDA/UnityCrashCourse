using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraRotation : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public Slider xSensitivitySlider;
    public Slider ySensitivitySlider;

    void Start()
    {
        lockCursor();
        UpdateXSensitivity();
        UpdateYSensitivity();
    }

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * xSensitivity * Time.fixedDeltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * ySensitivity * Time.fixedDeltaTime;

            //apply mouse input to rotation variables
            yRotation += mouseX;
            xRotation -= mouseY;

            //clamp the camera rotation when looking straight up or down
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate the player body and camera
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    public static void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UpdateXSensitivity()
    {
        this.xSensitivity = xSensitivitySlider.value;
    }
    public void UpdateYSensitivity()
    {
        this.ySensitivity = ySensitivitySlider.value;
    }
}
