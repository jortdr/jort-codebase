using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    //Raycasting
    [SerializeField] private LayerMask RayLayers;
    private GameObject rayResult;
    private int LayerMask;

    public WeaponInfo W_Info;
    public PlayerUI W_UI;

    //Current Stats
    public int CurrentLoad;
    public int MaxLoad;
    public int AmmoCount;
    public int WeaponDamage;

    private void Update()
    {
        LayerMask = RayLayers.value;
        RaycastHit hit;


        //Debug Ray
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);

        //If mouse clicks, go check
        if (Input.GetMouseButtonDown(0) && CurrentLoad > 0)
        {
            
            Debug.Log("Clicked");
            CurrentLoad = CurrentLoad - 1;
            UpdateUI();

            //Raycast to player
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, LayerMask))
            {
                Debug.Log("Target Acuired | " + hit.collider.name);

                rayResult = hit.collider.gameObject;

                rayResult.GetComponent<PlayerHealth>().DamagePlayer(WeaponDamage);

            }
        }

        //More Buttons
        if (Input.GetKeyDown(KeyCode.R)) Reload();
        if (Input.GetKeyDown(KeyCode.Q)) DropWeapon();
    }

    private void Reload()
    {

        if (CurrentLoad == MaxLoad) { }
        else
        {
            int LoadAmount = Mathf.Min(MaxLoad - CurrentLoad, AmmoCount);
            CurrentLoad += LoadAmount;
            AmmoCount = AmmoCount - LoadAmount;

            UpdateUI();
        }
    }

    public void LoadWeaponStats(WeaponInfo inf)
    {
        CurrentLoad = inf.CurrentLoad;
        MaxLoad = inf.MaxLoad;
        AmmoCount = inf.AmmoCount;
        WeaponDamage = inf.WeaponDamage;

        UpdateUI();
        W_Info = inf;
    }

    private void UpdateUI()
    {
        W_UI.RefreshAmmo(CurrentLoad, AmmoCount);
    }

    private void DropWeapon()
    {
        //Don't forget to save bullets loaded and ammo associated to gun before dropping
        W_Info.OverwriteData(CurrentLoad, AmmoCount);

        CurrentLoad = 0;
        AmmoCount = 0;
        MaxLoad = 0;
        WeaponDamage = 0;

        W_Info.gameObject.GetComponent<MeshCollider>().enabled = true;
        W_Info.Drop();

        UpdateUI();
    }

}
