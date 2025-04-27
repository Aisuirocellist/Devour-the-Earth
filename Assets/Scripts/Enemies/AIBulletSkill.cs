using UnityEngine;

[RequireComponent (typeof(EnemyPathfinding))]
public class AIBulletSkill : BulletSkill
{
    [SerializeField] Projectile bulletPrefab;
    private EnemyPathfinding enemyPathfinding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    public override void UseSkill()
    {
        Projectile bullet = Instantiate(bulletPrefab, bulletFirePoint.position, transform.rotation);

        bullet.SetDamage(GetDamage());
        bullet.SetSpeed(bulletSpeed);

        base.UseSkill();
    }

    protected override bool IsSkillUseTriggered()
    {
        return (enemyPathfinding.IsOnFight() || enemyPathfinding.getFaceingDoToHit()) && base.IsSkillUseTriggered();
    }
}
