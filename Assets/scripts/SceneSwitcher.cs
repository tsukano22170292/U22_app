using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // x軸を指定する変数
    public float x;
    // y軸を指定する変数
    public float y;

    public string SceneName;
   
    private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
            // 次のシーンにxの値を渡す
            PlayerPrefs.SetFloat("x", x);
            // 次のシーンにyの値を渡す
            PlayerPrefs.SetFloat("y", y);
        }
    }
}