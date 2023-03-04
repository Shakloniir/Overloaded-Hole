using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public FloatingJoystick Joystick;
    public Rigidbody controller;

    public Transform holeDropPose;
    public List<GameObject> Stickmans;
    public GameObject throwPose;
    public GameObject libra;

    public Vector2 XBoundaries = new Vector2(-4, 10);
    public Vector2 ZBoundaries = new Vector2(-10, 10);

    public bool disableControl;
    [SerializeField] Gravity gravity;
    [SerializeField] InHole hole;
    [SerializeField] LayerChanger layerChanger;

    public void FixedUpdate()
    {
        if (GameManager.instance.GameFinish) return;

        if (disableControl) return;

        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        Vector3 newPosition = transform.position + direction * Time.deltaTime * Speed;

        newPosition.x = Mathf.Clamp(newPosition.x, XBoundaries.x, XBoundaries.y);
        newPosition.z = Mathf.Clamp(newPosition.z, ZBoundaries.x, ZBoundaries.y);

        controller.MovePosition(newPosition);
    }

    public void EnableControl()
    {
        disableControl = false;
        gravity.enabled = true;
        hole.enabled = true;
        layerChanger.enabled = true;
    }
    public void DisableControl()
    {
        disableControl = true;
        gravity.enabled = false;
        hole.enabled = false;
        layerChanger.enabled = false;
        StartCoroutine(StickmanDrop());
    }   
    IEnumerator StickmanDrop()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < Stickmans.Count;)
        {
            if (Stickmans.Count == 0) break;
            FindObjectOfType<Terazi>().Drop(-0.1f);
            FindObjectOfType<Terazi>().PlayerText();
            FindObjectOfType<StickmanSpawner>().currentStickmen--;
            Stickmans[0].transform.tag = "Untagged";
            Stickmans[0].transform.parent = libra.transform;
            Stickmans[0].transform.DOJump(throwPose.transform.position, 1, 1,0.5f);
            Stickmans.Remove(Stickmans[0]);
            yield return new WaitForSeconds(0.1f);
        }
        EnableControl();
    }
}
