using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bahamutAnimationController : MonoBehaviour {
    private Animator animator;
    int direction = 0;
    private playerStatusController playerStatus;
    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
        playerStatus = this.GetComponent<playerStatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerStatus.isIdle());
        animator.SetInteger("direction", playerStatus.getFaceDirection());
        if (playerStatus.isIdle())
        {
            animator.speed = 0.05f;
        }
        else
        {
            animator.speed = 1.0f;
        }
    }
}
