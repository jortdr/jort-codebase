using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
/*    //Raycasting
    [SerializeField] private LayerMask RayLayers;
    private GameObject rayResult;
    private int LayerMask;

    public WeaponInfo info;

    public PlayerWeaponLink link;*/




/*    private void Update()
    {
        LayerMask = RayLayers.value;

        RaycastHit hit;


        //Debug Ray
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);

        //If mouse clicks, go check
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            //Raycast to player
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, LayerMask))
            {
                Debug.Log("Target Acuired | " + hit.collider.name);

                rayResult = hit.collider.gameObject;

                rayResult.GetComponent<PlayerHealth>().DamagePlayer(info.WeaponDamage);

            }
        }
    }*/
}
