using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalaxe : MonoBehaviour
{
    private float lenght, startPosition;
    public float parallaxe;
    public GameObject MainCam;

    public bool Infinite;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = MainCam.transform.position.x * (1 - parallaxe);
        float dist = MainCam.transform.position.x * parallaxe;

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (Infinite)
        {
            if (temp > startPosition + lenght)
            {
                startPosition += lenght;
            }
                
            else if ( temp < startPosition - lenght)
            {
                startPosition -= lenght;
            }
                
        }
    }
}
