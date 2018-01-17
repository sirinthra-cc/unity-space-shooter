using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private void Start()
    {
        Rigidbody laser = gameObject.GetComponent<Rigidbody>();
        laser.velocity = transform.forward * speed;
    }
}
