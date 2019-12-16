using UnityEngine;
using System.Collections;

public class OrbitMovement : MonoBehaviour
{

    GameObject core;
    public Transform center;
    public Vector3 axis = Vector3.forward;
    public Vector3 desiredPosition;
    public float radius;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    void Start()
    {
        core = GameObject.FindWithTag("Core");
        center = core.transform;
        radius = Mathf.Abs(transform.position.y);
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}