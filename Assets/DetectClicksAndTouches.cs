using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClicksAndTouches : MonoBehaviour
{

    private GameObject _player;
    

    //this variable adds a Debug.Log call to show what was touched
    public bool Debug = false;

    //this is the actual camera we reference in the update loop, set in Start()
    private Camera _camera;
    
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        
        //set up our ray from screen to scene
        ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) //check to see if we've clicked
        {
            //if we hit
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //tell the system what we've clicked on if in Debug mode
                if (Debug)
                    UnityEngine.Debug.Log("You clicked " + hit.collider.gameObject.name, hit.collider.gameObject);

                //run the Clicked() function on the clicked object
                hit.transform.gameObject.SendMessage("Clicked", hit.point, SendMessageOptions.DontRequireReceiver);
            }
        }

        if (Input.GetMouseButtonDown(1)) //check to see if we've clicked
        {

            //if we hit
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //tell the system what we've clicked on if in Debug mode
                if (Debug)
                    UnityEngine.Debug.Log("You right clicked " + hit.collider.gameObject.name, hit.collider.gameObject);

                //run the Clicked() function on the clicked object
                hit.transform.gameObject.SendMessage("RightClicked", hit.point, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}