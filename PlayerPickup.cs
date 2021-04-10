using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickup : MonoBehaviour
{
    //Raycasting Variables
     public float RayLength = 5f;
    [SerializeField] private LayerMask RayLayers;
     private int LayerMask;

    //UI Variables
    public TMP_Text LabelText;

    //Parenting
    public Transform HandLocation;
    public Transform RayObject;

    public WeaponHandler wp;

    private void Update()
    {
        //Sets Layers to INT for Raycasting
        LayerMask = RayLayers.value;
        RaycastHit hit;

        //Debug Ray
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, RayLength, LayerMask)) {
            Debug.Log("HIT! " + hit.collider.name);
            //Enable Text 
            LabelText.text = "Press 'E' to pick up " + hit.collider.name;
            LabelText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E hit");
                RayObject = hit.collider.transform;

                //Set parent and copy Transform to set pos and rot
                RayObject.parent = HandLocation;
                RayObject.position = HandLocation.position;
                RayObject.rotation = HandLocation.rotation;

                RayObject.GetComponent<WeaponInfo>().Pickup();
                
                wp.LoadWeaponStats(RayObject.gameObject.GetComponent<WeaponInfo>());
            }
        }
        else HideLabel();
    }

    private void HideLabel()
    {
        LabelText.gameObject.SetActive(false);
        LabelText.text = null;
    }
}
