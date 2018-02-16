using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float mydamage;
	
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemies"))
			other.gameObject.GetComponent<CharacterInfo>().Hit(mydamage);
		
		Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
