using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mago : MonoBehaviour
{
    [SerializeField] private GameObject bolaFuego;
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaque;
    [SerializeField] private float danoAtaque;
    private Animator anim;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RutinaAtaque());
    }

    IEnumerator RutinaAtaque(){
        while(true){
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoAtaque);
        }
    }
    private void LanzarBola(){
        Instantiate(bolaFuego, puntoSpawn.position, transform.rotation);
    }
}
