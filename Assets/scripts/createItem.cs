using UnityEngine;

public class createItem : MonoBehaviour
{
    //アイテムデータベース
    public ItemDatabase itemDatabase;
    //アイテムのタグ
    public string itemTag;
    
    public void Create()
    {
        //アイテムデータベースから合成アイテムを取得する
        SynthesisItem item = itemDatabase.GetSynthesisItemByTag(itemTag);
        //合成アイテムが取得できたらデバッグログにアイテムの名前と数を表示する
        if (item != null)
        {
            Debug.Log("必要な空き缶の数は" + item.needAkikan.ToString() + "こ");
            Debug.Log("必要な段ボールの数は" + item.needCardboard.ToString() + "こ");
            Debug.Log("必要なペットボトルの数は" + item.needPetbottle.ToString() + "こ");
            
        }
        else
        {
            Debug.Log("アイテムが見つかりませんでした");
        }

        //必要なアイテムの数を配列に入れる
        int[] needList = {item.needAkikan, item.needCardboard, item.needPetbottle};

        //必要なアイテムの数を引く
        for(int i = 0; i < needList.Length; i++){
            Item targetItem = itemDatabase.GetItemByID(i);
            targetItem.count -= needList[i];
        }

        //合成アイテムの数を増やす
        item.count += 1;
        Debug.Log("合成成功！");
    }
}
