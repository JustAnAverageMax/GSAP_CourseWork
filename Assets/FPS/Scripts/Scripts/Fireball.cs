using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;//скорость движения 
    public int damage = 1;//наносимый урон
    private GameObject parent;

    private void FixedUpdate()
    {
        transform.Translate(0,0,speed*Time.fixedDeltaTime);
    }
    

}
