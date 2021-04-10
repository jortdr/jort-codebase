using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float Sensitivity = 100f;

    public Transform PlayerBody;

    private float XRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Mouse Input
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        //Clamp to 90f to disable necksnap
        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);


        //Transform rotation to TransformObj
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * MouseX);

    }
}
