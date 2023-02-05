using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNameGenerator : MonoBehaviour
{
    public TMP_Text text;
    public List<string> names = new List<string> { "John", "Jane", "Joe", "Emily", "Emma", "Ethan", "Ava", "Olivia", "Liam", "Sophia", "Mason", "Madison", "Noah", "Abigail", "Aiden", "Elizabeth", "Lucas", "Ella", "Mia", "Avery", "Isabelle", "Riley", "Aaliyah", "Aubrey", "Addison", "Evelyn", "Hazel", "Natalie", "Harper" };

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            int randomIndex = Random.Range(0, names.Count);
            text.text = names[randomIndex];
        }
    }
}
