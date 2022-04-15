using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplore : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            _spriteRenderer.enabled = true;
        }
    }
}
