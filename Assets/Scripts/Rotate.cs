using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{	
	public bool useRamdon;
	public Vector3 rotateSpeed;
	
	void Start () 
	{
		if(useRamdon)
		{
			rotateSpeed.x = Random.Range(2,10);
			rotateSpeed.y = Random.Range(2,10);
			rotateSpeed.z = Random.Range(2,10);
		}

	}
	
	void Update () 
	{
		transform.Rotate(rotateSpeed.x * Time.deltaTime, rotateSpeed.y * Time.deltaTime, rotateSpeed.z * Time.deltaTime);	
	}
}