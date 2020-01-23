using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public float speed;
	public float spawnTime;
	private float lastSpawn = 0.0f;
	public GameObject asteroid;
	private Vector2 screenBounds;
	private float hypo;

	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		hypo = 2 * screenBounds.y;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (GameManager.instance.dead)
			return;
		if (lastSpawn >= spawnTime)
		{
			Spawn();
			lastSpawn = 0;
		}
		lastSpawn += Time.fixedDeltaTime;
    }

	private void Spawn()
	{
		float angle = Random.value * 360;
		GameObject rock = Instantiate(asteroid) as GameObject;
		rock.transform.Rotate(new Vector3(0, 0, angle));
	}
}
