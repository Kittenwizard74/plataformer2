using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float senseHor;
    public float senseVer;

    public Transform orientacion;

    float rotacionX;
    float rotacionY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //input del mouse
        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseHor;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseVer;

        rotacionY += mousex;
        rotacionX -= mousey;

        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        //rotacion camara

        transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0);
        orientacion.rotation = Quaternion.Euler(0, rotacionY, 0);
    }
}
