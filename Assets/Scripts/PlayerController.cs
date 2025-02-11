using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;  //[SerializeField] ile unity den görebiliyoruz.
    [SerializeField]
    private float pushForce = 1000f;
    [SerializeField]
    private float movement,speed=5f;
    public Vector3 respawnPoint;
    private GameManager gameManager;
    public AudioSource crashSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //unity içinden de olur bu kod ile script içinden de yapýlýr.
        respawnPoint = this.transform.position; //player baþlangýç konumu deðiþkene atanýr.
        gameManager = FindObjectOfType<GameManager>();  //gamemanager script eriþim.
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(0, 0, pushForce * Time.deltaTime); fixed alýnca fizik motoruna daha uygun olur FPS etkisinden kurtulmak.
        movement = Input.GetAxis("Horizontal"); // buton basýmýný canlý almak için update metodunda
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime); //FPS den kurtulmuþ FixedUpdatede fixedDeltaTime kullanýlýr.

        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);

        FallDedector();
    }

    private void OnCollisionEnter(Collision other)
    {
        //bariyer
        if (other.collider.CompareTag("Bariyer")){
            crashSound.Play(); // çarpýþma sesi çalar
            // this.transform.position = respawnPoint;  script baðlantýsý yapýlmadan önce
            gameManager.RespawnPlayer();
            }
    }
    private void FallDedector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        }
    }
}
