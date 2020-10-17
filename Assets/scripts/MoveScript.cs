using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    
    public Vector2 enemySpeed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(
            enemySpeed.x * direction.x,
            enemySpeed.y * direction.y);
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
