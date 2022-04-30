using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCharacter : MonoBehaviour
{
    private Transform player;
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(player);
    }
}
