using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CharacterInfo : MonoBehaviour
{

	public string Name;

	public string Info;
	
	public int Health;

	public int MaxHealth;

	public float HealthPercent;

	public int Strength;

	public int Dexterity;

	public int Constitution;

	public float Damage;
	
	public float MoveSpeed;

	public float AttackSpeed;

	public GameObject TheCanvas;
	
	// Use this for initialization
	void Start ()
	{
		TheCanvas = GameObject.FindGameObjectWithTag("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
	{
		HealthPercent = (float)Health / MaxHealth;

	}

	private void OnMouseEnter()
	{
		TheCanvas.GetComponent<CanvasControl>().MouseOverEnter();
	}

	private void OnMouseExit()
	{
		TheCanvas.GetComponent<CanvasControl>().MouseOverExit();
		
	}
}
