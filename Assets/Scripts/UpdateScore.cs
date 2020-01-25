using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.score.ToString();
    }
}
