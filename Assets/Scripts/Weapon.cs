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
	
	public GameObject MyBullet;

	public AnimationClip[] AttackAnims;

	public AnimationClip MyAttackAnim;
	
	// Use this for initialization
	void Start () {
		TheCanvas = GameObject.FindGameObjectWithTag("Canvas");
			_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PickUp()
	{
		
		_rb.useGravity = false;

		GetComponent<Collider>().enabled = false;

	}

	public void PutDown()
	{
		
	}

	private void OnMouseEnter()
	{
		if (Grounded)
			Debug.Log("onMouseEnter");
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
