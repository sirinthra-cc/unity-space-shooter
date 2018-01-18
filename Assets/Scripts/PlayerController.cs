using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rigidbody shooter = gameObject.GetComponent<Rigidbody>();
        shooter.velocity = movement * speed;
        shooter.position = new Vector3(
            Mathf.Clamp(shooter.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(shooter.position.z, boundary.zMin, boundary.zMax)
        );
        shooter.rotation = Quaternion.Euler(0.0f, 0.0f, shooter.velocity.x * -tilt);
    }
}
