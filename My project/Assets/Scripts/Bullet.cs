using System.Collections;
using UnityEngine;

public class Bullet : PoolObject
{

    TrailRenderer trail;
    float trailTime;

    Vector3 startPos;
    public int damage;
    public int speed;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HitManager>())
        {
            other.GetComponent<HitManager>().Damage(damage, startPos);
        }

        Destroy();
    }

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trailTime = trail.time;
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnObjectReuse()
    {
        trail.time = -1;
        Invoke("ResetTrail", 0.1f);
        transform.localScale = Vector3.one;
    }

    void ResetTrail()
    {
        trail.time = trailTime;
    }
}
