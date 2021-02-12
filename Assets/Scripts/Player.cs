using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _movement_;
    [SerializeField] private float _speed_;

    [SerializeField] private Vector3 _bulletoffset_;
    private GameObject _spawnedbullet_;
    [SerializeField] private GameObject _bullet_;
    [SerializeField] private float _bulletspeed_;
    [SerializeField] private float _fireRate_;
    private float firetime = 0;

    [SerializeField] private Camera _camera_;
    private Vector2 boundlimit;
    private Vector2 objectsize;


    public int healthPts;
    public bool death;

    private void Start()
    {
        boundlimit = _camera_.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectsize = transform.GetComponent<SpriteRenderer>().bounds.extents;
        
    }

    void Update()
    {
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
        }*/

        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

    void Shoot()// commande le tir 
    {
        if (Time.time > firetime)
        {
            firetime = Time.time + _fireRate_;// lui limite sa cadence de tir
            _spawnedbullet_ = Instantiate(_bullet_, transform.position + _bulletoffset_, transform.rotation);//instancie la bullet
            _spawnedbullet_.GetComponent<Rigidbody2D>().velocity = Vector2.right * _bulletspeed_;//lui donne sa vitesse

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
        if (other.CompareTag("EnemyBullet")) healthPts--;
    }
}
