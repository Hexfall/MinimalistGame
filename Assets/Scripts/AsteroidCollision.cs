using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.attachedRigidbody.name == "Player")
		{
			Debug.Log("Works");
			GameManager.instance.kill();
		}
		else if (other.attachedRigidbody.name == "BulletCapsule")
		{
			GameManager.instance.incScore();
			Destroy(other.gameObject.transform.parent.gameObject);
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
