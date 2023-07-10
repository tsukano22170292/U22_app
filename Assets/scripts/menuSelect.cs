using UnityEngine;
using UnityEngine.UI;

public class menuSelect : MonoBehaviour
{
    public GameObject trueImage;
    public GameObject falseImage;

    public void OnClickMenuButton()
    {
        Debug.Log("OnClickMenuButton called");
        falseImage.gameObject.SetActive(false);
        trueImage.gameObject.SetActive(true);
    }
}