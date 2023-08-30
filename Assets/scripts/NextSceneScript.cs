using UnityEngine;

public class NextSceneScript : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        // PlayerPrefsから"x"というキーで保存された値を取得
        int x = PlayerPrefs.GetInt("x");
        // PlayerPrefsから"y"というキーで保存された値を取得
        int y = PlayerPrefs.GetInt("y");
        
        // プレイヤーの位置を変更
        player.transform.position = new Vector2(x, y);
    }
}
