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
	
	public float GetMaxHealth()
	{
		return MaxHealth;
	}

	public float HealthPercent;

	public int BloodPoints = 0;

	public int Strength;

	public int Dexterity;

	public float Damage;
	
	public float MoveSpeed;

	public float AttackSpeed;

	public GameObject TheCanvas;

	public Material CurrentMat;

	public Material MyMaterial;

	public Material HitMat;

	public Material BleedMat;

	public GameObject PlayerPrefab;
	
	// Use this for initialization
	void Start ()
	{
		TheCanvas = GameObject.FindGameObjectWithTag("Canvas");
		Health = MaxHealth;
		CalcValues();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		CalcValues();
	}
	
	private void CalcValues()
	{
		HealthPercent = (float)Health / MaxHealth;
		
		//calc damage using strength
		
		//calc attack speed using Dex
		
		//calc move speed using Dex
	}
	
	public void Hit(float damage)
	{
		Health -= (int)damage;
		CheckDeath();
		StartCoroutine("HitColor");
	}

	private void CheckDeath()
	{
		if (HealthPercent > 0)
		{
			if (HealthPercent < 0.2f)
			{
				SetBleeding();
			}

			return;
		}
		
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
		GameObject newP = Instantiate(PlayerPrefab, new Vector3(-500, 0, 0), Quaternion.identity);
		Camera.main.GetComponent<CameraFollowPlayer>().SetNewPlayer(newP);
		TheCanvas.GetComponent<CanvasControl>().SetNewPlayer(newP);
		newP.GetComponent<CharacterInfo>().IncreaseBlood(BloodPoints);
		//Destroy(gameObject);
		
		//dont destroy but switch to new player and set this to Feral
		
		MaxHealth = 50;
		Health = MaxHealth;
		gameObject.tag = "Enemies";
		gameObject.layer = LayerMask.NameToLayer("Enemies");
		
	}

	public void IncreaseBlood(int amount)
	{
		BloodPoints += amount;
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

	public void SetBleeding()
	{
		foreach (Renderer t in transform.GetComponentsInChildren<Renderer>())
		{
			CurrentMat = BleedMat;
			t.material = BleedMat;
		}
	}
}
