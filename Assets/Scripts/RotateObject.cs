using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,180f * Time.deltaTime); //bozuk para z ekseninde d�n�� deltaTime her pc ayn� h�zda
    }
}
