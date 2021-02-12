using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverBala : MonoBehaviour
{

    private float velocidad = 3f;
    [SerializeField] Text ObstaculosDestruidos;
    public static int contador = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0, 0, transform.position.z * velocidad * Time.deltaTime);
       ObstaculosDestruidos.text = " " + contador;
        Debug.Log(contador);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {

            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Disparar");
            contador++;
        }



    }
}
