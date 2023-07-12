using UnityEngine;
using TMPro;

public class SynthesisItemListChecker : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public TextMeshProUGUI[] synthesisItemCountTexts; // 合成アイテムリスト内の各スロットのカウントを表示するTextコンポーネントの配列

    private void Start()
    {
        int synthesisItemCount = itemDatabase.synthesisItems.Length;
        Debug.Log("Synthesis Item List Count: " + synthesisItemCount);

        // 各アイテムのcountの値を出力する
        for (int i = 0; i < synthesisItemCount; i++)
        {
            int count = itemDatabase.synthesisItems[i].count;
            Debug.Log("Synthesis Item " + i + " Count: " + count);

            if (i < synthesisItemCountTexts.Length)
            {
                // 合成アイテムリスト内の各スロットのTextコンポーネントにcountの値を表示する
                synthesisItemCountTexts[i].text = count.ToString();
            }
        }
    }
    
}
