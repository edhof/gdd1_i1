using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool _hasSpawn;
    private MoveScript _moveScript;
    private Collider2D _colliderComponent;
    private SpriteRenderer _rendererComponent;
    private FireScript _fireScript;
    
    private void Awake()
    {
        _fireScript = GetComponentInChildren<FireScript>();
        _moveScript = GetComponent<MoveScript>();
        _colliderComponent = GetComponent<Collider2D>();
        _rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _hasSpawn = false;
        _colliderComponent.enabled = false;
        _moveScript.enabled = false;
        _fireScript.enabled = false;
    }

    void Update()
    {
        if (_hasSpawn == false)
        {
            if (_rendererComponent.isVisible)
            {
                Spawn();
            }
        }
        else
        {
            if (_fireScript != null && _fireScript.enabled && _fireScript.CanFire)
            {
                _fireScript.Fire(true);
            }

            if (!_rendererComponent.isVisible)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activate itself.
    private void Spawn()
    {
        _hasSpawn = true;
        _colliderComponent.enabled = true;
        _moveScript.enabled = true;
        _fireScript.enabled = true;
    }
}
