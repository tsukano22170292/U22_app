using UnityEngine;
using UnityEngine.UI;

public class talk1 : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

    public GameObject image;

    [SerializeField]
    string words = "ここにセリフ";

    private bool isColliding = false;
    private bool isTextVisible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isColliding)
            {
                if (isTextVisible)
                {
                    dialogue.SetActive(false);
                    isTextVisible = false;
                    //もし、imageがあれば  
                    if (image != null)
                    {
                        image.SetActive(false);
                    }
                }
                else
                {
                    Text.text = words;
                    dialogue.SetActive(true);
                    isTextVisible = true;
                    //もし、imageがあれば
                    if (image != null)
                    {
                        image.SetActive(true);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
            dialogue.SetActive(false);
            isTextVisible = false;
            if (image != null)
            {
                image.SetActive(false);
            }
        }
    }
}