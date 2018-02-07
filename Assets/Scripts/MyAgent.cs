using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyAgent : MonoBehaviour
{


	public void NavTarget(Vector3 target)
	{
		GetComponent<NavMeshAgent>().SetDestination(target);
	}
}
