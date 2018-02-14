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
		if (!MouseOverTargetUi.activeSelf) return;
		//set up our ray from screen to scene
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//if we hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			DoMouseOverTargetUi(hit.collider.gameObject);
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

	public void MouseOverEnter()
	{
		MouseOverTargetUi.SetActive(true);
	}

	public void MouseOverExit()
	{
		MouseOverTargetUi.SetActive(false);
	}

	public void SetNewPlayer(GameObject myNewplayer)
	{
		ThePlayer = myNewplayer;
	}

}
