using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      // Move a raquete para esquerda
    public KeyCode moveRight = KeyCode.D;    // Move a raquete para direita
    public float speed = 10.0f;             // Define a velocidade da raquete
    public float boundX = 2.25f;            // Define os limites em X
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete

    }

    void Update()
    {

        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveRight))
        {   // Velocidade da raquete para ir para direita
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft))
        {      // Velocidade da Raquete para ir para esquerda
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posi��o da raquete
        if (pos.x > boundX)
        {
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite lateral direito
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite lateral esquerdo
        }
        transform.position = pos;               // Atualiza a posi��o da raquete

    }

}
