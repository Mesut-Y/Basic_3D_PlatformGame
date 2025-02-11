using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameManager gameManager;
    public int scoreValue;
    public AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //gamemanager ile baðlantý kuruldu.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"));//score value gamemanager scriptinde oluþturulan bir metoda parametre olarak gödnerilecek.
        {
            coinSound.Play();  // coin sesi çalar.
            gameManager.AddScore(scoreValue); //coinden skoru gamemanagere yükledi.
            Destroy(this.gameObject);//objeyi ok et
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
