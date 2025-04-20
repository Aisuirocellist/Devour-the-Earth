using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthState : State
{
    [SerializeField] Color hitColor;
    //private GameObject Spawner1, Spawner0;
    [SerializeField] GameObject Spawner2;
    [SerializeField] GameObject Spawner3;
    private SpriteRenderer sr;
    private int stage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();
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

        yield return new WaitForSeconds(0.2f);

        if (GetHealth() <= 0)
        {
            Destroy(gameObject);
            //Application.Quit();
            SceneManager.LoadScene("Main Menu");
        } 
        else if (stage == 3 && GetHealth() <= 25) // STAGE 5
        {
            stage = 4;
        } 
        else if (stage == 2 && GetHealth() <= 50) // STAGE 4
        {
            Instantiate(Spawner3);
            stage = 3;
        } 
        else if (stage == 1 && GetHealth() <= 75) // STAGE 3
        {
            Instantiate(Spawner2);
            stage = 2;
        }

        sr.color = Color.white;
    }

}
