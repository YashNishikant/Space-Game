using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    private float time;
    [SerializeField] private float limit;

    void Update()
    {
        time += Time.deltaTime;

        if ((int)time > limit) {
            Destroy(this.gameObject);
        }

    }
}
