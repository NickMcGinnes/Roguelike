using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.AI;

public class CharacterInfo : MonoBehaviour
{

	public string Name;

	public string Info;
	
	public int Health;

	public int MaxHealth;

	public float HealthPercent;

	public int Strength;

	public int Dexterity;

	public float Damage;
	
	public float MoveSpeed;

	public float AttackSpeed;

	public GameObject TheCanvas;

	public Material CurrentMat;

	public Material HitMat;
	
	// Use this for initialization
	void Start ()
	{
		TheCanvas = GameObject.FindGameObjectWithTag("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
	{
		CalcValues();
	}
	
	public void Hit(float damage)
	{
		Health -= (int)damage;
		StartCoroutine("HitColor");
		CheckDeath();
	}

	private void CheckDeath()
	{
		if (Health > 0) return;
		if (CompareTag("Player"))
		{
			SetPlayerToFeral();
		}
		else
		{
				OnMouseExit();
				Destroy(gameObject);
		}
	}

	private void SetPlayerToFeral()
	{
		Destroy(gameObject);
		
		//dont destroy but switch to new player and set this to Feral
		/*
		MaxHealth = 50;
		Health = MaxHealth;
		gameObject.tag = "Enemies";
		gameObject.layer = LayerMask.NameToLayer("Enemies");
		*/
	}
	
	private void CalcValues()
	{
		HealthPercent = (float)Health / MaxHealth;
		
		//calc damage using strength
		
		//calc attack speed using Dex
		
		//calc move speed using Dex
	}

	private void OnMouseEnter()
	{
		if (CompareTag("Player")) return;
		TheCanvas.GetComponent<CanvasControl>().MouseOverEnter();
	}

	private void OnMouseExit()
	{
		if (CompareTag("Player")) return;
		TheCanvas.GetComponent<CanvasControl>().MouseOverExit();
		
	}
	
	IEnumerator HitColor()
	{
		foreach (Renderer t in transform.GetComponentsInChildren<Renderer>())
		{
			t.material = HitMat;
		}
		yield return new WaitForSeconds(0.2f);
		foreach (Renderer t in transform.GetComponentsInChildren<Renderer>())
		{
			t.material = CurrentMat;
		}
	}
}
