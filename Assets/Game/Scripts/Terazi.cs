using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terazi : MonoBehaviour
{
    public Animator anim;
    public float playerFrame;

    [SerializeField] float StartStopValue;
    [SerializeField] float StartForcevalue;
    [SerializeField] float StartTimer;

    [SerializeField] float forceValue;
    [SerializeField] bool drop;

    bool startEqual;
    private void Start()
    {
        playerFrame = 0.5f;
    }
    void Update()
    {
        if (!startEqual)
            StartEqualizer();
        else
            ValueChanger();


        playerFrame = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;  //Get the current frame of animation

        #region Animation position bounds
        if (playerFrame > 1)
            playerFrame = 1;

        else if (playerFrame < 0)
            playerFrame = 0;
        #endregion
    }

    private void StartEqualizer()
    {
        if (StartStopValue > StartTimer)
        {
            StartTimer += Time.deltaTime;
            anim.SetFloat("time", StartForcevalue);
        }
        else
        {
            StartForcevalue = 0;
            anim.SetFloat("time", StartForcevalue);
            startEqual = true;
        }
    }
    public void Drop(float force)
    {
        forceValue = force;
        StartCoroutine(DropStart());
    }
    private void ValueChanger()
    {
        if (drop)
        {
            StartCoroutine(DropStop());
            anim.SetFloat("time", forceValue);
        }
        else
            anim.SetFloat("time", 0);
    }
    IEnumerator DropStart()
    {
        yield return new WaitForSeconds(1f);
        drop = true;
    }
    IEnumerator DropStop()
    {
        yield return new WaitForSeconds(0.1f);
        drop = false;
    }
}
