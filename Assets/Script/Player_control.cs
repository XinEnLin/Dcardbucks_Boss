using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    public LayerMask SolidObject_layer;
    public LayerMask Interactable_layer;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogError("Animator component not found on this object!");
    }

    public void HandleUpdate()
    {


        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // ❗ 只允許單一方向移動（上下 or 左右）
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                Vector3 targetPos = transform.position;
                targetPos.x += input.x * moveSpeed * Time.deltaTime;
                targetPos.y += input.y * moveSpeed * Time.deltaTime;

                if (isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
                //else
                //Debug.Log("🚧 被牆擋住！");
            }
        }
        animator.SetBool("is_moving", isMoving);



        if (Input.GetKeyDown(KeyCode.Z))//按Z觸發interact
        {
            interact();
        }
    }

    void interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;
        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, Interactable_layer);
        if (collider != null)
        {
            //Debug.Log("there is a NPC!!");
            collider.GetComponent<interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

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
        bool hit = Physics2D.OverlapCircle(targetPos, 0.2f, SolidObject_layer) != null;
        //Debug.DrawLine(transform.position, targetPos, hit ? Color.red : Color.green, 0.2f);
        //Debug.Log("是否碰到牆：" + hit);
        return !hit;
    }
}

