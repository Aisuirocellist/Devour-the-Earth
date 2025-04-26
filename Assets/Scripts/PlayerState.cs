using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerState : State, Stunnable
{
    [SerializeField] Color hitColor;
    private SpriteRenderer sr;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private RelativeMovement movement;
    private MouseLook mouseLook;
    private RelativeShooter shooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<RelativeMovement>();
        mouseLook = GetComponent<MouseLook>();
        shooter = GetComponent<RelativeShooter>();
    }

    // Update is called once per frame
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(ReactOnHit());
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

    private IEnumerator ReactOnHit()
    {
        sr.color = hitColor;

        CamShake.Instance.shake(3f, 0.5f);
        yield return new WaitForSeconds(0.2f);

        if (!IsAlive())
        {
            SceneManager.LoadScene("Regroup Menu");
            Destroy(gameObject);
        }

        sr.color = Color.white;
    }

    private IEnumerator StunFor(float time)
    {
        isStunned = true;

        rb.linearVelocity = Vector3.zero;
        movement.enabled = false;
        mouseLook.enabled = false;
        shooter.enabled = false;

        yield return new WaitForSeconds(time);

        movement.enabled = true;
        mouseLook.enabled = true;
        shooter.enabled = true;

        isStunned = false;
    }
}
