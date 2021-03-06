﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int score = 0;
	public bool dead = false;
	public float respawnTime = 5.0f;
	public float sinceDead = 0.0f;
	public float aliveTime = 0.0f;

	void Awake()
	{
        instance = this;
	}

	public void incScore()
	{
		score++;
	}

	public void kill()
	{
		dead = true;
		sinceDead = 0.0f;
	}

	void FixedUpdate()
	{
		if (dead)
		{
			if (sinceDead >= respawnTime)
			{
				SceneManager.LoadScene("SampleScene");
				Reset();
			}
			else
				sinceDead += Time.fixedDeltaTime;
		}
		else
		{
			aliveTime += Time.fixedDeltaTime;
		}
	}

	private void Reset()
	{
		score = 0;
		dead = false;
	}
}
