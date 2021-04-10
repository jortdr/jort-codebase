using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHealth : MonoBehaviour
{
    public int BoostValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().HealPlayer(BoostValue);
        }
    }
}
