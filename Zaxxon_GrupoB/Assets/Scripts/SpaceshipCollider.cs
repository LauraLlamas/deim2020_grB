using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;
    public GameObject SonidoExplosion;
    public GameObject ExplosionParticulas;

    //Para acceder a las variables globales
    GameObject initObject;
    InitGame initGame;
    Vector3 pos;




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
            pos = transform.position;
            Instantiate(SonidoExplosion);
            Instantiate(ExplosionParticulas, pos, Quaternion.identity);
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
       
    }



}
