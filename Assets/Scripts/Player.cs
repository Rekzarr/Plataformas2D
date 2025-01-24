using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [SerializeField] private TextMeshProUGUI clearText;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask saltable;
    [SerializeField] private Transform pies;
    [SerializeField] private float distanciaSuelo;
    [SerializeField] private int numeroSaltos;
    private int contadorSaltos;

    [Header("Sistema de combate")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask danable;
    [SerializeField] private float danoAtaque;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Saltar();
        LanzarAtaque();
         
    }

    private void Movimiento(){
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH * velocidadMovimiento, rb.linearVelocity.y);

        if(inputH != 0){
            anim.SetBool("Running", true);
            if(inputH > 0){
                transform.eulerAngles = Vector3.zero;
                
            }else{
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        } else {
            anim.SetBool("Running", false);

        }
    }

    private void Saltar(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if(contadorSaltos < numeroSaltos){
                rb.linearVelocity = new Vector2(0f, fuerzaSalto);
                anim.SetTrigger("Salto");
                contadorSaltos++;
            } 
        }
        if(EstoySuelo()){
                contadorSaltos = 0;
            }
    }
    private bool EstoySuelo(){
        return Physics2D.Raycast(pies.position, Vector3.down, distanciaSuelo, saltable);
    }
    private void LanzarAtaque(){
            if(Input.GetMouseButtonDown(0)){
                anim.SetTrigger("Attack");
        }
    }

    private void Ataque(){ //Evento de animación
        Collider2D[] collidersTocados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, danable);
        foreach(Collider2D item in collidersTocados){
            if(item.gameObject.CompareTag("Finish")){
                clearText.text = "Game clear!";
                Time.timeScale = 0;
            }
            SistemaVidas vidasEnemigos = item.gameObject.GetComponent<SistemaVidas>();
            vidasEnemigos.RecibirDano(danoAtaque);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.DrawSphere(puntoAtaque.position, radioAtaque);
    }
}