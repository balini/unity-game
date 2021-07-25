using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gato : MonoBehaviour {
    //Essa propriedade é responsável por fazer com que o gato sofra os efeitos da gravidade no jogo (ou seja, responsável por fazer o gato ficar a deriva se o jogador deixar de clicar na tela)
    Rigidbody2D comportamento;
    [SerializeField]
    private float f = 6;

    //Método invocado assim que o jogo é iniciado, serve para dizer ao Unity que estou passando uma propriedade do tipo Rigidbody como parâmetro e associando-a ao "comportamento"
    private void Awake() {
        this.comportamento = this.GetComponent<Rigidbody2D>();
    }

    //Método que é criado por padrão pelo Unity ao gerar um arquivo C#. O método é chamado automaticamente pelo Unity (responsável pelo game loop).
    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            //Método que captura o clique do usuário. Recebe o botão direito como parâmetro para capturar esse tipo de clique específico
            this.Mover();
            //Fire1 = atalho do botão direito no Unity
        }
    }

    //Método responsável por mover o gato
    private void Mover() {
        this.comportamento.velocity = Vector2.zero;
        this.comportamento.AddForce(Vector2.up * f, ForceMode2D.Impulse);
        //O Método AddFforce recebe como parâmetro um vetor de força, com a intensidade e o tipo
        //Como o intuito é mover o gato para cima de forma a impulsiona-lo, passei como parâmetro o Vector2 e o tipo de força ForceMode2D.Impulse
        //Para aumentar a intensidade da força e dar mais fluidez ao movimento do gato quando o usuário clicar, multipliquei a intensidade da força por 10
        //Vector2 = possui coordenadas no eixo x e y
    }


}
