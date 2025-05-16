using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ? ����a��q�B���`�P�]�i��^�������h�޿�
/// </summary>
public class Player_health : MonoBehaviour
{
    private float health = 0f;                      // �ثe��q
    [SerializeField] private float maxHealth = 100f; // �̤j��q�]�i�b Inspector �վ�^

    //public Header("Knockback �]�w")
    public float knockbackForce = 5f;               // ���h�ɪ��O�D�j�p�]�ثe���ϥΡ^

    private Rigidbody2D rb;                         // ���a����A�ΨӨ��o�첾�P���z�����ާ@

    private void Start()
    {
        health = maxHealth;                         // �C���}�l�ɪ�l�Ʀ�q
        rb = GetComponent<Rigidbody2D>();           // ��� Rigidbody2D �ե�
    }

    /// <summary>
    /// ? ��s��q�ƭȡ]���Ȭ��^��A�t�Ȭ�����^
    /// �i��ܶǤJ���h��V�@�� knockback
    /// </summary>
    /// <param name="mod">��q�ܤƶq�]���ƥ[��A�t�Ʀ���^</param>
    /// <param name="knockbackDir">�i��G�����ɪ���V�V�q</param>
    public void UpdateHealth(float mod, Vector2? knockbackDir = null)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth; // ���W�L�̤j��
        }
        else if (health <= 0f)
        {
            health = 0f;        // ���`�B�z�]���B�Ȯɥu�L�X�T���^
            Debug.Log("Player Respawn");
        }

        // ? �H�U�����h�\��]�ثe���ѡ^
        // �Y�ҥΥi�����a���������V����@�q�Z���]�ݤ�ʸѶ}�H�U�϶��^

        //// Knockback ��ʦ첾�]�w�� Kinematic ���a�^
        //if (knockbackDir.HasValue)
        //{
        //    Vector3 displacement = (Vector3)(knockbackDir.Value.normalized * knockbackForce * 0.1f); // �վ��Y��
        //    transform.position += displacement;
        //}
    }
}
