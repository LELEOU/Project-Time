using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    public Transform player;
    public float parallaxEffect = 0.5f;// Quanto mair, mais lento o fundo vai se mover, entao deixa num valor baixo

    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (player == null)
        {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        lastPlayerPosition = player.position;

    } 
    void LateUpdate()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += deltaMovement * parallaxEffect;
        lastPlayerPosition = player.position;
    }
   


}
