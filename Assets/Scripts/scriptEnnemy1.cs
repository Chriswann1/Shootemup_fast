using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class scriptEnnemy1 : MonoBehaviour
{
    public int healthPts;
    [SerializeField] private protected float speed;
    private protected float firetime;
    [SerializeField] private protected float _fireRate_;
    private protected GameObject _spawnedbullet_;
    [SerializeField] private protected Vector3 _bulletoffset_;
    [SerializeField] private protected GameObject _bullet_;
    [SerializeField] private protected float _bulletspeed_;
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        Shoot();
    }
    
    public virtual void Shoot()// commande le tir 
    {
        if (Time.time > firetime)
        {
            firetime = Time.time + _fireRate_;// lui limite sa cadence de tir
            _spawnedbullet_ = Instantiate(_bullet_, transform.position + _bulletoffset_, transform.rotation);//instancie la bullet
            _spawnedbullet_.GetComponent<Rigidbody2D>().velocity = -Vector2.right * _bulletspeed_;//lui donne sa vitesse

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (healthPts <= 0)
        {
            GameplayManager.Instance.Score += 100;
            GameplayManager.Instance.scoreCount += 100;
            Destroy(gameObject);

        }
        
        if (other.gameObject.tag == "bullet")
        {
            healthPts--;
            Destroy(other.gameObject);
        }
    }
}
