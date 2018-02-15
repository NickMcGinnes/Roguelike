using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public bool Grounded;

	public float Range;

	public float Damage;
	
	//0 for sword, 1 for spear and 2 for crossbow
	public int WeaponType;
	
	public GameObject MyBullet;

	public AnimationClip[] AttackAnims;

	public AnimationClip MyAttackAnim;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
