using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("🎯 玩家進入偵測圈，開始追蹤！");
            enemy.SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("🛑 玩家離開偵測圈，停止追蹤！");
            enemy.SetTarget(null);
        }
    }
}
