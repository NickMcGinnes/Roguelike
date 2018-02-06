using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClicksAndTouches : MonoBehaviour
{

	public Camera DetectionCamera;
	
	//this variable adds a Debug.Log call to show what was touched
	public bool Debug = false;
	
	//this is the actual camera we reference in the update loop, set in Start()
	private Camera _camera;
	
	// Use this for initialization
	void Start () 
	{
		if (DetectionCamera != null)
		{
			_camera = DetectionCamera;
		}
		else
		{
			_camera = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		Ray ray;
		RaycastHit hit;

		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					ray = _camera.ScreenPointToRay(touch.position);
					
					if (Physics.Raycast(ray, out hit, Mathf.Infinity))
					{
						if(Debug)
							UnityEngine.Debug.Log("You touched " + hit.collider.gameObject.name,hit.collider.gameObject);
						
						hit.transform.gameObject.SendMessage("Clicked",hit.point,SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
		else //we are on a computer (more than likely)
		{
			if (Input.GetMouseButtonDown(0)) //check to see if we've clicked
			{
				//set up our ray from screen to scene
				ray = _camera.ScreenPointToRay(Input.mousePosition);
					
				//if we hit
				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					//tell the system what we've clicked on if in Debug mode
					if(Debug)
						UnityEngine.Debug.Log("You clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
						
					//run the Clicked() function on the clicked object
					hit.transform.gameObject.SendMessage("Clicked",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
			if (Input.GetMouseButtonDown(1)) //check to see if we've clicked
			{
				//set up our ray from screen to scene
				ray = _camera.ScreenPointToRay(Input.mousePosition);
					
				//if we hit
				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					//tell the system what we've clicked on if in Debug mode
					if(Debug)
						UnityEngine.Debug.Log("You right clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
						
					//run the Clicked() function on the clicked object
					hit.transform.gameObject.SendMessage("RightClicked",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
