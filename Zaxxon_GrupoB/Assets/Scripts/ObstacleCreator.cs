﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject Spaceship;
    private SpaceshipMove spaceshipMove;

    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;

    [SerializeField] float distanciaInicial = 8;
    
    // Start is called before the first frame update
    void Start()
    {

        spaceshipMove = Spaceship.GetComponent<SpaceshipMove>();

        for (int n = 0; n <= 24; n++)
        {
            CrearColumna(n * distanciaInicial);
        }

        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");

    }

    //Función que crea una columna en una posición Random
    void CrearColumna(float posZ = 0f)
    {
        randomNumber = Random.Range(-7f, 7f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna();
            float interval = 4 / spaceshipMove.speed;
            //Debug.Log(interval);
            yield return new WaitForSeconds(interval);
            
        }

    }

   
}
