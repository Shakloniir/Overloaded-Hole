using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
public class EnemyBlackHole : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    public List<GameObject> caughtStickmen;

    public GameObject throwPose;
    public GameObject libra;

    public bool disableControl;
    [SerializeField] Gravity gravity;
    [SerializeField] InHole hole;
    [SerializeField] LayerChanger layerChanger;


    private void Start()
    {
        caughtStickmen = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.GameFinish) return;

        if (disableControl) return;

        GameObject nearestStickman = GetNearestStickman();

        if (nearestStickman != null)
        {
            target = nearestStickman.transform;
        }
        else
        {
            target = GameObject.FindWithTag("Target").transform;
        }

        if (caughtStickmen.Count < 15)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            target = GameObject.FindWithTag("Target").transform;
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private GameObject GetNearestStickman()
    {
        GameObject nearestStickman = null;
        float nearestDistance = float.MaxValue;

        GameObject[] allStickmen = GameObject.FindGameObjectsWithTag("Stickman");
        foreach (var stickman in allStickmen)
        {
            if (!caughtStickmen.Contains(stickman) && stickman.GetComponent<SticmkanListControl>().IsInHole == false)
            {
                float distance = Vector3.Distance(stickman.transform.position, transform.position);
                if (distance < nearestDistance)
                {
                    nearestStickman = stickman;
                    nearestDistance = distance;
                }
            }
        }

        return nearestStickman;
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
        for (int i = 0; i < caughtStickmen.Count;)
        {
            if (caughtStickmen.Count == 0) break;
            FindObjectOfType<Terazi>().Drop(0.1f);
            FindObjectOfType<Terazi>().EnemyText();
            caughtStickmen[0].transform.tag = "Untagged";
            caughtStickmen[0].transform.parent = libra.transform;
            FindObjectOfType<StickmanSpawner>().currentStickmen--;
            caughtStickmen[0].transform.DOJump(throwPose.transform.position, 1, 1, 0.5f);
            caughtStickmen.Remove(caughtStickmen[0]);
            yield return new WaitForSeconds(0.1f);
        }
        EnableControl();
    }
}
