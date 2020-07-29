using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinaryCodeAnim : MonoBehaviour
{
    public float timeDelay;
    public TextMeshProUGUI text;

    int bytes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BinaryCode());
    }

    IEnumerator BinaryCode()
    {
        while (true)
        {
            bytes++;
            text.text += Random.Range(0, 2).ToString();
            
            if (bytes == 8)
            {
                bytes = 0;
                text.text += "\n";
            }

            yield return new WaitForSeconds(timeDelay);

            if (text.text.Length > 600)
            {
                text.text = text.text.Remove(0, 100);
            }
        }
    }
}
