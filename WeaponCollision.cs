using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private Rigidbody rb;
    private float damage;

    public float x;
    public float y;
    public float z;
    public float xyzTotal;

    public float DamageSpeed;
    public int DamageDealt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        damage = GetComponent<WeaponInfo>().ColliderDamage;
    }

    private void Update() //This must be made more efficient, running Update() on a million weapons is NOT efficient. - J
    {
         x = Mathf.Clamp(Mathf.Abs(rb.velocity.x),0.5f, 10f);
         y = Mathf.Clamp(Mathf.Abs(rb.velocity.y), 0.5f, 10f);
         z = Mathf.Clamp(Mathf.Abs(rb.velocity.z), 0.5f, 10f);

        xyzTotal = x + y + z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && xyzTotal >= 5f)
        {
            DamageSpeed = xyzTotal;
            DamageDealt =Mathf.RoundToInt(xyzTotal * damage);

            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(DamageDealt);

        }
    }
}
