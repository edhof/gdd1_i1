using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private FireScript _fireScript;
    
    private void Awake()
    {
        _fireScript = GetComponentInChildren<FireScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireScript != null && _fireScript.CanFire)
        {
            _fireScript.Fire(true);
        }
    }
}
