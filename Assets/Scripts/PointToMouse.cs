using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{
	public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
		if (GameManager.instance.dead)
			return;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;
		dir = Vector3.forward * Mathf.Rad2Deg * Mathf.Atan((mouse.y - transform.position.y)/(mouse.x - transform.position.x));
		if (mouse.x - transform.position.x < 0)
			dir.z -= 180;
		transform.eulerAngles = dir;
    }
}
