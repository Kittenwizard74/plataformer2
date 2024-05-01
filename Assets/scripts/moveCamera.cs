using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform camaraPos;

    void Update()
    {
        transform.position = camaraPos.position;
    }
}
