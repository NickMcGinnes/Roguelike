using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{

	public bool IsDebug = false;

	public bool IsQueue = false;

	public float Radius = 5.0f;

	public LayerMask Mask;

	private GameObject _targetEnemy;

	private float _primaryAttackTime = 0.0f;

	private float _secondaryAttackTime = 0.0f;

	public GameObject myWeaponHand;

	public GameObject myWeapon;

	// Update is called once per frame
	void Update()
	{
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
			Vector3 look = hit.point;

			look.y = 0.0f;
			float distance = Vector3.Distance(gameObject.transform.position, hit.point);

			if (Input.GetMouseButton(0))
			{
				LeftClick(distance, hit, look);
			}

			if (Input.GetMouseButtonDown(1))
			{
				RightClick(distance, hit);
			}

			if (Input.GetKey(KeyCode.LeftShift))
			{
				transform.LookAt(look);
				StopHere();
			}
		}
	}

	private void LeftClick(float distance, RaycastHit hit, Vector3 look)
	{
		//print(distance);
		if (IsQueue)
			IsQueue = false;

		if (distance <= 1.3f)
		{
			if (hit.collider.gameObject.CompareTag("Weapon"))
			{
				print("Can pick up " + hit.collider.gameObject.name);
				// drop current weapon
				if (myWeapon != null)
				{
					myWeapon.GetComponent<Weapon>().PutDown();
				}
				//pickup weapon
				myWeapon = hit.collider.gameObject;
				if (myWeapon.GetComponent<Weapon>() == null)
					myWeapon = myWeapon.transform.parent.gameObject;
				myWeapon.GetComponent<Weapon>().PickUp(myWeaponHand);
			}

			else if (hit.collider.gameObject.CompareTag("Enemies"))
			{
				print(distance);
				StopHere();
				transform.LookAt(look);
				PlayerBasicAttack();
			}
		}
		else
		{
			//print("inside else");
			if (GetComponent<NavMeshAgent>().isStopped)
				GetComponent<NavMeshAgent>().isStopped = false;

			MoveTo(hit.point);
			
			IEnumerator coroutine = QueueAction(hit, look);
			StartCoroutine(coroutine);
		}
	}



	private void RightClick(float distance, RaycastHit hit)
	{
		if (distance < 3.0f)
		{
		}

		if (hit.collider.gameObject.CompareTag("Enemies"))
		{
			PlayerSpecialAttack();
		}
		else
		{
			if (GetComponent<NavMeshAgent>().isStopped)
				GetComponent<NavMeshAgent>().isStopped = false;
			StartCoroutine("Dash");
			MoveTo(hit.point);
		}
	}

	private void PlayerBasicAttack()
	{
		//set up our ray from screen to scene
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//if we hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (hit.collider.gameObject.CompareTag("Enemies"))
			{
				if (Time.time > _primaryAttackTime + GetComponent<CharacterInfo>().AttackSpeed)
				{
					float myDamage = GetComponent<CharacterInfo>().Damage;

					hit.collider.gameObject.GetComponent<CharacterInfo>().Hit(myDamage);
					_primaryAttackTime = Time.time;
				}
			}
		}
	}

	private void PlayerSpecialAttack()
	{
		//set up our ray from screen to scene
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//if we hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (hit.collider.gameObject.CompareTag("Enemies"))
			{
				_targetEnemy = hit.collider.gameObject;
				if (Time.time > _secondaryAttackTime + GetComponent<CharacterInfo>().SecondaryAttackSpeed)
				{
					/*
					float myDamage = (0.2f * _targetEnemy.GetComponent<CharacterInfo>().GetMaxHealth());
					if (myDamage >= _targetEnemy.GetComponent<CharacterInfo>().Health)
						gameObject.GetComponent<CharacterInfo>().IncreaseBlood(1);
					*/

					float myDamage = GetComponent<CharacterInfo>().Damage * 1.3f;
					hit.collider.gameObject.GetComponent<CharacterInfo>().Hit(myDamage);
					_secondaryAttackTime = Time.time;
				}
			}
		}
	}

	void EnemyMovement()
	{
		Collider[] things = Physics.OverlapSphere(transform.position, Radius, Mask);

		if (things.Length > 0)
		{
			if (GetComponent<NavMeshAgent>().isStopped)
				GetComponent<NavMeshAgent>().isStopped = false;
			MoveTo(things[0].gameObject.transform.position);

			float distance = Vector3.Distance(gameObject.transform.position, things[0].gameObject.transform.position);

			if (!(distance < 1.2f)) return;
			StopHere();
			transform.LookAt(things[0].gameObject.transform);
			EnemyAttack(things[0].gameObject);
		}
		else
		{
			StopHere();
		}
	}

	private void EnemyAttack(GameObject myTarget)
	{
		if (Time.time > _primaryAttackTime + GetComponent<CharacterInfo>().AttackSpeed)
		{
			float myDamage = GetComponent<CharacterInfo>().Damage;

			myTarget.GetComponent<CharacterInfo>().Hit(myDamage);
			_primaryAttackTime = Time.time;
		}
	}

	private void MoveTo(Vector3 myTarget)
	{
		GetComponent<NavMeshAgent>().SetDestination(myTarget);
	}

	private void StopHere()
	{
		GetComponent<NavMeshAgent>().isStopped = true;
	}




	private IEnumerator Dash()
	{
		GetComponent<NavMeshAgent>().speed = 12.0f;
		yield return new WaitForSeconds(0.3f);
		GetComponent<NavMeshAgent>().speed = 3.5f;
	}


	private IEnumerator QueueAction(RaycastHit hit, Vector3 look)
	{
		//print("inside coroutine");
		IsQueue = true;
		float distance = Vector3.Distance(gameObject.transform.position, hit.point);
		while (distance > 1.3f)
		{
			distance = Vector3.Distance(gameObject.transform.position, hit.point);
			yield return 0;
		}
		//print("close enough");
		LeftClick(distance, hit, look);
		IsQueue = false;
	}
}
