using UnityEngine;
using UnityEngine.Tilemaps;

public class Gomi_Drop : MonoBehaviour
{
    public GameObject objectPrefab; // オブジェクトのプレハブを格納する変数
    public GameObject objectPrefab2; //２個目のオブジェクト
    public GameObject objectPrefab3;

    public int objectCount = 30;

    private Bounds tilemapBounds;

    public LayerMask collisionLayer;

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
            SpawnObject(spawnRangeX,spawnRangeY);
        }
        Debug.Log("tilemapBounds.min: " + tilemapBounds.min);
        Debug.Log("tilemapBounds.max: " + tilemapBounds.max);
    }

    private void SpawnObject(float spawnRangeX, float spawnRangeY)
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

        if (randomIndex == 0){
            obj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity); // オブジェクトを生成
        }else if (randomIndex == 1){
            obj = Instantiate(objectPrefab2, spawnPosition, Quaternion.identity); // オブジェクト２を生成
        }else{
            obj = Instantiate(objectPrefab3, spawnPosition, Quaternion.identity); // オブジェクト３を生成
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

    }

    bool CheckOverlap(GameObject obj)
    {
        Vector2 colliderSize = obj.GetComponent<BoxCollider2D>().size;
        //オブジェクトの中心を基準にして、当たり判定を持つオブジェクトとの重なりをチェック
        Collider2D[] colliders = Physics2D.OverlapBoxAll(obj.transform.position, colliderSize, 0,collisionLayer);
        return colliders.Length > 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OtherObject"))
        {
            Destroy(collision.gameObject); //他のオブジェクトに触れたら消える
        }
    }
}