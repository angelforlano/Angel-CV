using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteCodeAnim : MonoBehaviour
{
    public float timeDelay;
    [TextArea] public string code;
    public TextMeshProUGUI text;
    
    //<color=#89DDFF>if</color>

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BinaryCode());
    }

    IEnumerator BinaryCode()
    {
        foreach (var item in code)
        {
            text.text += item;
            yield return new WaitForSecondsRealtime(Random.Range(0.01f, 0.05f));
        }
    }
}