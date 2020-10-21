using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static ParticlesScript Instance;

    public ParticleSystem Hearts;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void StartHearts(Vector3 position)
    {
        instantiate(Hearts, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        position.z = 0;
        
        ParticleSystem newParticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}
