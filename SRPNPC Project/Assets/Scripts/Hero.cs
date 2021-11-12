using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject NPC;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NPC.GetComponent<NPC>().TakeDamage(1);
        }
    }
}
