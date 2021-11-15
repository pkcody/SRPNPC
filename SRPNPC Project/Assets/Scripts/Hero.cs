using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NPC2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NPC.GetComponent<NPC>().TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            NPC2.GetComponent<NPC>().TakeDamage(20);
        }
    }
}
