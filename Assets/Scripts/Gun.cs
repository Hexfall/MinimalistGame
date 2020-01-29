using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject bullet;
	public GameObject superBullet;
	public float cooldown;
	public float superCooldown;
	public float superDuration;
	private float heat = 0.0f;
	private float superHeat;
	public AudioSource sound;
	private bool superActive = false;
	private GameObject b;
	public GameObject cooldownLocation;
	public GameObject cooldownBar;
	public int cdBars;
	private GameObject[] cdBarArray;
	private int cdBarPointer = 0;
	private float angle;
	public Color ready;
	public Color notReady;

	void Start()
	{
		cdBarArray = new GameObject[cdBars];
		angle = 360.0f / (float)cdBars;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(1) && superHeat <= 0)
			superHeat = superCooldown;
		if (Input.GetMouseButton(0) && heat <= 0 && !GameManager.instance.dead)
		{
			if (!superActive)
				b = Instantiate(bullet) as GameObject;
			else
				b = Instantiate(superBullet) as GameObject;
			b.transform.rotation = transform.rotation;
			b.transform.Rotate(0, 0, -90);
			b.transform.position = transform.position;
			heat = cooldown;
			sound.pitch = Random.Range(3.0f, 3.5f);
			sound.Play();
		}
    }

	void FixedUpdate()
	{
		if (heat > 0 && !GameManager.instance.dead)
			heat -= Time.fixedDeltaTime;
		if (superHeat > 0 && !GameManager.instance.dead)
			superHeat -= Time.fixedDeltaTime;
		if (superHeat + superDuration >= superCooldown)
			superActive = true;
		else
			superActive = false;
		if (!superActive)
		{
			if (Mathf.Floor((superCooldown - superDuration - superHeat) / (superCooldown - superDuration) * cdBars) > cdBarPointer)
			{
				cdBarArray[cdBarPointer] = Instantiate(cooldownBar) as GameObject;
				cdBarArray[cdBarPointer].transform.parent = cooldownLocation.transform;
				cdBarArray[cdBarPointer].transform.localPosition = new Vector3(0, 0, 0);
				cdBarArray[cdBarPointer].transform.Rotate(0, 0, - angle * cdBarPointer - angle / 2);
				ChangeColor(cdBarArray[cdBarPointer], notReady);
				cdBarPointer++;
			}
			if (cdBarPointer == cdBars)
			{
				for (int i = 0; i < cooldownLocation.transform.childCount; i++)
					ChangeColor(cooldownLocation.transform.GetChild(i).gameObject, ready);
			}
		}
		else
		{
			if (Mathf.Floor((superHeat + superDuration - superCooldown) / superDuration * cdBars) < cdBarPointer)
			{
				cdBarPointer--;
				Destroy(cdBarArray[cdBarPointer]);
			}
		}
	}

	void ChangeColor(GameObject parent, Color color)
	{
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			SpriteRenderer sprite = parent.transform.GetChild(i).GetComponent<SpriteRenderer>();
			sprite.color = color;
		}
	}
}
