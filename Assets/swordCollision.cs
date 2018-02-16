using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollision : MonoBehaviour {
	
	private void OnCollisionEnter(Collision other)
	{
		gameObject.transform.parent.GetComponent<Weapon>().passsed = other;
		gameObject.transform.parent.GetComponent<Weapon>().Collided();
		
	}
}
