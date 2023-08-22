using UnityEngine;

public class increaseCount : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public string itemName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // プレイヤーのアイテム数が上限に達していない場合のみゴミを拾う
            if (itemDatabase.GetItemByTag(itemName).count < itemDatabase.maxGomiCapacity)
            {
                itemDatabase.GetItemByTag(itemName).count++;
                // このスクリプトがアタッチされているゲームオブジェクトを破棄する
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("アイテムの所持上限に達しているため、ゴミを拾うことができません。");
            }
        }
    }
}
