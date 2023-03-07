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
    public GameObject throwPose2;
    public GameObject libra;

    public bool disableControl;
    [SerializeField] Gravity gravity;
    [SerializeField] InHole hole;
    [SerializeField] LayerChanger layerChanger;

    [SerializeField] Animator stickmen;
    [SerializeField] int stickmancounter;
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

        if (caughtStickmen.Count < 25)
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
    int counter;
    IEnumerator StickmanDrop()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < caughtStickmen.Count;)
        {
            if (caughtStickmen.Count == 0) break;
            //FindObjectOfType<Terazi>().Drop(0.1f);
            //FindObjectOfType<Terazi>().EnemyText();
            caughtStickmen[0].transform.tag = "Untagged";
            //caughtStickmen[0].transform.parent = libra.transform;
            FindObjectOfType<StickmanSpawner>().currentStickmen--;

            stickmancounter++;

            if (counter == 0)
            {
                counter++;
                caughtStickmen[0].transform.DOJump(throwPose.transform.position, 1, 1, 0.5f);
            }
            else if (counter == 1)
            {
                counter = 0;
                caughtStickmen[0].transform.DOJump(throwPose2.transform.position, 1, 1, 0.5f);
            }

            caughtStickmen.Remove(caughtStickmen[0]);
            yield return new WaitForSeconds(0.1f);
        }


        if (stickmancounter < 15)
        {
            stickmen.SetBool("1", true);
        }
        else if (stickmancounter < 25)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
        }
        else if (stickmancounter < 35)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
        }
        else if (stickmancounter < 45)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
        }
        else if (stickmancounter < 55)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
            stickmen.SetBool("5", true);
        }
        else if (stickmancounter < 65)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
            stickmen.SetBool("5", true);
            stickmen.SetBool("6", true);
        }
        else if (stickmancounter < 75)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
            stickmen.SetBool("5", true);
            stickmen.SetBool("6", true);
            stickmen.SetBool("7", true);
        }
        else if (stickmancounter < 85)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
            stickmen.SetBool("5", true);
            stickmen.SetBool("6", true);
            stickmen.SetBool("7", true);
            stickmen.SetBool("8", true);
        }
        else if (stickmancounter < 95)
        {
            stickmen.SetBool("1", true);
            stickmen.SetBool("2", true);
            stickmen.SetBool("3", true);
            stickmen.SetBool("4", true);
            stickmen.SetBool("5", true);
            stickmen.SetBool("6", true);
            stickmen.SetBool("7", true);
            stickmen.SetBool("8", true);
            stickmen.SetBool("9", true);
        }

        EnableControl();
    }
}
