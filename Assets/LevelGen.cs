using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

	public Vector3 WorldSize;

	private Room[,] _rooms;

	private List<Vector3> _takenPositions = new List<Vector3>();

	private int _gridSizeX, _gridSizeZ, _numberofRooms = 20;

	public GameObject RoomWhiteObj;
	
	
}
