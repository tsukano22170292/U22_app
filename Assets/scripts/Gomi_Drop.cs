using UnityEngine;
using UnityEngine.Tilemaps;

public class Gomi_Drop : MonoBehaviour
{
    public GameObject object_akikan; // オブジェクトのプレハブを格納する変数
    public GameObject object_cardboard; //２個目のオブジェクト
    public GameObject object_petbottle;

    public int objectCount = 30; //オブジェクトを生成する数

    private Bounds tilemapBounds;

    public LayerMask collisionLayer;

    public GameObject generatedObject; //他のスクリプトで生成されたオブジェクトを参照するための変数

    void Start()
    {   
        //デバッグログの追加
        //Debug.Log("Start() method called.");

        //タイルマップの範囲を取得
        GameObject grid = GameObject.Find("Grid");
        TilemapRenderer tilemapRenderer = grid.GetComponentInChildren<TilemapRenderer>();
        tilemapBounds = tilemapRenderer.bounds;
        float spawnRangeX = tilemapBounds.size.x;
        float spawnRangeY = tilemapBounds.size.y;

        //objectCountの数だけオブジェクトを生成する        
        for (int i = 0; i < objectCount; i++)
        {
            generatedObject = SpawnObject(spawnRangeX,spawnRangeY);
        }
        Debug.Log("tilemapBounds.min: " + tilemapBounds.min);
        Debug.Log("tilemapBounds.max: " + tilemapBounds.max);
    }

    private GameObject SpawnObject(float spawnRangeX, float spawnRangeY)
    {
        //デバッグログの追加
        //Debug.Log("Spawning object.");

        float spawnPositionX = Random.Range(tilemapBounds.min.x, tilemapBounds.max.x); // X軸のランダムな座標を生成
        float spawnPositionY = Random.Range(tilemapBounds.min.y, tilemapBounds.max.y); // Y軸のランダムな座標を生成
        Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

        // オブジェクトが生成される予定の座標を一時的に保持
        Vector2 spawnPositionTemp = new Vector2(spawnPosition.x, spawnPosition.y);

        int randomIndex = Random.Range(0, 3); //０または２のランダムな値を生成

        GameObject obj = null; // GameObject オブジェクトの宣言と初期化

        if (randomIndex == 0)
        {
            obj = Instantiate(object_akikan, spawnPosition, Quaternion.identity); // オブジェクト１を生成
            obj.tag = "akikan";//オブジェクト１にタグを設定
        }
        else if (randomIndex == 1)
        {
            obj = Instantiate(object_cardboard, spawnPosition, Quaternion.identity); // オブジェクト２を生成
            obj.tag = "cardboard";//オブジェクト２にタグを設定
        }
        else
        {
            obj = Instantiate(object_petbottle, spawnPosition, Quaternion.identity); // オブジェクト３を生成
            obj.tag = "petbottle";//オブジェクト３にタグを設定
        }
        
        if (obj != null){
            //生成したオブジェクトにコライダーを追加する
            obj.AddComponent<BoxCollider2D>();
            obj.SetActive(true); //表示する

            //重なりをチェック。重なっていたらtrue
            bool isOverlapping = CheckOverlap(obj);
            Debug.Log("isOverlapping:" + isOverlapping);
            if(isOverlapping){
                //オブジェクトが生成されるはずだった座標をデバッグログに表示
                Debug.Log("Expected spaw position" + spawnPositionTemp);

                Destroy(obj); //重なっていたらオブジェクトを破棄する
            }
        }

        return obj;
    }

    bool CheckOverlap(GameObject obj)
    {
        Vector2 colliderSize = obj.GetComponent<BoxCollider2D>().size;
        //オブジェクトの中心を基準にして、当たり判定を持つオブジェクトとの重なりをチェック
        Collider2D[] colliders = Physics2D.OverlapBoxAll(obj.transform.position, colliderSize, 0,collisionLayer);
        return colliders.Length > 0;
    }
}