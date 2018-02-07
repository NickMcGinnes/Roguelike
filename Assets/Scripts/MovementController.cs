using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour {
	
	
	
	
	
	
	
	public float Radius = 5.0f;

	public LayerMask Mask;

	private GameObject _targetEnemy;
	
	
	
	// Update is called once per frame
	void Update () {
		if (gameObject.CompareTag("Player"))
		{
			PlayerMovement();
		}
		else
		{
			EnemyMovement();
		}
	}

	void PlayerMovement()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				MoveTo(transform.position);
				gameObject.transform.LookAt(hit.point);
			}
			if (Input.GetMouseButtonDown(0))
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					//Attack();
				}
				else
				{
					MoveTo(hit.point);
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
				//SpecialAttack();
			}
		}
	}


	void EnemyMovement()
	{
		Collider[] things = Physics.OverlapSphere(transform.position, Radius, Mask);

		if (things.Length > 0)
		{
			MoveTo(things[0].gameObject.transform.position);
		}
		else
		{
			MoveTo(gameObject.transform.position);
		}
		
		
	}
	void MoveTo(Vector3 myTarget)
	{
		GetComponent<NavMeshAgent>().SetDestination(myTarget);
	}
}
