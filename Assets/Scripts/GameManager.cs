using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private float respawnDelay = 2f;
    private bool isGameEnding=false;
    private int score;
    public Text scoreText;
    public Text winText;

    public GameObject WinnerUI;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();  //playercontroller sýnýfýna eriþim hierarchy için
    }

    public void RespawnPlayer()
    {
        // playerController.transform.position = playerController.respawnPoint; cororutine beklemeli baþlama için taþýyoruz.
        if (isGameEnding == false) {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine()); //("RespawnCoroutine") yazýlabilir.
        }
    }
    
    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //oyunbaþlangýcý deðiþti. yeniden baþlayýnca puan vesaire herþey sýfýrlandý.
        //playerController.transform.position = playerController.respawnPoint;
        //playerController.gameObject.SetActive(true);
        isGameEnding = false;
    }
        
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }
    
    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text ="seviye Tamamlandý. Toplam Puan " + score;
        Invoke("NextLevel", respawnDelay);  //metodu bekleme sonunda çalýþtýrýr.

    }
    public void NextLevet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //birsonraki scene
    }
}
