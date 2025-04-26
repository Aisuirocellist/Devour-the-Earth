using UnityEngine;

public class EnemyBullet : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (hitEffect != null)
            Instantiate(hitEffect, transform.position + transform.up * 0.5f, transform.rotation);

        State state = collider.gameObject.GetComponent<State>();

        if (state != null && state is not EarthState)
        {
            state.TakeDamage(GetDamage());
        }

        Destroy(gameObject);
    }
}
