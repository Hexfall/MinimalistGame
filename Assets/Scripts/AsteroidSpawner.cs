﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public float speed;
	public float spawnTime;
	public float doubleDiffTime;
	private float lastSpawn = 0.0f;
	public GameObject asteroid;

    // Update is called once per frame
    void FixedUpdate()
    {
		if (GameManager.instance.dead)
			return;
		if (lastSpawn >= spawnTime / (GameManager.instance.aliveTime / doubleDiffTime))
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
