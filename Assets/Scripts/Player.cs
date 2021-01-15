using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    private Vector2 _movement_;
    [SerializeField] private float _speed_;

    [SerializeField] private Vector2 _bulletoffset_;
    private GameObject _spawnedbullet_;
    [SerializeField] private GameObject _bullet_;
    [SerializeField]private Vector2 _bulletspeed_;
    [SerializeField]private float fireRate;
    private float firetime;
    
    
    public int healthPts;
    public bool death;


    void Update()
    {
        _movement_ = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(_movement_.normalized * _speed_ * Time.deltaTime);
        

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
        if (Time.time > firetime)
        {
            _spawnedbullet_ = Instantiate(_spawnedbullet_, transform.position * _bulletoffset_, transform.rotation);//instancie la bullet
            _spawnedbullet_.GetComponent<Rigidbody2D>().velocity = _bulletspeed_;//lui donne sa vitesse
            firetime = Time.time + fireRate;// lui limite sa cadence de tir
        }

    }
    
}
