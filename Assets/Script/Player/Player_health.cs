using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_health : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    //[Header("Knockback �]�w")]
    public float knockbackForce = 5f;

    private Rigidbody2D rb;
    

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdateHealth(float mod, Vector2? knockbackDir = null)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player Respawn");
        }

        //// Knockback ��ʦ첾
        //if (knockbackDir.HasValue)
        //{
        //    Vector3 displacement = (Vector3)(knockbackDir.Value.normalized * knockbackForce * 0.1f); // �վ��Y��
        //    transform.position += displacement;
        //}
    }

    
}
