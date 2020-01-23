using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
	public Vector3 direction;
	private Vector2 screenBounds;

	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		screenBounds *= 3;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!GameManager.instance.dead)
			transform.localPosition += direction * Time.fixedDeltaTime;

		float x = transform.position.x, y = transform.position.y;
		if (Mathf.Abs(transform.position.x) > screenBounds.x || Mathf.Abs(transform.position.y) > screenBounds.y)
			Destroy(gameObject.transform.parent.gameObject);
	}
}
