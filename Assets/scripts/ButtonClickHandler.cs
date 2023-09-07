using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject prefab;


    public void DeactivatePrefab()
    {
        // プレハブを非アクティブにする
        prefab.SetActive(false);
    }
    public void PlayPrefab()
    {
        // もしプレハブが非アクティブならば
        if (!prefab.activeSelf)
        {
            // プレハブをアクティブにする
            prefab.SetActive(true);
            // デバッグログを表示する
            Debug.Log("プレハブをアクティブにしました");
            // プレハブを１秒後に非アクティブにする
            Invoke("DeactivatePrefab", 1f);
        }
    }
}
