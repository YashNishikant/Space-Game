using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private float interval;
    [SerializeField] private GameObject target;
    private float time;
    private float timechanged;
    private bool spawn;

    private void Start()
    {
        spawn = true;
    }

    void Update()
    {

        time += Time.deltaTime;

        if ((int)time % interval == 0)
        {
            if (spawn)
            {
                time = timechanged;
                GameObject g = Instantiate(target, new Vector3(Random.Range(-10, 10), 10, 0), Quaternion.Euler(90,180,0));
                spawn = false;
            }
        }

        if ((int)time != timechanged)
        {
            spawn = true;
        }

    }
}
