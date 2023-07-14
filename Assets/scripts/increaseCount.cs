using UnityEngine;

public class increaseCount : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public string itemName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            itemDatabase.GetItemByTag(itemName).count++;
            //このスクリプトがアタッチされているゲームオブジェクトを破棄する
            Destroy(gameObject);
        }
    }
}
