using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private float damage = 0.1f;    
    
    private void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.InflictDamage(damage, false, gameObject);
        }
    }
}
