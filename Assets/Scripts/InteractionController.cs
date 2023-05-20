using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private string[] _layers;
    private LayerMask _layerMask;
    private Vector2 _aimDirection;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(_layers);
    }

    private void Update()
    {
        var aim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (aim.magnitude > 0)
        {
            _aimDirection = aim;
        }

        if (!Input.GetButtonDown("Fire1")) return;
        
        Interact();
    }

    private void Interact()
    {
        var raycastHits = Physics2D.RaycastAll(transform.position, _aimDirection, 1f, _layerMask);
        
        if (raycastHits.Length == 0) return;

        if (raycastHits[0].transform.CompareTag("NPC"))
        {
            Debug.Log(raycastHits[0].transform.name);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, _aimDirection, Color.red);
    }
}
