using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public bool CanEvade = false;
    
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
    
    

    private void FixedUpdate()
    {
        if (CanEvade)
        {
            var leftBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0, 0)
            ).x;

            var rightBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(1, 0, 0)
            ).x;

            var topBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0.05f, 0)
            ).y;

            var bottomBorder = Camera.main.ViewportToWorldPoint(
                new Vector3(0, 0.7f, 0)
            ).y;
        
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(3,3), 0, Vector2.left);

            if (hit.collider != null && hit.collider.CompareTag("PlayerBullet"))
            {
                var vec = transform.position;
                float rand = Random.Range(-5f, 1f);
            
                if (rand <= 0)
                {
                    vec.y -= 10;
                }
                else
                {
                    vec.y += 10;
                }
            
            
                var pos = new Vector3(
                    Mathf.Clamp(vec.x, leftBorder, rightBorder),
                    Mathf.Clamp(vec.y, topBorder, bottomBorder),
                    0
                );

                this.transform.position = Vector2.MoveTowards(transform.position, pos, 0.1f);
            }
        }
    }
    

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
