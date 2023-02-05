using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RagdollEnable : MonoBehaviour
{
    public CollisionDetectionMode detectionMode;
    public GameObject _rig;

    private Collider _mainCollider;
    // private Animator _animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        References();
    }


    private void Start()
    {
        GetRagdollBits();
        RagdollModeOff();

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.collisionDetectionMode = detectionMode;

        }
        foreach (CharacterJoint col in joints)
        {
            col.enableProjection = true;
        }
    }

    private void References()
    {
        _mainCollider = GetComponent<Collider>();
        // _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
        }

        _mainCollider.enabled = false;
        // _animator.enabled = false;
        agent.enabled = false;
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
        //_animator.enabled = true;
        agent.enabled = true;
    }

}
