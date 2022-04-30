using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private float damage = 0.1f;
    [SerializeField] private float slowCoefficient = 0.4f;

    private float _playerSlowCoefficient;
    private PlayerCharacterController _playerCharacterController;
    private void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        _playerCharacterController = other.GetComponent<PlayerCharacterController>();
        if (_playerCharacterController)
        {
            _playerSlowCoefficient = _playerCharacterController.SlowCoefficient;
            _playerCharacterController.SlowCoefficient = slowCoefficient;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.InflictDamage(damage, false, gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        _playerCharacterController.SlowCoefficient = _playerSlowCoefficient;
    }
}
