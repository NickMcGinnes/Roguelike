using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObjectControl : MonoBehaviour
{

	//public GameObject room, rmNSEW, rmNSE, rmNSW, rmNS, rmN, rmSEW, rmSE, rmSW, rmS, rmEW, rmE, rmW; 
	public GameObject DoorN, DoorS, DoorE, DoorW;
	public bool north, south, east, west;

	public int type; // 0: normal, 1: enter

	private void Start()
	{
		SetDoors();
	}

	void SetDoors()
	{
		if (north)
			DoorN.SetActive(true);
		if (south)
			DoorS.SetActive(true);
		if (east)
			DoorE.SetActive(true);
		if (west)
			DoorW.SetActive(true);
	}
	
/*
	void PickPrefab()
	{
		if (north)
		{
			if (south)
			{
				if (east)
				{
					if (west)
					{
						//set object to all doors
					}
					else
					{
						//set object to all but west
					}
				}
				else if (west)
				{
					//set object to all but east
				}
				else
				{
					//set object to north&south
				}
			}
			else
			{
				if (east)
				{
					if (west)
					{
						
					}
				}
			}
		}
	}
*/
}
