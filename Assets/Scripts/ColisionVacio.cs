using UnityEngine;

public class ColisionVacio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D elOtro) {
        if(elOtro.gameObject.CompareTag("PlayerHitBox")){
            Player player = elOtro.gameObject.GetComponent<Player>();
            player.Recolocar();
        }
    }
}
