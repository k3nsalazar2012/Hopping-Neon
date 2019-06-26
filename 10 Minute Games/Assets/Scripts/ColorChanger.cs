using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public new Light light;
    public Text scoreText;
    public Text[] titleTexts;
    Color newColor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Mathf.Sin(Time.time * 1f) + 1f) / 4f;
        newColor = Color.Lerp(Color.red, Color.green, t);
        light.color = newColor;
        scoreText.color = newColor;
        foreach (Text text in titleTexts)
        {
            text.color = newColor;
        }
    }
}
