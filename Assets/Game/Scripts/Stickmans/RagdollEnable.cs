using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagdollEnable : MonoBehaviour
{
    public CollisionDetectionMode detectionMode;
    public GameObject _rig;

    private Collider _mainCollider;
    private Animator _animator;


    private void Start()
    {
        References();
        GetRagdollBits();
        RagdollModeOff();
    }

    private void References()
    {
        _mainCollider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    CharacterJoint[] joints;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;

    void GetRagdollBits()
    {
        joints = _rig.GetComponentsInChildren<CharacterJoint>();
        ragdollColliders = _rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = _rig.GetComponentsInChildren<Rigidbody>();
    }

    public void RagdollModeOn() 
    {
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
            rigid.collisionDetectionMode = detectionMode;
        }

        _mainCollider.enabled = false;
        _animator.enabled = false;
    }
    public void RagdollModeOff()
    {
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        _mainCollider.enabled = true;
        _animator.enabled = true;
    }

}
