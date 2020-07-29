using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpener : MonoBehaviour 
{
	public string link;

	public void OpenLink() 
	{
		Application.OpenURL(link);	
	}

	public void OpenLinkBtn(string link) 
	{
		Application.OpenURL(link);	
	}
}