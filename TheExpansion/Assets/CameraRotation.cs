using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * 150 * Time.deltaTime;
        if (xRotation > 45) xRotation = 45;
        else if (xRotation < -45) xRotation = -45;

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
    }
}
