using System.Collections;
using UnityEngine;

public class EnemyState : State, Stunnable
{
    [SerializeField] Color hitColor;
    private SpriteRenderer sr;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private EnemyPathfinding enemyPathfinding;
    private EnemySkill skill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        skill = GetComponent<EnemySkill>();
    }

    public bool IsStunned()
    {
        return isStunned;
    }

    public void GetStunned(float time)
    {
        StopCoroutine(StunFor(time));
        StartCoroutine(StunFor(time));
    }

    // Update is called once per frame
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(ReactOnHit());
    }

    private IEnumerator ReactOnHit()
    {
        sr.color = hitColor;
        GetComponent<EnemyPathfinding>().setAttackingDoToHit();

        yield return new WaitForSeconds(0.2f);

        if (!IsAlive())
        {
            GetComponent<DeathScript>().assimilate();

            if (transform.parent != null)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject);
        }

        sr.color = Color.white;
    }

    private IEnumerator StunFor(float time)
    {
        isStunned = true;

        rb.linearVelocity = Vector3.zero;
        enemyPathfinding.enabled = false;
        skill.enabled = false;

        yield return new WaitForSeconds(time);

        enemyPathfinding.enabled = true;
        skill.enabled = true;

        isStunned = false;
    }
}
