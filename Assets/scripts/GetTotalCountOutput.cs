using TMPro;
using UnityEngine;

public class GetTotalCountOutput : MonoBehaviour
{
    // アイテムの合計数を表示するテキスト
    public TextMeshProUGUI[] totalCountText;
    // アイテムデータベース
    public ItemDatabase itemDatabase;

    // Start is called before the first frame update
    void Start()
    {
        // アイテムの合計数を表示するテキストを更新する
        foreach (TextMeshProUGUI text in totalCountText)
        {
            text.text = "拾ったごみの数" + itemDatabase.GetTotalCount().ToString() + "こ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // アイテムの合計数を表示するテキストを更新する
        foreach (TextMeshProUGUI text in totalCountText)
        {
            text.text = "拾ったごみの数" + itemDatabase.GetTotalCount().ToString() + "こ";
        }   
    }
}
