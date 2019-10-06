using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float minBound, maxBound;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        // h < 0 => go to the left
        if (player.position.x < minBound && h < 0)
            h = 0;
        // h > 0 => go to the right
        else if (player.position.x > maxBound && h > 0)
            h = 0;

        player.position += Vector3.right * h * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
        }
    }
}
