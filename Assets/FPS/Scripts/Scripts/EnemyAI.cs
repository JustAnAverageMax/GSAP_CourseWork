using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//Базовый искуственный интелект
public class EnemyAI : MonoBehaviour
{
    //Параметры сценария
    public float speed = 5.0f;
    public float obstacleRande = 5.0f;
    public bool _alive = true;

    //Снаряды
    [SerializeField]
    private GameObject[] _fireballsPrefab;
    private GameObject _fireball;
    [SerializeField] private Transform raycastPos;
    private Agent _agent;
    
    private void Start()
    {
        _alive = true;
        _agent = gameObject.GetComponent<Agent>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = new Ray(raycastPos.position, transform.forward);
        Gizmos.DrawRay(ray);
    }

    private void Update()
    {
        if (_alive)
        {
            //Непрерывное движение вперед
            transform.Translate(0, 0, speed * Time.deltaTime);

            //Луч из объекта вперед
            Ray ray = new Ray(raycastPos.position, transform.forward);
            RaycastHit hit;//объект удара

            //Пускаем луч и проверяем 
            if (Physics.Raycast(ray, out hit))
            {
                //Получаем объект удара
                GameObject hitObject = hit.transform.gameObject;
                //Если объект удара игрок
                if (hitObject.GetComponent<CharacterController>())
                {
                    _agent.isEnable = true;
                    //Если огненого шара нет
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(0, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball], raycastPos.position, transform.rotation);

                    }
                }
                //Проверяем дистанцию до объекта впереди
                else if (hit.distance < obstacleRande)
                {
                    _agent.isEnable = false;
                    //Пора действовать
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
