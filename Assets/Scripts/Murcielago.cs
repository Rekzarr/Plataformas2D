using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Murcielago : MonoBehaviour
{
    [SerializeField] private Transform[] puntosPatrulla;
    [SerializeField] private float velocidad;  
    [SerializeField] private float dano;

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

    private void OnTriggerEnter2D(Collider2D elOtro){
        if(elOtro.gameObject.CompareTag("DeteccionPlayer")){
            Debug.Log("Player detectado");
        }else if(elOtro.gameObject.CompareTag("PlayerHitBox")){
            SistemaVidas vidasPlayer = elOtro.gameObject.GetComponent<SistemaVidas>();
            vidasPlayer.RecibirDano(dano);
        }
    }
}
