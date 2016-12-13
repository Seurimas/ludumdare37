using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Netted : MonoBehaviour
{
    private float amount = 5;
    public float duration = 3f;
    private float progress = 0;
    private playerMoveController move;
    void Start()
    {
        move = GetComponent<playerMoveController>();
        if (move.speed > amount + 1)
            move.speed -= amount;
        else
            Destroy(this);
    }
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > duration)
        {
            GetComponent<playerMoveController>().speed += amount;
            Destroy(this);
        }
    }
}
