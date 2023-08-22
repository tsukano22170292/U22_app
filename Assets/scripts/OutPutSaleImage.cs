using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutPutSaleImage : MonoBehaviour
{   
    public string itemTag;
    public ItemDatabase itemDatabase;
    public TextMeshProUGUI CountImage;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI StockText;
    public Image Completeimage;

    int count = 0;
    int price = 0;

    SynthesisItem item; // item をフィールドとして宣言する

    // Start is called before the first frame update
    void Start()
    {
        CountImage.text = count.ToString();
        PriceText.text = price.ToString();
        // itemTagを用いてアイテムデータベースから合成アイテムを取得する
        item = itemDatabase.GetSynthesisItemByTag(itemTag);

        StockText.text = "所持数：" + item.count.ToString();
    }

    public void AddCount()
    {
        count++;
    }

    public void SubCount()
    {
        count--;
    }

    public void CompleteImageFalse()
    {
        Completeimage.gameObject.SetActive(false);
    }
    
    public void SaleItem()
    {
        // 売却するアイテムの個数が0以下の場合は何もしない
        if (count <= 0)
        {
            return;
        }
        // 売却するアイテムの個数が0より大きい場合はアイテムを売却する
        else
        {
            // 売却するアイテムの個数を減らす
            item.count -= count;
            // 売却したアイテムの個数に応じてお金を増やす
            itemDatabase.money.money += price;
            itemDatabase.money.totalMoney += price;
            // 売却したアイテムの個数をリセットする
            count = 0;
            // CompleteImageをアクティブにする
            Completeimage.gameObject.SetActive(true);
            // 1秒後にCompleteImageを非アクティブにする
            Invoke("CompleteImageFalse", 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountImage.text = count.ToString();
        price = count * item.price;
        PriceText.text = price.ToString();
        StockText.text = "所持数：" + item.count.ToString();
    }
}
