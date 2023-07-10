using TMPro;
using UnityEngine;

public class moneyOutput : MonoBehaviour
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
            text.text = "かせいだおかね" + itemDatabase.money.totalMoney.ToString() + "えん";
        }
        
    }

}
