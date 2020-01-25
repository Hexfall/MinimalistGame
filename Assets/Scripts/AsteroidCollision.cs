using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource sound = GameManager.instance.GetComponent<AudioSource>();
		if (other.attachedRigidbody.name == "Player")
		{
			GameManager.instance.kill();
			sound.Play();
		}
		else if (other.attachedRigidbody.name == "BulletCapsule")
		{
			GameManager.instance.incScore();
			sound.pitch = Random.Range(.25f, .7f);
			sound.Play();
			Destroy(other.gameObject.transform.parent.gameObject);
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
