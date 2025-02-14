using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
    }
}
