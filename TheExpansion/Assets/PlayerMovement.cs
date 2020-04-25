using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float yRotation =0;
    private float speed = 5;
    private Vector3 nextPosition = Vector3.zero;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            nextPosition -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            nextPosition += transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            nextPosition += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            nextPosition -= transform.forward * Time.deltaTime * speed;
        }

        if (Physics.Linecast(transform.position, nextPosition + (nextPosition-transform.position) * 10, out hit))
        {
            nextPosition = transform.position;
        }

        transform.position = nextPosition;

        yRotation += Input.GetAxis("Mouse X") * 150 * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }
}
