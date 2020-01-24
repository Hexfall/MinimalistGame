using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star;
    public int amount;
    public float maxSize, minSize;
    public float minSpeed, maxSpeed;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        for (int i = 0; i < amount; i++)
            SpawnStar();
    }

    void SpawnStar()
    {
        GameObject s = Instantiate(star) as GameObject;
        float size = GenNum(minSize, maxSize);
        s.transform.localScale = new Vector3(size, size, 1);
        float speed = GenNum(minSpeed, maxSpeed);
        s.GetComponent<Rotation>().rotationSpeed = speed;
        Vector2 location = RandomLocation(screenBounds);
        s.transform.position = new Vector3(location.x, location.y, 0);
    }

    private float GenNum(float min, float max)
    {
        return Random.value * (max - min) + min;
    }

    private Vector2 RandomLocation(Vector2 screenSize)
    {
        float x = Random.value * screenSize.x * 2 - screenSize.x;
        float y = Random.value * screenSize.y * 2 - screenSize.y;
        return new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
