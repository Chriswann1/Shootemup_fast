using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _movement_;
    [SerializeField] private float _speed_;

    void Update()
    {
        _movement_ = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(_movement_.normalized * _speed_ * Time.deltaTime);
        
    }
    
}
