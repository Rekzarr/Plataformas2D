using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSalto;
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
        Atacar();
                
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
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetTrigger("Salto");
            }    
    }
    private void Atacar(){
            if(Input.GetMouseButtonDown(0)){
                anim.SetTrigger("Attack");
        }
    }
}