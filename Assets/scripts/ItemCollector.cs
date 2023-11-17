using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ItemCollector : MonoBehaviour
{
    public int coins = 0;
    [SerializeField] private Text Coins_Text;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            Coins_Text.text = "Coins: " + coins;

        }
    }

}
