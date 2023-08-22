using TMPro;
using UnityEngine;

public class moneyOutput : MonoBehaviour
{
    // お金を表示するテキスト
    public TextMeshProUGUI MoneyText;
    // アイテムデータベース
    public ItemDatabase itemDatabase;
    // Start is called before the first frame update
    void Start()
    {
        // お金を表示するテキストを更新する
        MoneyText.text = itemDatabase.money.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = itemDatabase.money.money.ToString();
    }
}
