using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject pS;
    private readonly float _speed = 30;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bulletPS = Instantiate(pS, transform.position, transform.rotation);
        bulletPS.transform.LookAt(transform.position - transform.forward, Vector3.up);
        bulletPS.GetComponent<ParticleSystem>().Play();

        if (collision.transform.CompareTag("Sphere"))
        {
            collision.transform.GetComponent<ColorChangeScript>().TriggerStopAnimation();
        }
        else if (collision.transform.CompareTag("Start")) {
            collision.transform.GetComponent<StartGameScript>().StartGame();
        }

        Destroy(bulletPS, 2);
        Destroy(gameObject);
    }
}
