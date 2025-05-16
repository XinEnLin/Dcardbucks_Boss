using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var health = collision.GetComponent<Player_health>();
            if (health != null)
            {
                //Debug.Log("💢 攻擊區觸發！扣血！");
                if(enemy.attackSpeed <= enemy.canAttack)
                {
                    Vector2 knockbackDir = (collision.transform.position - transform.position); // 玩家 - 敵人
                    health.UpdateHealth(-enemy.attackDamage, knockbackDir);
                    enemy.canAttack = 0f;
                }
                else
                {
                    enemy.canAttack += Time.deltaTime;
                }

                
            }
        }
    }
}
