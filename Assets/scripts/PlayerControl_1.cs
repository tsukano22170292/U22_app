using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_1 : MonoBehaviour
{
    [SerializeField] LayerMask BckgroundObjectLayer;
    [SerializeField] private ItemDatabase itemDatabase;

    Animator animator;
    bool isMoving;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        itemDatabase = Resources.Load<ItemDatabase>("ItemDatabase");
    }

    void Start()
    {
        gameObject.tag = "player";
    }

    void Update()
    {
        if (isMoving == false)
        {      
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x != 0)
            {
                y = 0;
            }

            if(x != 0 || y != 0)
            {
                 animator.SetFloat("InputX", x);
                animator.SetFloat("InputY", y);
                StartCoroutine(Move(new Vector2(x,y)));
            }
        }
        animator.SetBool("IsMoving", isMoving);

    }
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        if (IsWalkable(targetPos) == false)
        {
            isMoving = false;
            yield break;
        }
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, BckgroundObjectLayer) == false;
    }

    //塚野が追加したごみとの衝突処理用のメソッド
    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject != null)
        {
           string collidingObjectTag = collision.gameObject.tag;
            if (collidingObjectTag == "akikan" || collidingObjectTag == "cardboard" || collidingObjectTag == "petbottle")
            {
                Destroy(collision.gameObject);//他のオブジェクトに触れたら消える

                //アイテムデータの更新
                Item item = itemDatabase.GetItemByTag(collidingObjectTag);
                if(item != null)
                {
                    item.count++;
                }
            } 
        }
    }
}