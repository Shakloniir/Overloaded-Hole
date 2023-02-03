using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickmanColors : MonoBehaviour
{
    [Header ("Player Colors")]

    [SerializeField] Color[] PlayerColors;
    [SerializeField] Color[] EnemyColors;
    [SerializeField] Color defaultColor;

    SkinnedMeshRenderer rend;

    int randomColor;

    private void Awake()
    {
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
    }


    public void DefaultColor()
    {
        rend.material.DOColor(defaultColor, 0.5f);
    }
    public void ChangeColor(bool enemy)
    {
        if (!enemy)
        {
            randomColor = Random.Range(0, PlayerColors.Length);
            rend.material.DOColor(PlayerColors[randomColor], 0.5f);
        }
        else
        {
            randomColor = Random.Range(0, EnemyColors.Length);
            rend.material.DOColor(EnemyColors[randomColor],0.5f);
        }
    }
}
