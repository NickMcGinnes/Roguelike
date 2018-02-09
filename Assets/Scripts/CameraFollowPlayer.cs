using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject Player;

    private Vector3 _vcameraDifference;

    private Vector3 _currentPos;
	
    // Use this for initialization
	void Start ()
    {
        _vcameraDifference.x =  - transform.position.x - Player.transform.position.x;
        _vcameraDifference.y = transform.position.y - Player.transform.position.y;
        _vcameraDifference.z = Player.transform.position.z - transform.position.z;

        //Debug.Log(vcameraDifference.x);
        //Debug.Log(vcameraDifference.y);
        //Debug.Log(vcameraDifference.z);
    }

    // Update is called once per frame
    void Update ()
    {
        //transform.LookAt(Player.transform);
        Vector3 currentPos = transform.position;
        Vector3 targetPos = Player.transform.position;
        
        targetPos.y = _vcameraDifference.y;
        targetPos.z -= _vcameraDifference.z;

        float currentDistance = Vector3.Distance(targetPos, currentPos);
        currentDistance = currentDistance * 2;
        
        currentPos =  Vector3.Lerp(currentPos, targetPos, currentDistance*Time.deltaTime);
        transform.position = currentPos;
	}

    public void SetNewPlayer(GameObject myNewPlayer)
    {
        Player = myNewPlayer;
    }
}
