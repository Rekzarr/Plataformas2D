using UnityEngine;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private float vidas;
    
    public void RecibirDano(float danoRecibido){
        vidas -= danoRecibido;
        if(vidas <= 0){
            if(this.gameObject.CompareTag("PlayerHitBox")){
                Player player = this.gameObject.GetComponent<Player>();
                player.Recolocar();
                vidas = 100;
            } else {
                Destroy(this.gameObject);
            }
            
        }
    }
}
