using TMPro; 
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public TMP_Text winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }

            Debug.Log("Player Won!");
        }
    }
}
