using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public FloatingJoystick Joystick;
    public Rigidbody controller;
    public List<GameObject> Stickmans;
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        controller.MovePosition(transform.position + direction * Time.deltaTime * Speed);
    }
}
