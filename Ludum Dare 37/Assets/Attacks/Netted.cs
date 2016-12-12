using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Netted : MonoBehaviour
{
    public float duration = 3f;
    private float progress = 0;
    private playerMoveController move;
    void Start()
    {
        move = GetComponent<playerMoveController>();
        if (move.speed > 5)
            move.speed -= 4;
        else
            Destroy(this);
    }
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > duration)
        {
            GetComponent<playerMoveController>().speed += 4;
            Destroy(this);
        }
    }
}
