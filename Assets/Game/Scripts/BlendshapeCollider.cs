using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(RASCALSkinnedMeshCollider))]
public class BlendshapeCollider : MonoBehaviour
{
    public SkinnedMeshRenderer rend;
    public RASCALSkinnedMeshCollider meshCollider;
    public float blendWeight;

    private void Awake()
    {
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        meshCollider = GetComponent<RASCALSkinnedMeshCollider>();
        GetComponent<SphereCollider>().isTrigger = true;
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
        blendWeight += 10;
        rend.SetBlendShapeWeight(0, blendWeight);
        meshCollider.ImmediateUpdateColliders();
    }
}
