using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

    float speed = 3;
    float delta_x;
    float delta_y;
    float threshold = 3;
    // Use this for initialization
    void Start () {

        //offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log(transform.position);
        //transform.position = player.transform.position + offset;
        if (player.transform.position.x > transform.position.x)
        {
            delta_x = player.transform.position.x - transform.position.x;
        }
        else
        {
            delta_x = transform.position.x - player.transform.position.x;
        }

        if (player.transform.position.y > transform.position.y)
        {
            delta_y = player.transform.position.y - transform.position.y;
        }
        else
        {
            delta_y = transform.position.y - player.transform.position.y;
        }

        if(delta_x >= threshold || delta_y >= threshold)
        {
            offset = player.transform.position;
            offset.z = 1;
            transform.position = Vector3.MoveTowards(transform.position, offset, speed * Time.deltaTime);
        }
    }
}
