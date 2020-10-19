using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float length;
    private float start;
    public GameObject Camera;
    public float ParallaxEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = Camera.transform.position.x * (1 - ParallaxEffect);
        var dist = Camera.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);

        if (temp > start + length)
        {
            start += length;
        }
        else if (temp < start - length)
        {
            start -= length;
        }
    }
}
