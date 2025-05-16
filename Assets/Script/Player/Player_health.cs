using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_health : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    //[Header("Knockback 設定")]
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

        //// Knockback 手動位移
        //if (knockbackDir.HasValue)
        //{
        //    Vector3 displacement = (Vector3)(knockbackDir.Value.normalized * knockbackForce * 0.1f); // 調整縮放
        //    transform.position += displacement;
        //}
    }

    
}
