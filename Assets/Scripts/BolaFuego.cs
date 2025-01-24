using UnityEngine;

public class BolaFuego : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulsoBola;
    [SerializeField] private float dano;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulsoBola, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D elOtro){
        if(elOtro.gameObject.CompareTag("PlayerHitBox")){
            SistemaVidas vidasPlayer = elOtro.gameObject.GetComponent<SistemaVidas>();
            vidasPlayer.RecibirDano(dano);
            Destroy(this.gameObject);
        }
    }
}
