using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
	public Vector3 direction;

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!GameManager.instance.dead)
			transform.localPosition += direction * Time.fixedDeltaTime;
    }
}
