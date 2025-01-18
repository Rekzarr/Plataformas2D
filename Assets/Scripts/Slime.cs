using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slime : MonoBehaviour
{
    [SerializeField] private Transform[] puntosPatrulla;
    [SerializeField] private float velocidad;  
    private Vector3 destinoActual;
    private int indiceActual = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinoActual = puntosPatrulla[indiceActual].position;
        StartCoroutine(Patrulla());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Patrulla(){
        while(true){
            while(transform.position != destinoActual){
                transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);
                yield return null; 
            }
            DefinirNuevoDestino();
        }
        
    }

    private void DefinirNuevoDestino(){
        indiceActual++;
        if(indiceActual >= puntosPatrulla.Length){
            indiceActual = 0;
        }
        destinoActual = puntosPatrulla[indiceActual].position;
        EnfocarDestino();
    }

    private void EnfocarDestino(){
        if(destinoActual.x > transform.position.x){
            transform.localScale = Vector3.one;
        } else{
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
