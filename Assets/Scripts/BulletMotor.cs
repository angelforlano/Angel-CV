using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotor : MonoBehaviour
{
	public int speed = 4;
	public GameObject bulletImpact;

	void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
	}

	void OnTriggerEnter(Collider other)
	{
		// Debug.Log("Col Whit >>> " + other.gameObject.name);
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Trigger"))
		{
			return;
		}

		// Generales
		if (bulletImpact != null)
		{
			var gameObj = Instantiate(bulletImpact,transform.position,transform.rotation);
			Destroy(gameObj, 1);
		}
		Destroy(gameObject, 1);
		gameObject.SetActive(false);
	}
}