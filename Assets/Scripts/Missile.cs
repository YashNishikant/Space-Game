using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Missile : MonoBehaviour
{

    float speed;
    [SerializeField] private ParticleSystem explosion;

    private void Start()
    {
        speed = -10;
    }

    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        speed++;
        Destroy(this.gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }

}
