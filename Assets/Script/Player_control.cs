using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float moveSpeed = 3f;
    //private float health = 0f;
    //[SerializeField] private float maxHealth = 100f;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public int cherry = 0;

    public LayerMask SolidObject_layer;
    public LayerMask Interactable_layer;

    //private void Start()
    //{
    //    health = maxHealth;
    //}

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on this object!");
        }
    }

    //public void UpdateHealth(float mod)
    //{
    //    health += mod;

    //    if (health > maxHealth)
    //    {
    //        health = maxHealth;
    //    }
    //    else if (health <= 0f)
    //    {
    //        health = 0f;
    //        Debug.Log("Player Respawn");
    //    }
    //}

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            // 取得玩家輸入（僅允許單一方向）
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            

            if (input != Vector2.zero)
            {
                // 設定動畫方向參數
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // ✅ 計算目標位置（normalize 讓斜向不變快）
                Vector3 direction = new Vector3(input.x, input.y).normalized;
                Vector3 targetPos = transform.position + direction * moveSpeed * Time.deltaTime;

                // 檢查是否可行走
                if (isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
                // else Debug.Log("🚧 被牆擋住！");
            }
        }

        // 更新動畫狀態
        animator.SetBool("is_moving", isMoving);

        // 互動輸入偵測
        if (Input.GetKeyDown(KeyCode.F))
        {
            interact();
        }
    }

    void interact()
    {
        // 根據動畫方向取得面對方向
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        // 嘗試取得可互動物件
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, Interactable_layer);
        if (collider != null)
        {
            collider.GetComponent<interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // 緩慢移動至目標位置
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

        animator.SetBool("is_moving", false);
    }

    private bool isWalkable(Vector3 targetPos)
    {
        // 使用碰撞偵測判斷是否可行走
        bool hit = Physics2D.OverlapCircle(targetPos, 0.2f, SolidObject_layer) != null;

        // Debug.DrawLine(transform.position, targetPos, hit ? Color.red : Color.green, 0.2f);
        // Debug.Log("是否碰到牆：" + hit);

        return !hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)//收集道具
    {
        if(collision.tag == "collection")
        {
            Destroy(collision.gameObject);
            cherry += 1;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag =="Enemy")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}
