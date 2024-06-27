using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Controller : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera cam;
    [Header("Color")]
    [SerializeField] private Color color;
    [Header("Layer")]
    [SerializeField] private LayerMask layer;
    [Header("JumpForce")]
    [SerializeField] private float force;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            if (hit.collider !=null)
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
            }
        }
    }
}
