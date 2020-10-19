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
    private FireScript[] _fireScripts;
    
    private void Awake()
    {
        _fireScripts = GetComponentsInChildren<FireScript>();
        _moveScript = GetComponent<MoveScript>();
        _colliderComponent = GetComponent<Collider2D>();
        _rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _hasSpawn = false;
        _colliderComponent.enabled = false;
        _moveScript.enabled = false;
        foreach (var script in _fireScripts)
        {
            script.enabled = false;
        }
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
            foreach (var script in _fireScripts)
            {
                if (script != null && script.enabled && script.CanFire)
                {
                    script.Fire(true);
                }
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
        foreach (var script in _fireScripts)
        {
            script.enabled = true;
        }
    }
}
