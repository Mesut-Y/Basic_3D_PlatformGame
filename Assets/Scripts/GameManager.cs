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
        playerController = FindObjectOfType<PlayerController>();  //playercontroller s�n�f�na eri�im hierarchy i�in
    }

    public void RespawnPlayer()
    {
        // playerController.transform.position = playerController.respawnPoint; cororutine beklemeli ba�lama i�in ta��yoruz.
        if (isGameEnding == false) {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine()); //("RespawnCoroutine") yaz�labilir.
        }
    }
    
    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //oyunba�lang�c� de�i�ti. yeniden ba�lay�nca puan vesaire her�ey s�f�rland�.
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
        winText.text ="seviye Tamamland�. Toplam Puan " + score;
        Invoke("NextLevel", respawnDelay);  //metodu bekleme sonunda �al��t�r�r.

    }
    public void NextLevet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //birsonraki scene
    }
}
