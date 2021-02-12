using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{


    private ObstacleCreator obstacleCreator;

    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    public bool inMarginMoveX = true;
    public bool inMarginMoveY = true;


    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text Posicion;
    [SerializeField] MeshRenderer myMesh;
   
    

    GameObject initObject;
    InitGame initGame;


    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");

        initObject = GameObject.Find("InitObject");
        initGame = initObject.GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();
        

    }
    /*
   
    private void OnCollisionEnter(Collision collision)
    {
        print("chocado");
        if (collision.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            Time.timeScale = 0f;
        }
    }
    */

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n ++)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n;

            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(1f);

            if (n > 20 && n < 50) 
            {
                speed = 3.5f;
            }
            else if (n > 50)
            {
                speed = 4f;
            }
        }
        
    }


 


    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
      
        
        float myPosY = transform.position.y;
        float myPosX = transform.position.x;
       // print(myPosX);
        Posicion.text = "POSICIÓN: X: " + (Mathf.Round(myPosX)) + " Y: " + (Mathf.Round(myPosY));
        //Debug.Log(Mathf.Round(myPosX));


        //Rotar pulsando
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0.0f, 0.0f, 10.0f, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0.0f, 0.0f, -10.0f, Space.World);
        }
        */

        if (myPosX < -4.5 && desplX < 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX < -4.5 && desplX > 0)
        {
            inMarginMoveX = true;
        }
        else if (myPosX > 4.5 && desplX > 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX > 4.5 && desplX < 0)
        {
            inMarginMoveX = true;
        }
        //Retricción en Y
        if (myPosY < -0 && desplY < 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY < -0 && desplY > 0)
        {
            inMarginMoveY = true;
        }
        else if (myPosY > 4 && desplY > 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY > 4 && desplY < 0)
        {
            inMarginMoveY = true;
        }

        //Si estoy en los márgenes, me muevo
        if (inMarginMoveX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX, Space.World);

        }
        if (inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY, Space.World);
        }


        transform.rotation = Quaternion.Euler(desplY * -20, 0, desplX * -20);

        

    }

    



}
        