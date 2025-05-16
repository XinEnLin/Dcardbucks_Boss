using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] public float attackDamage = 10f;
    [SerializeField] public float attackSpeed = 1f;
    public float canAttack;

    private Transform target;

    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    //public float GetAttackDamage()
    //{
    //    return attackDamage;
    //}
    //public float GetAttackSpeed()
    //{
    //    return attackSpeed;
    //}

    //public float GetCanAttack()
    //{
    //    return canAttack;
    //}
}
