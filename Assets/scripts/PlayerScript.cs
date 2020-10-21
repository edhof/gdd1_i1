using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 playerSpeed = new Vector2(20, 20);

    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        HealthBarScript.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("player_speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        _movement = new Vector2(
            playerSpeed.x * x,
            playerSpeed.y * y
            );

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            FireScript script = GetComponent<FireScript>();
            if (script != null)
            {
                script.Fire(false);
            }
        }
        
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0.05f, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0.7f, dist)
        ).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        _rigidbody2D.velocity = _movement;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var damagePlayer = false;
        
        var enemy = other.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            var enemyHealth = enemy.GetComponent<HPScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hitPoints);
            }

            damagePlayer = true;
        }

        if (damagePlayer)
        {
            var playerHealth = this.GetComponent<HPScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
                HealthBarScript.SetHealthBarValue(HealthBarScript.GetHealthBarValue() - 0.1f);
            }
        }
    }
}
