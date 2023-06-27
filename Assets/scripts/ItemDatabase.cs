using UnityEngine;

// インスペクター上でCreateメニューからこのスクリプトのインスタンスを作成できるようにする
[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Create Item Database")]
public class ItemDatabase : ScriptableObject
{
    public Item[] items;

    //タグ（ItemName）に基づいてアイテムを取得するメソッド
    public Item GetItemByTag(string tag)
    {
        // アイテムの配列をループして、タグに一致するアイテムを探す
        foreach (Item item in items)
        {
            //一致したらそのアイテムを返す
            if (item.itemName == tag)
            {
                return item;
            }
        }
        //一致しなかったらnullを返す
        return null;
    }
}

//アイテムのクラス
[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public int count;
    // 他に必要なアイテム情報を追加することができます
}