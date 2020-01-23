using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject bullet;
	public float cooldown;
	private float heat = 0.0f;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0) && heat <= 0)
		{
			GameObject b = Instantiate(bullet) as GameObject;
			b.transform.rotation = transform.rotation;
			b.transform.Rotate(0, 0, -90);
			b.transform.position = transform.position;
			heat = cooldown;
		}
    }

	void FixedUpdate()
	{
		if (heat > 0)
			heat -= Time.fixedDeltaTime;
	}
}
