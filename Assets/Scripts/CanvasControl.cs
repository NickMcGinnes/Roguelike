using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

	public GameObject ThePlayer;
	private float _maxBarSize = 525.0f;

	//variables for bloodPoints
	public GameObject BloodUI;

	//variables for TargetUI
	public GameObject MouseOverTargetUi;
	public GameObject TargetHealthBar;
	public GameObject NameText;
	public GameObject InfoText;

	//Tooltip
	public GameObject TooltipUi;


	//variables for playerUI
	public GameObject PlayerHealthBar;

	// Use this for initialization
	void Start()
	{
		if (ThePlayer == null)
			ThePlayer = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		CheckTargetUi();
		DoPlayerUi();
	}

	private void DoPlayerUi()
	{
		//get character info from target
		CharacterInfo myChar = ThePlayer.GetComponent<CharacterInfo>();
		BloodUI.GetComponentInChildren<Text>().text = myChar.BloodPoints.ToString();
		//healthBar scale
		Vector3 newscale = PlayerHealthBar.transform.localScale;
		newscale.x = _maxBarSize * (myChar.HealthPercent);
		PlayerHealthBar.transform.localScale = newscale;
	}

	private void CheckTargetUi()
	{
		
		//set up our ray from screen to scene
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//if we hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (MouseOverTargetUi.activeSelf)
				DoMouseOverTargetUi(hit.collider.gameObject);
			if (TooltipUi.activeSelf)
				DoToolTipUi(hit.collider.gameObject);
			
		}
	}

	private void DoMouseOverTargetUi(GameObject highlightedGameObject)
	{
		//get character info from target
		CharacterInfo myChar = highlightedGameObject.GetComponent<CharacterInfo>();

		//healthBar scale
		Vector3 newscale = TargetHealthBar.transform.localScale;
		newscale.x = _maxBarSize * (myChar.HealthPercent);
		TargetHealthBar.transform.localScale = newscale;

		NameText.GetComponent<Text>().text = myChar.Name;

		InfoText.GetComponent<Text>().text = myChar.Info;
	}
	
	void DoToolTipUi(GameObject highlightedGameObject)
	{
		Weapon myWeapInfo = highlightedGameObject.GetComponent<Weapon>();

		string myString = "";

		myString += myWeapInfo.name;
		myString += myWeapInfo.Range;
		myString += myWeapInfo.Damage;
		Vector3 myPos;
		
		myPos = Input.mousePosition;

		TooltipUi.transform.position = myPos;
		TooltipUi.GetComponent<Text>().text = myString;
	}

	public void MouseOverTargetEnter()
	{
		MouseOverTargetUi.SetActive(true);
	}

	public void MouseOverTargetExit()
	{
		MouseOverTargetUi.SetActive(false);
	}

	public void MouseOverPickupEnter()
	{
		TooltipUi.SetActive(true);
	}

	public void MouseOverPickupExit()
	{
		TooltipUi.SetActive(false);
	}
	
	public void SetNewPlayer(GameObject myNewplayer)
	{
		ThePlayer = myNewplayer;
	}

}
