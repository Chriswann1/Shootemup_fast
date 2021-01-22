using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using System.Security.Cryptography;

public class scriptEnnemy1 : MonoBehaviour
{
    public int healthPts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (healthPts <= 0)
        {
            GameplayManager.Instance.Score += 100;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "bullet")
        {
            healthPts--;
            Destroy(other.gameObject);
        }

    }
}
