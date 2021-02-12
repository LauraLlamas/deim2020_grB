using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }

    public void Volver()
    {
        SceneManager.LoadScene("Start");
    }

    public void Puntuacion()
    {
        SceneManager.LoadScene("Ranking");
    }
}
