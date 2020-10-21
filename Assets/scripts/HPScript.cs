using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public int hitPoints = 1;
    public bool isEnemy = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            if (isEnemy)
            {
                ParticlesScript.Instance.StartHearts(transform.position);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ShotScript shot = other.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.belongsToEnemy != isEnemy)
            {
                Damage(shot.damage);
                if (!isEnemy)
                {
                    HealthBarScript.SetHealthBarValue(HealthBarScript.GetHealthBarValue() - 0.1f);
                }
                else
                {
                    ScoreHandler.AddToScore(100);
                }
                
                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
}
