using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
	public GameObject explosion;
	private AudioSource sound;

	void Start()
	{
		sound = GameManager.instance.GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		try
		{
			sound.pitch = Random.Range(.25f, .7f);
			sound.Play();
		} catch {}
		if (other.attachedRigidbody.name == "Player")
		{
			GameManager.instance.kill();
		}
		else if (other.attachedRigidbody.name == "BulletCapsule")
		{
			Destroy(other.gameObject.transform.parent.gameObject);
			Explode();
		}
		else if (other.attachedRigidbody.name == "SuperBulletCapsule")
		{
			Explode();
		}
	}

	private void Explode()
	{
		GameManager.instance.incScore();
		Destroy(gameObject.transform.parent.gameObject);
		GameObject e = Instantiate(explosion) as GameObject;
		e.transform.position = transform.position;
	}
}
