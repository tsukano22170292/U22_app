using TMPro;
using UnityEngine;

public class totalMoneyOutput : MonoBehaviour
{
    // お金の合計を表示するテキスト
    public TextMeshProUGUI[] totalMoneyText;
    // アイテムデータベース
    public ItemDatabase itemDatabase;

    // Start is called before the first frame update
    void Start()
    {
        // お金の合計を表示するテキストを更新する
        foreach (TextMeshProUGUI text in totalMoneyText)
        {
            text.text = "かせいだお金" + itemDatabase.money.totalMoney.ToString() + "円";
        }
        
    }

}
