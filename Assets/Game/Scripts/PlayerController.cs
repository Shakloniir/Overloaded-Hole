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
    public Vector2 XBoundaries = new Vector2(-4, 10);
    public Vector2 ZBoundaries = new Vector2(-10, 10);

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        Vector3 newPosition = transform.position + direction * Time.deltaTime * Speed;

        newPosition.x = Mathf.Clamp(newPosition.x, XBoundaries.x, XBoundaries.y);
        newPosition.z = Mathf.Clamp(newPosition.z, ZBoundaries.x, ZBoundaries.y);

        controller.MovePosition(newPosition);
    }
}
