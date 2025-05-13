using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float  speed = 10f;
    [SerializeField] private float attackDamage = 10f;
    private Transform target;

    private void Update()
    {
        if(target != null)
        {
            float step  = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_health>().UpdateHealth(-attackDamage);
            Debug.Log("敵人正在接觸玩家！");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target= collision.transform;
            //Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
            //Debug.Log(target);
        }
    }
}
