using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI[] slotCountTexts;
    public ItemDatabase itemDatabase;

    private void Start()
    {
        // slotCountTextsの要素数をアイテムリストの要素数に合わせる
        slotCountTexts = new TextMeshProUGUI[itemDatabase.items.Length];

        // 各スロットのアイテム数を表示する
        for (int i = 0; i < slotCountTexts.Length; i++)
        {
            int itemCount = itemDatabase.items[i].count;
            slotCountTexts[i].text = itemCount.ToString();
        }
    }

    void Update()
    {
        // アイテムの所持数を更新する処理
        for (int i = 0; i < slotCountTexts.Length; i++)
        {
            int itemCount = itemDatabase.items[i].count;
            slotCountTexts[i].text = itemCount.ToString();
        }
    }
}
