using TMPro;
using UnityEngine;

public class GetTotalSynthesisCountOutput : MonoBehaviour
{
    // SynthesisCountの合計数を表示するテキスト
    public TextMeshProUGUI[] totalSynthesisCountText;
    // アイテムデータベース
    public ItemDatabase itemDatabase;

    // Start is called before the first frame update
    void Start()
    {
        // SynthesisCountの合計数を表示するテキストを更新する
        foreach (TextMeshProUGUI text in totalSynthesisCountText)
        {
            text.text = "リサイクルした回数" + itemDatabase.GetTotalSynthesisCount().ToString() + "回";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // SynthesisCountの合計数を表示するテキストを更新する
        foreach (TextMeshProUGUI text in totalSynthesisCountText)
        {
            text.text = "リサイクルした回数" + itemDatabase.GetTotalSynthesisCount().ToString() + "回";
        }   
    }
}
