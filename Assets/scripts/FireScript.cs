using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shotRate = 0.1f;
    
    private float _cooldown;

    public bool CanFire
    {
        get
        {
            return _cooldown <= 0f;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }

    public void Fire(bool isEnemy)
    {
        if (CanFire)
        {
            _cooldown = shotRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.belongsToEnemy = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right; // towards in 2D space is the right of the sprite
            }
        }
    }
}
