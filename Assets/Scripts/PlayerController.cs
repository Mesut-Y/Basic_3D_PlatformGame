using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;  //[SerializeField] ile unity den g�rebiliyoruz.
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
        rb = GetComponent<Rigidbody>(); //unity i�inden de olur bu kod ile script i�inden de yap�l�r.
        respawnPoint = this.transform.position; //player ba�lang�� konumu de�i�kene atan�r.
        gameManager = FindObjectOfType<GameManager>();  //gamemanager script eri�im.
    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(0, 0, pushForce * Time.deltaTime); fixed al�nca fizik motoruna daha uygun olur FPS etkisinden kurtulmak.
        movement = Input.GetAxis("Horizontal"); // buton bas�m�n� canl� almak i�in update metodunda
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime); //FPS den kurtulmu� FixedUpdatede fixedDeltaTime kullan�l�r.

        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);

        FallDedector();
    }

    private void OnCollisionEnter(Collision other)
    {
        //bariyer
        if (other.collider.CompareTag("Bariyer")){
            crashSound.Play(); // �arp��ma sesi �alar
            // this.transform.position = respawnPoint;  script ba�lant�s� yap�lmadan �nce
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
