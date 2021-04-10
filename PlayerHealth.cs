using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] private GameObject DeathParticles;

    private PlayerUI H_UI;

    private void Start()
    {
        H_UI = GetComponent<PlayerUI>();
    }


    public void DamagePlayer(int dmg)
    {
        Health = Health - dmg;
        Instantiate(DeathParticles, transform.position, Quaternion.identity, transform);

        if (H_UI != null) H_UI.RefreshHealth(Health);
        else Debug.LogWarning("HealthUI Missing on " + gameObject.name);

        if (Health <= 0)
        {
            //Player Dead, do something
            Destroy(gameObject);
        }
    }

    public void HealPlayer(int value)
    {
        Health = Mathf.Clamp(Health + value, 1, 100);
    }
}
