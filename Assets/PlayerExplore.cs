using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplore : MonoBehaviour
{
    [SerializeField] private Vector3 currentPos;
    [SerializeField]
    private Vector3 playerPosition;

    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        currentPos = transform.position;
        if (Vector3.Distance(transform.position, playerPosition) < 10.0f)
        {
            _spriteRenderer.enabled = true;
        }
    }
}
