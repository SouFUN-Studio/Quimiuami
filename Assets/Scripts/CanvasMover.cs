using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMover : MonoBehaviour
{
    public Transform exitLimit;
    public Transform startLimit;
    Vector2 currentPosition;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > exitLimit.position.x)
            transform.position = new Vector3(startLimit.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }

}
