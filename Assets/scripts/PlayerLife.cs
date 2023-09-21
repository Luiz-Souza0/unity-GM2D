using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
 
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traa"))
        {

                rb.bodyType = RigidbodyType2D.Static;
                anim.SetTrigger("die");
       
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
//https://www.youtube.com/watch?v=ynH51MiKutY&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U&index=9