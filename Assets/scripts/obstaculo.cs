using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculo : MonoBehaviour {
    //Define a velocidade em que o obstaculo se movimenta
    [SerializeField]
    private float vel = 0.03f;
    //=====Instancia vetor com 3 dimensoes para armazenar posicao do gato
    private Vector3 posicaoGato;
    //====Instancia booleano para triggar momento da pontuacao
    private bool ponto;
    //===Instancia objeto pontuacao
    private pontuacao pontuacao;

    //=======Metodo criado para possibilitar armazenamento dos pontos; a ideia é que a cada obstaculo passado, um ponto é somado
    //Esses pontos serao armazenados e exibidos em um objeto
    //Nao podem ser armazenados no proprio obstaculo pois eles sao destruidos a cada loop da cena do jogo
    private void Start() {
        //====Toda classe derivada do monobehavior possui a propriedade transform, que nos permite acessar a posiçao do objeto
        //Aqui estamos armazenando a posiçao do gato na variavel posicaoGato
        this.posicaoGato = GameObject.FindObjectOfType<gato>().transform.position;

        //=====Ao renderizar um novo obstaculo, devemos declarar a existencia do objeto pontuacao
        this.pontuacao = GameObject.FindObjectOfType<pontuacao>();
    }

    private void Update() {
        this.transform.Translate(Vector3.left * this.vel);

        //=====Como o Update é o metodo que roda o tempo inteiro durante o jogo, implementamos a logica da pontuaçao nele
        //No decorrer do jogo os obstaculos se movem ao longo do eixo x da direita para a esquerda, ou seja, diminuindo de valor
        //Enquanto isso o gato permanece fixo no eixo x
        //Entao para saber se o gato ultrapassou os obstaculos, ou seja, se os obstaculos se moveram diante do gato, comparamos os valores do eixo x do obstaculo e do gato
        //Se o valor do x do obstaculo for menor do que o do gato, significa que o gato ultrapassou o obstaculo e um ponto será somado
        //this.transform.position.x = posicao do obstaculo (valor do x do obstaculo); this.posicaoGato.x = posicao do gato (valor do x do gato)
        if (!this.ponto && this.transform.position.x < this.posicaoGato.x)
        {
            this.ponto = true;
            this.pontuacao.AddPontos();
        }
    }

    //===Metodos para destruir os objetos instaciados, usamos quando reiniciamos o jogo para que a cena volte do inicio
    private void OnTriggerEnter2D(Collider2D outro) {
        this.Destruir();
    }

    public void Destruir() {
        Destroy(this.gameObject);
    }
} 
