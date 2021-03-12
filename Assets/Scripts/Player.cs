using System;
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
     

    [SerializeField] private Vector3 _bulletoffset_;
    private GameObject _spawnedbullet_;
    [SerializeField] private GameObject _bullet_;
    [SerializeField] private float _bulletspeed_;
    [SerializeField] private float _fireRate_;
    private float firetime = 0;

    [SerializeField] private Camera _camera_;
    private Vector2 boundlimit;
    private Vector2 objectsize;



    private void Start()
    {
        boundlimit = _camera_.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectsize = transform.GetComponent<SpriteRenderer>().bounds.extents;
        
    }

    void Update()
    { }/*
        _movement_ = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(_movement_.normalized * _speed_ * Time.deltaTime);
        Correctpos();

        if(healthPts <= 0) Destroy(this.gameObject);

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        /*if (healthPts <= 0 && !death)
        {
            death = true;
            Destroy(gameObject);
            GameplayManager.Instance.ShowGameOver();
        }

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

    void Shoot()// commande le tir 

    {

        if (Time.time > time)

        {

            GameObject spawnedbullet = Instantiate(spawnedbullet, transform.position + _bulletoffset_, transform.rotation);//instancie la bullet

            spawnedbullet.GetComponent<Rigidbody2D>().velocity = bulletspeed;//lui donne sa vitesse

            time = Time.time + fireRate;// lui limite sa cadence de tir

        }

    }

    void Correctpos()
    {
        Vector2 correctedpos;
        correctedpos = transform.position;
        correctedpos.x = Mathf.Clamp(correctedpos.x, boundlimit.x * -1 + objectsize.x, boundlimit.x - objectsize.x);
        correctedpos.y = Mathf.Clamp(correctedpos.y, boundlimit.y * -1 + objectsize.y, boundlimit.y - objectsize.y);
        transform.position = correctedpos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            healthPts--;
            Destroy(other.gameObject);
        }
    }*/
}
