using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
	private Transform enemyHolder;
	public static float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy",0f,0.1f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
    	enemyHolder.position += Vector3.left * speed;

    	if (enemyHolder.position.x < -15)
        {
        	enemyHolder.position = new Vector3(50f,enemyHolder.position.y,0f);
            speed += 0.1f;
        	PlayerScore.playerScore += 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	// hit the player
    	if (other.tag == "Player")
    	{
    		Destroy(other.gameObject); 	
    		GameOver.isPlayerDead = true;
    	}
    }
}
