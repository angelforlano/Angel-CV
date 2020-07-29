using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeccionsController : MonoBehaviour
{
    public float delay1;
    public float delay2;
    
    public GameObject plexus;
    public Animator animator;
    public List<CanvasGroup> seccions = new List<CanvasGroup>();

    int previusSeccion;

    void Start()
    {
        seccions[0].alpha = 1;

        for (int i = 1; i < seccions.Count; i++)
        {
            seccions[i].alpha = 0;
        }
    }

    IEnumerator ChangeSeccion(int _seccion)
    {
        animator.SetTrigger("play");
        
        seccions[_seccion].interactable = true;
        seccions[_seccion].blocksRaycasts = true;

        seccions[previusSeccion].interactable = false;
        seccions[previusSeccion].blocksRaycasts = false;

        yield return new WaitForSeconds(delay1);

        plexus.SetActive(_seccion == 0);
        AsteroidGameController.Instance.SetGameText(_seccion != 0);
        
        seccions[_seccion].alpha = 1;
        seccions[previusSeccion].alpha = 0;
        
        yield return new WaitForSeconds(delay2);
        seccions[_seccion].interactable = true;
        previusSeccion = _seccion;
    }

    public void GoMenu()
    {
        SetSeccion(0);
    }

    public void SetSeccion(int _seccion)
    {
        StartCoroutine(ChangeSeccion(_seccion));
    }
}