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
        gameManager = FindObjectOfType<GameManager>(); //gamemanager ile ba�lant� kuruldu.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"));//score value gamemanager scriptinde olu�turulan bir metoda parametre olarak g�dnerilecek.
        {
            coinSound.Play();  // coin sesi �alar.
            gameManager.AddScore(scoreValue); //coinden skoru gamemanagere y�kledi.
            Destroy(this.gameObject);//objeyi ok et
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
