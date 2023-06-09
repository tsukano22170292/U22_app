using UnityEngine;

public class Gomi_Drop : MonoBehaviour
{
    public GameObject objectPrefab; // オブジェクトのプレハブを格納する変数
    public GameObject objectPrefab2; //２個目のオブジェクト
    public GameObject objectPrefab3;
    public int objectCount = 10;
    public float spawnRangeX; // X軸の出現範囲
    public float spawnRangeY; // Y軸の出現範囲

    public LayerMask collisionLayer;

    void Start()
    {
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        spawnRangeX = cameraWidth;
        spawnRangeY = cameraHeight;
        
        for (int i = 0; i < objectCount; i++)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        float spawnPositionX = Random.Range(-spawnRangeX / 2f, spawnRangeX / 2f); // X軸のランダムな座標を生成
        float spawnPositionY = Random.Range(-spawnRangeY / 2f, spawnRangeY / 2f); // Y軸のランダムな座標を生成
        Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

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
            if(isOverlapping){
                Destroy(obj); //重なっていたらオブジェクトを破棄する
            }
        }

    }

    bool CheckOverlap(GameObject obj)
    {
        Vector2 colliderSize = GetComponent<BoxCollider2D>().size;
        //オブジェクトの中心を基準にして、当たり判定を持つオブジェクトとの重なりをチェック
        Collider2D[] colliders = Physics2D.OverlapBoxAll(obj.transform.position, colliderSize, 0, collisionLayer);
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