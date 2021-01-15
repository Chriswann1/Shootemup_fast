using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 speed = new Vector2(0.5f, 0.5f);
    private Vector2 bulletspeed;
    public int healthPts;
    public bool death;
    public double fireRate;

    [SerializeField]
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        /*if (healthPts <= 0 && !death)
        {
            death = true;
            Destroy(gameObject);
            GameplayManager.Instance.ShowGameOver();
        }*/
    }

    void Shoot()// commande le tir 
    {
        if (Time.time > time)
        {
            GameObject spawnedbullet = Instantiate(spawnedbullet, transform.position + bulletOffset, transform.rotation);//instancie la bullet
            spawnedbullet.GetComponent<Rigibody2D>().velocity = bulletspeed;//lui donne sa vitesse
            time = Time.time + fireRate;// lui limite sa cadence de tir
        }
    }
}
