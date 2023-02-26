using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{

    public static float fps;
    public Text fpsDisplay;


    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "" + fps;
    }
    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)fps);
    }
}