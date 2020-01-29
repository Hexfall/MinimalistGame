using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // A value between 0 and 1.
    public float start = 0.0f;
    private float value = 0.0f;
    private float size;
    public float changeRate = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        value = Mathf.Rad2Deg * Mathf.Asin(start);
    }

    // Update is called once per frame
    void Update()
    {
        value += changeRate;
        size = Mathf.Sin(Mathf.Deg2Rad * value);
        transform.localScale = new Vector3(size, size, 1);
        if (value >= 180)
            Destroy(gameObject);
    }
}
