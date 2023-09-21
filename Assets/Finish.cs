using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource EndPhase;
    private bool CheckLevelComplete;

    // Start is called before the first frame update
    private void Start()
    {
        EndPhase = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !CheckLevelComplete)
        {
            EndPhase.Play();
            CheckLevelComplete = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
