using UnityEngine;
using UnityEngine.SceneManagement;

public class scene2 : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.gameObject.CompareTag("Player"))
        {
         SceneManager.LoadScene("map");
        }
    }
}