using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected GameObject hitEffect;
    private float damage = 1;
    private float speed = 5;

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(transform.up * (speed * Time.deltaTime), Space.World);
    }

    protected GameObject GetHitEffect()
    {
        return hitEffect;
    }

    protected float GetDamage()
    {
        return damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected float GetSpeed()
    {
        return speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        
    }
}
