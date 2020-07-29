using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadiallFillAnim : MonoBehaviour
{
    public string title;
    [Range(0, 1)] public float percent;
    public Image fillBar;
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = title;
        StartCoroutine(Fill());
    }

    IEnumerator Fill()
    {
        while (fillBar.fillAmount < percent)
        {
            yield return new WaitForEndOfFrame();
            fillBar.fillAmount += Time.deltaTime / 2.5f;
        }
    }
}