using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public string WeaponName;
    public int WeaponDamage;
    public int CurrentLoad;
    public int MaxLoad;
    public int AmmoCount;
    [Range(0f,1f)]
    public float ColliderDamage;

    private Rigidbody rb;
    private MeshCollider mc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mc = GetComponent<MeshCollider>();
    }

    public void OverwriteData(int Current, int Ammo)
    {
        CurrentLoad = Current;
        AmmoCount = Ammo;
    }

    public void Pickup()
    {
        mc.enabled = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;
    }

    public void Drop()
    {
        transform.parent = null;
        rb.useGravity = true;
        rb.freezeRotation = false;
        mc.enabled = true;
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
    }
}
