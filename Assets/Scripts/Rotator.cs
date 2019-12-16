using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float speed;
    public bool orbit;

    private void Start()
    {
        speed = Random.Range(30, 50);
    }
    // Update is called once per frame
    void Update () {
        if(orbit)
            transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        else
            transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
