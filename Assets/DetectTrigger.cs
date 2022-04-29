using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.InflictDamage(transform.parent.GetComponent<Fireball>().damage, false, transform.parent.gameObject);
        }
        Destroy(transform.parent.gameObject);
    }
}
