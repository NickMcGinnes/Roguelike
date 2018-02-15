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
	
	public int WeaponType; //0 for sword, 1 for spear and 2 for crossbow

	private Rigidbody _rb;
	private Collider _coll;
	
	public GameObject MyBullet;

	public AnimationClip[] AttackAnims;

	public AnimationClip MyAttackAnim;
	
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
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PickUp(GameObject hand)
	{
		_rb.useGravity = false;
		_coll.enabled = false;
		Grounded = false;
		
		gameObject.transform.SetParent(hand.transform);
		gameObject.transform.position = hand.transform.position;
		gameObject.transform.rotation = hand.transform.rotation;
		
		CloseTooltip();
	}

	public void PutDown()
	{
		_rb.useGravity = true;
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
}
