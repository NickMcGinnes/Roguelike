using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerUnitOnClicked : MonoBehaviour
{
	private UnitManager _unitManager;

	private void Start()
	{
		_unitManager = GameObject.FindGameObjectWithTag("PlayerUnitManager").GetComponent<UnitManager>();
	}

	void Clicked()
	{
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			_unitManager.SelectAdditionalUnit(gameObject);
		else
		{
			//tell the player unit manager to select this object
			_unitManager.SelectSingleUnit(gameObject);	
		}
		
	}
}
