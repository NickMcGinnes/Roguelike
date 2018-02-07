using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

	public GameObject MouseOverUi;
    
   	public GameObject HealthBar;
	private float _maxBarSize = 525.0f;

	public GameObject NameText;

	public GameObject InfoText;
    	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (MouseOverUi.activeSelf)
		{
			//set up our ray from screen to scene
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			
			//if we hit
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{	
				SetMouseUi(hit.collider.gameObject);
			}
		}
	}

	public void MouseOverEnter()
	{
		MouseOverUi.SetActive(true);
	}

	public void MouseOverExit()
	{
		MouseOverUi.SetActive(false);
	}

	void SetMouseUi(GameObject highlightedGameObject)
	{
		CharacterInfo myChar = highlightedGameObject.GetComponent<CharacterInfo>();
		
		//healthBar
		Vector3 newscale = HealthBar.transform.localScale;
		newscale.x = _maxBarSize *(myChar.HealthPercent);
		HealthBar.transform.localScale = newscale;

		NameText.GetComponent<Text>().text = myChar.Name;

		InfoText.GetComponent<Text>().text = myChar.Info;
	}
}
