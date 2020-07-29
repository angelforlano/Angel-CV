using UnityEngine;
using System.Collections;
 
public class FPSDisplay : MonoBehaviour
{
    public int size = 4;
    public bool show;

    float deltaTime ;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            show = !show;
        }

        if (!show)
            return;

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }
 
    void OnGUI()
    {   
        if(!show)
            return;

        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * size / 100;


        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = fps.ToString("0");

        if (fps > 30)
        {
            style.normal.textColor = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            style.normal.textColor = new Color(1f, 1f, 0f, 1f);
        }

        GUI.Label(rect, text, style);
    }
}