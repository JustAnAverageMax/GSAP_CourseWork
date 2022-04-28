using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    public float _obstacleRange = 5.0f;
    public bool _alive = true;
    public bool _isRotating = false;
    public bool _detectedPlayer;

    [SerializeField] private LayerMask _layerMask;
    private Collider _collider;
    private BoxCollider _boxCollider;
    [SerializeField] private GameObject[] _fireballsPrefab;
    private GameObject _fireball;
    private Agent _agent;

    [SerializeField]
    private Transform _firePos;

    private bool hitDetect;
    private RaycastHit hitInfo;

    public Vector3 targetRotation;
    public Quaternion rotateTo;


    private void Start()
    {
        _collider = GetComponent<Collider>();
        _alive = true;
        _agent = gameObject.GetComponent<Agent>();
    }

    private void OnDrawGizmos()
    {
        _collider = GetComponent<Collider>();
        _boxCollider = GetComponent<BoxCollider>();
#if UNITY_EDITOR
        hitDetect = Physics.BoxCast(_collider.bounds.center, _collider.bounds.size / 2, transform.forward, out hitInfo,
            transform.rotation, _obstacleRange, _layerMask);
#endif
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.TransformPoint(_boxCollider.center), transform.rotation,
            transform.lossyScale);
        Gizmos.matrix = rotationMatrix;

        //if (hitInfo.transform.gameObject.CompareTag("MinimapSprite")) return;
        if (hitDetect)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vector3.zero, Vector3.forward * hitInfo.distance);
            Gizmos.DrawWireCube(Vector3.forward * hitInfo.distance, _boxCollider.size);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(Vector3.zero, Vector3.forward * _obstacleRange);
            Gizmos.DrawWireCube(Vector3.forward * _obstacleRange, _boxCollider.size);
        }
    }


    private void FixedUpdate()
    {
        if (_alive && !_isRotating)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            if (!_detectedPlayer)
            {
                 hitDetect = Physics.BoxCast(_collider.bounds.center, _collider.bounds.size / 2, transform.forward,
                                out hitInfo,
                                transform.rotation, _obstacleRange, _layerMask);
            }
            else
            {
                
                Ray ray = new Ray(transform.position, transform.forward);
                hitDetect = Physics.Raycast(ray, out hitInfo, _layerMask);
            }
           
            if (hitDetect)
            {
                GameObject hitObject = hitInfo.transform.gameObject;


                if (hitObject.GetComponent<CharacterController>())
                {
                    _detectedPlayer = true;
                    _agent.isEnable = true;
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(0, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball], _firePos.position,
                            transform.rotation);
                    }
                }
                else if (hitInfo.distance < _obstacleRange && !hitObject.CompareTag("Lol"))
                {
                    Debug.Log(hitObject);
                    _detectedPlayer = false;
                    _agent.isEnable = false;
                    _isRotating = true;
                    float angleRotation = Random.Range(-90, 90);
                    targetRotation = Vector3.up * angleRotation; 
                    
                    rotateTo = Quaternion.Euler(transform.eulerAngles + targetRotation);
                    StartCoroutine(Rotate(rotateTo, 0.5f));
                }
            }
        }
    }

    private IEnumerator Rotate(Quaternion targetRotation, float time)
    {
        float elapsedTime = 0.0f;
        Quaternion startingRotation = transform.rotation; // have a startingRotation as well
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here

            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, (elapsedTime / time));
            yield return null;
        }

        _isRotating = false;
        
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}