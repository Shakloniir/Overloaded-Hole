using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public FloatingJoystick Joystick;
    public CharacterController controller;
    public RASCALSkinnedMeshCollider skinnedMeshCollider;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        controller.Move(direction * Speed * Time.fixedDeltaTime);
    }

    
}
