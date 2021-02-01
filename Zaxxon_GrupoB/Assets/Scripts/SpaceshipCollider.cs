using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;


   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            print("Hit");
            myMesh.enabled = false;
            Time.timeScale = 0f;

            StartCoroutine("Cambiar");
            Cambiar();
           

        }

       
    }

    IEnumerator Cambiar()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

}
