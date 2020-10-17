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
        
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        _rigidbody2D.velocity = _movement;
    }
}
