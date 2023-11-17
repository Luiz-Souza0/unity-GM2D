using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    [SerializeField] private Text Text_tuto;
    public GameObject playe;
    public int coin;

    void Update()
    {
        coin = playe.GetComponent<ItemCollector>().coins;

        if (coin == 3)
        {
            Text_tuto.text = "Evite os espinhos e siga para passar de fase";
        }
    }



}
