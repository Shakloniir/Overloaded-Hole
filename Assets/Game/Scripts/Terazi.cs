using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terazi : MonoBehaviour
{
    public Animator anim;
    public float playerFrame;
    public float startforce;
    public float starttimer;
    private void Start()
    {
        playerFrame = 0.5f;
    }


    void Update()
    {

        float hznt = Input.GetAxis("Horizontal");
        anim.SetFloat("time", -hznt);

        playerFrame = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;  //Get the current frame of animation

        #region Animation position bounds
        if (playerFrame > 1)
            playerFrame = 1;

        else if (playerFrame < 0)
            playerFrame = 0;
        #endregion
    }
}
