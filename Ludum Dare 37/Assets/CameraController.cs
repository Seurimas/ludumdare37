using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
        deadzone_check();
    }

    void deadzone_check()
    {
        //MAGIC NUMBERS!
        float speed = player.GetComponent<playerMoveController>().speed;
        float deltaX = 0.0f;
        float deltaY = 0.0f;
        float horizontal_threshold = 5.0f;
        float vertical_threshold = 2.5f;
        Vector3 moveTemp;

        if (player.transform.position.x > transform.position.x)
        {
            deltaX = player.transform.position.x - transform.position.x;
        }
        else
        {
            deltaX = transform.position.x - player.transform.position.x;
        }

        if (player.transform.position.y > transform.position.y)
        {
            deltaY = player.transform.position.y - transform.position.y;
        }
        else
        {
            deltaY = transform.position.y - player.transform.position.y;
        }

        if (deltaX >= horizontal_threshold || deltaY >= vertical_threshold)
        {
            moveTemp = player.transform.position;
            moveTemp.z = -10.0f;
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.deltaTime);
        }
        Debug.Log(transform.position);
        Debug.Log("deltaX: " + deltaX);
        Debug.Log("deltaY: " + deltaY);
    }

}
