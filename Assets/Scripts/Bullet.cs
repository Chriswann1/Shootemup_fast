using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float starttime;
    [SerializeField] private float lifetime;
    
    private void Start()
    {
        starttime = Time.time;
    }

    void Update()
    {
        if (Time.time >= starttime + lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
