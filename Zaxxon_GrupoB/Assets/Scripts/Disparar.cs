﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] GameObject Bala;
    [SerializeField] GameObject Nave;
    Vector3 pos;
    

    public float velocidad = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disparar();
        
    }

    void disparar()
    {
        // al pulsar se ejecuta
        if (Input.GetButtonDown("Fire1"))
        {
            //bala sigue a la nave
            pos = Nave.transform.position;
            // crea la bala
            Instantiate(Bala, pos, Quaternion.identity);
            transform.Translate(0 , 0, transform.position.z * velocidad * Time.deltaTime);
        }
    }
}
