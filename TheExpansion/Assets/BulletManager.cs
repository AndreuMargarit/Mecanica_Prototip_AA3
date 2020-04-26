using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float speed = 30;
    [SerializeField] private GameObject pS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bulletPS = Instantiate(pS, transform.position, transform.rotation);
        bulletPS.transform.LookAt(transform.position - transform.forward, Vector3.up);
        bulletPS.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }
}
