using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text fpsText;
    int frameCount = 0;
    float fps = 0f;
    float dt = 0f;
    readonly float updateRate = 4f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1f / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1f / updateRate;

            fpsText.text = "FPS: " + (int)fps;
        }
    }
}
