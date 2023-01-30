using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(RASCALSkinnedMeshCollider))]
public class BlendshapeCollider : MonoBehaviour
{
    public SkinnedMeshRenderer rend;
    public RASCALSkinnedMeshCollider meshCollider;
    public Animator animator;
    public float blendWeight;
    public int counter;

    private void Awake()
    {
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        meshCollider = GetComponent<RASCALSkinnedMeshCollider>();
        animator = GetComponent<Animator>();
        GetComponent<CapsuleCollider>().isTrigger = true;
        meshCollider.immediateStartupCollision = true;
        transform.tag = "Player";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StickmanFall();
        }
    }
    public void StickmanFall()
    {
        counter++;
        animator.SetTrigger("Glup");
        if (blendWeight <= 25)
        {
            blendWeight += 2f;
        }
        else if (blendWeight <= 45)
        {
            blendWeight += 2.5f;
        }
        else if (blendWeight <= 60)
        {
            blendWeight += 3f;
        }
        else if (blendWeight <= 100)
        {
            blendWeight += 3.5f;
        }
        else
        {
            //blow
            animator.SetBool("Blow", true);
        }
        rend.SetBlendShapeWeight(0, blendWeight);
        meshCollider.ImmediateUpdateColliders();
    }
}
