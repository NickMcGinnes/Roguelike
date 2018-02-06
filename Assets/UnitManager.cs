using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

	public List<GameObject> SelectedUnits;

	public List<GameObject> GetSelectedUnits()
	{
		return SelectedUnits;
	}
	
	// Use this for initialization
	void Start () 
	{
		SelectedUnits.Clear();
	}

	public bool IsSelected(GameObject unit)
	{
		if (SelectedUnits.Contains(unit))
			return true;
		else
			return false;
	}
	
	public void SelectSingleUnit(GameObject unit)
	{
		SelectedUnits.Clear();
		SelectedUnits.Add(unit);
	}
	
	public void SelectAdditionalUnit(GameObject unit)
	{	
		SelectedUnits.Add(unit);
	}

	public void DeselectAllUnits()
	{
		SelectedUnits.Clear();
	}

	
}
