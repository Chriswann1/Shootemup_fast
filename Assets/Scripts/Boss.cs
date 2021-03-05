using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : scriptEnnemy1
{
    private Vector2 boundlimit;
    private Vector2 objectsize;
    [SerializeField] private Camera _camera_;
    private int dir = 1;
    private float fos = 120;
    private Vector3 origin;
    private float angle;
    private int bulletnumber = 5;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _camera_ = Camera.main;
        if (_camera_ != null) boundlimit = _camera_.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectsize = transform.GetComponent<SpriteRenderer>().bounds.extents;
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position + _bulletoffset_;
        if (transform.position.y + objectsize.y >= boundlimit.y || transform.position.y - objectsize.y <= -boundlimit.y)
        {
            dir = -dir;

        }
        
        transform.Translate(transform.up * speed * dir * Time.deltaTime);

        if (Time.time > firetime)
        {
            Shoot();
            firetime = Time.time + _fireRate_; // lui limite sa cadence de tir
        }
    }

    public override void Shoot()
    {
        
        angle = 45f;
        float angleIncrease = fos / bulletnumber;

        for (int i = 0; i < bulletnumber; i++)
        {
            _spawnedbullet_ = Instantiate(_bullet_, origin, transform.rotation);//instancie la bullet
            _spawnedbullet_.GetComponent<Rigidbody2D>().velocity = -AngleToVector3(angle) * _bulletspeed_;//lui donne sa vitesse

            angle -= angleIncrease;
        }
    }
    
    private Vector3 AngleToVector3(float angle)
    {
        float anglerad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(anglerad), Mathf.Sin(anglerad));
    }
}
