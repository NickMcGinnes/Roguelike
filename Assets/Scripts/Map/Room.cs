using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
	public Vector3 GridPosition;

	public int Type;

	public bool DoorN, DoorS, DoorE, DoorW;

	public Room(Vector3 myGridpos, int myType)
	{
		GridPosition = myGridpos;
		Type = myType;
	}
}
