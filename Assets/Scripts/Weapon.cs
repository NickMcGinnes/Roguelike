using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject TheCanvas;
	
	public bool Grounded;

	public string Name;
	
	public float Range;

	public float Damage;

	public float RateOfFire;
	
	public int WeaponType; //0 for sword, 1 for spear and 2 for crossbow

	private Rigidbody _rb;
	private Collider _coll;
	
	public GameObject MyBullet;

	public Collision passsed;

	//public AnimationClip[] AttackAnims;

	//public AnimationClip MyAttackAnim;
	
	// Use this for initialization
	void Start () {
		
		TheCanvas = GameObject.FindGameObjectWithTag("Canvas");
		_rb = GetComponent<Rigidbody>();
		_coll = GetComponent<Collider>();
		if (_coll == null)
		{
			_coll = gameObject.GetComponentInChildren<Collider>();
		}
		
		Grounded = true;
	}

	public void Attack()
	{
		switch (WeaponType)
		{
				case 0:
					StartCoroutine("WeaponAnim");
					break;
				case 1:
					StartCoroutine("WeaponAnim");
					break;
				case 2:
					GameObject shot = Instantiate(MyBullet, gameObject.transform.position, gameObject.transform.rotation);
					shot.GetComponent<Bullet>().mydamage = Damage;
					shot.GetComponent<Rigidbody>().velocity = shot.gameObject.transform.forward * 10;
					break;		
		}
	}

	public void PickUp(GameObject hand)
	{
		//_rb.useGravity = false;
		//_rb.isKinematic = true;
		_coll.enabled = false;
		Grounded = false;
		
		gameObject.transform.SetParent(hand.transform);
		gameObject.transform.position = hand.transform.position;
		gameObject.transform.rotation = hand.transform.rotation;
		
		CloseTooltip();
	}

	public void PutDown()
	{
		//_rb.useGravity = true;
		//_rb.isKinematic = false;
		_coll.enabled = true;
		Grounded = true;
		
		gameObject.transform.SetParent(null);
		
	}

	private void OnMouseEnter()
	{
		if (Grounded)
		TheCanvas.GetComponent<CanvasControl>().MouseOverPickupEnter();
	}

	private void OnMouseExit()
	{
		if(Grounded)
		CloseTooltip();
	}

	private void CloseTooltip()
	{
		TheCanvas.GetComponent<CanvasControl>().MouseOverPickupExit();
	}

	private void OnCollisionEnter(Collision other)
	{
		print("collisions");
		if (other.gameObject.CompareTag("Enemies"))
			other.gameObject.GetComponent<CharacterInfo>().Hit(Damage);
	}

	public void Collided()
	{
		print("collision");
		if (passsed.gameObject.CompareTag("Enemies"))
			passsed.gameObject.GetComponent<CharacterInfo>().Hit(Damage);
	}

	IEnumerator WeaponAnim()
	{
		Animation myAnimation = GetComponent<Animation>();
		myAnimation.Play();
		_coll.enabled = true;
		yield return new WaitForSeconds(RateOfFire);
		myAnimation.Stop();
		_coll.enabled = false;
	}
	
	/*
	IEnumerator SwordAnim()
	{
		Animation myAnimation = GetComponent<Animation>();
		myAnimation.Play();
		_coll.enabled = true;
		yield return new WaitForSeconds(RateOfFire);
		myAnimation.Stop();
		_coll.enabled = false;
	}
	*/
}
