using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickmanColors : MonoBehaviour
{
    [Header("Player Colors")]

    [SerializeField] Color[] PlayerColors;
    [SerializeField] Color[] EnemyColors;
    [SerializeField] Color defaultColor;
    [SerializeField] Material mat;
    Material defmat;

    SkinnedMeshRenderer rend;
    Color selectedColor;

    int randomColor;

    private void Awake()
    {
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        defmat = rend.material;
    }


    public void DefaultColor()
    {
        rend.material.DOColor(defaultColor, 0.5f);
    }
    public void ChangeColor(bool enemy)
    {
        if (!enemy)
        {
            rend.material = mat;
            randomColor = Random.Range(0, PlayerColors.Length);
            selectedColor = EnemyColors[randomColor];
            rend.material.DOColor(PlayerColors[randomColor], 0.5f);
        }
        else
        {
            rend.material = mat;
            randomColor = Random.Range(0, EnemyColors.Length);
            selectedColor = EnemyColors[randomColor];
            rend.material.DOColor(EnemyColors[randomColor], 0.5f);
        }
    }
    public void DropColor()
    {
        rend.material = defmat;
        rend.material.DOColor(selectedColor, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallArea")
        {
        }
    }
}
