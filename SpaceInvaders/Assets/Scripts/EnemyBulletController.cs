using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
	private Transform bullet;
	public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
    	bullet.position += Vector3.up * -speed;

    	// outside of the screen
    	if (bullet.position.y <= -10)
    		Destroy(bullet.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	// hit player
        if (other.tag == "Player")
        {
        	Destroy(other.gameObject);
        	Destroy(gameObject);
        	GameOver.isPlayerDead = true;
        }
        // if a bullet hit a base, reduce health of base
        else if (other.tag == "Base")
        {
        	GameObject playerBase = other.gameObject;
        	BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
        	baseHealth.health -= 1;
        	Destroy(gameObject);
        }
    }
}
