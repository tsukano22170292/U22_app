using UnityEngine;

// インスペクター上でCreateメニューからこのスクリプトのインスタンスを作成できるようにする
[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Create Item Database")]
public class ItemDatabase : ScriptableObject
{
    public Item[] items;
    public Money money;
    public SynthesisItem[] synthesisItems;

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

    //アイテムのIDに基づいてアイテムを取得するメソッド
    public Item GetItemByID(int id)
    {
        // アイテムの配列をループして、IDに一致するアイテムを探す
        foreach (Item item in items)
        {
            //一致したらそのアイテムを返す
            if (item.itemID == id)
            {
                return item;
            }
        }
        //一致しなかったらnullを返す
        return null;
    }

    //全てのアイテムの合計数を返すメソッド
    public int GetTotalCount()
    {
        int totalCount = 0;
        // アイテムの配列をループして、アイテムの数を合計する
        foreach (Item item in items)
        {
            totalCount += item.count;
        }
        //合計数を返す
        return totalCount;
    }

    //SynthesisItemのsynthesisItemIDに基づいてアイテムを取得するメソッド
    public SynthesisItem GetSynthesisItemByTag(string tag)
    {
        // アイテムの配列をループして、タグに一致するアイテムを探す
        foreach (SynthesisItem synthesisItem in synthesisItems)
        {
            //一致したらそのアイテムを返す
            if (synthesisItem.itemName == tag)
            {
                return synthesisItem;
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
    public Texture2D itemImage;
    // 他に必要なアイテム情報を追加することができます
}

//お金のクラス
[System.Serializable]
public class Money
{
    public int money;
    //今まで獲得したお金の合計を保存する変数
    public int totalMoney;
}

//合成アイテムのクラス
[System.Serializable]
public class SynthesisItem
{
    public string itemName;
    public int synthesisItemID;
    public int count;
    public Texture2D itemImage;
    public int needAkikan;
    public int needCardboard;
    public int needPetbottle;
    // 他に必要なアイテム情報を追加することができます
}