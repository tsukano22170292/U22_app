using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemListChecker : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public TextMeshProUGUI[] itemCountTexts; // インベントリ内の各スロットのカウントを表示するTextコンポーネントの配列

    private void Start()
    {
        int itemCount = itemDatabase.items.Length;
        Debug.Log("Item List Count: " + itemCount);

        // 各アイテムのcountの値を出力する
        for (int i = 0; i < itemCount; i++)
        {
            int count = itemDatabase.items[i].count;
            Debug.Log("Item " + i + " Count: " + count);

            if (i < itemCountTexts.Length)
            {
                // インベントリ内の各スロットのTextコンポーネントにcountの値を表示する
                itemCountTexts[i].text = count.ToString();
            }
        }
    }

    private void Update()
    {
        // 各アイテムのcountの値を出力する
        for (int i = 0; i < itemDatabase.items.Length; i++)
        {
            int count = itemDatabase.items[i].count;

            if (i < itemCountTexts.Length)
            {
                // インベントリ内の各スロットのTextコンポーネントにcountの値を表示する
                itemCountTexts[i].text = count.ToString();
            }
        }
    }
}