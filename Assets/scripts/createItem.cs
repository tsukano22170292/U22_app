using UnityEngine;
using TMPro;

public class createItem : MonoBehaviour
{
    //アイテムデータベース
    public ItemDatabase itemDatabase;
    //アイテムのタグ
    public string itemTag;

    public TextMeshProUGUI successTexts; // 合成成功時に表示するTextコンポーネント
    
    public TextMeshProUGUI failTexts; //合成失敗時に表示するTextコンポーネント

    //アイテムの所持数を表示するTextコンポーネントの配列
    public TextMeshProUGUI[] itemCountTexts;

    // アイテムのIDを指定するint型の配列
    public int[] itemIDs;

    private int listCount = 0;

    private void Start()
    {
        int itemCount = itemDatabase.items.Length;
        Debug.Log("Item List Count: " + itemCount);

        // 各アイテムのcountの値をitemIDsの値に応じて出力する
        foreach (int itemID in itemIDs)
        {
            int count = itemDatabase.items[itemID].count;

            // インベントリ内の各スロットのTextコンポーネントにcountの値を表示する
            itemCountTexts[listCount].text = "所持数：" + count.ToString();
            listCount++;
        }
        listCount = 0;
    }

    private void Update()
    {
        // 各アイテムのcountの値をitemIDsの値に応じて出力する
        foreach (int itemID in itemIDs)
        {
            int count = itemDatabase.items[itemID].count;

            // インベントリ内の各スロットのTextコンポーネントにcountの値を表示する
            itemCountTexts[listCount].text = "所持数：" + count.ToString();
            listCount++;
        }
        listCount = 0;
    }
    
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

        //必要なアイテムの数が、インベントリ内のアイテムの数より多い場合は合成できない
        for(int i = 0; i < needList.Length; i++){
            Item targetItem = itemDatabase.GetItemByID(i);
            if(targetItem.count < needList[i]){
                Debug.Log("合成できません");
                //合成成功時に表示するTextコンポーネントを非アクティブにする
                successTexts.gameObject.SetActive(false);
                //合成失敗時に表示するTextコンポーネントをアクティブにする
                failTexts.gameObject.SetActive(true);
                //処理を終了する
                return;
            }
            //必要なアイテムを消費する
            targetItem.count -= needList[i];
        }

        
        //合成アイテムの数を増やす
        item.count += 1;
        Debug.Log("合成成功！");
        //合成失敗時に表示するTextコンポーネントを非アクティブにする
        failTexts.gameObject.SetActive(false);
        //合成成功時に表示するTextコンポーネントをアクティブにする
        successTexts.gameObject.SetActive(true);
        // synthesisCount（累計合成数）の値を加算する
        item.synthesisCount += 1;
    }
}
