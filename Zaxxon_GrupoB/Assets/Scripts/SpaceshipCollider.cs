using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;

    //Para acceder a las variables globales
    GameObject initObject;
    InitGame initGame;

  


    private void Start()
    {
        //Obtemos el script de inicio
        initObject = GameObject.Find("InitObject");
        initGame = initObject.GetComponent<InitGame>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            print("Hit");
            myMesh.enabled = false;

            initGame.speed = 0;
            //SceneManager.LoadScene("GameOver");
            Invoke("CambiarEscena", 3f);
            // StartCoroutine("Cambiar");
            // Cambiar();


        }

       

    }
    /*
    IEnumerator Cambiar()
    {
        for(; ; )
        {
            print("a punto de cambiar");
            yield return new WaitForSeconds(3f);
            CambiarEscena();

        }
        
    }
    */

    void CambiarEscena()
    {
        SceneManager.LoadScene("GameOver");
        print("HOOOOLA");
    }



}
