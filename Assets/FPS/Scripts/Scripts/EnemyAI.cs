using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    public float _obstacleRange = 5.0f;
    public bool _alive = true;


    private Collider _collider;
    
    [SerializeField]
    private GameObject[] _fireballsPrefab;
    private GameObject _fireball;
    private Agent _agent;
    
    

    private bool hitDetect;
    private RaycastHit hitInfo;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _alive = true;
        _agent = gameObject.GetComponent<Agent>();
    }
    private void OnDrawGizmos()
      {
          if (hitDetect)
          {
              Gizmos.color = Color.red;
              Gizmos.DrawRay(transform.position, transform.forward * hitInfo.distance);
              Gizmos.DrawWireCube(transform.position + transform.forward * hitInfo.distance, transform.localScale);
          }
          else
          {
              Gizmos.color = Color.green;
              Gizmos.DrawRay(transform.position, transform.forward*_obstacleRange);
          }
      }

    

    private void FixedUpdate()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            
            hitDetect = Physics.BoxCast(transform.position, transform.localScale/2, transform.forward, out hitInfo, transform.rotation, _obstacleRange);
            if (hitDetect)
            {
                GameObject hitObject = hitInfo.transform.gameObject;
                if (hitObject.GetComponent<CharacterController>())
                {
                    _agent.isEnable = true;
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(0, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball], transform.position, transform.rotation);

                    }
                }
                else if (hitInfo.distance < _obstacleRange)
                {
                    _agent.isEnable = false;
                    float angleRotation = Random.Range(-100, 100);//выбираем угол поворота
                    transform.Rotate(0, angleRotation, 0);//поворачиваемся
                }
            }
        }        
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
