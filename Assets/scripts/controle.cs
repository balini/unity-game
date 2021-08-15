using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===Classe criada para definir o momento em que o jogo para ou começa
public class controle : MonoBehaviour {
    [SerializeField]
    private GameObject gameOver;
    private gato gatoObj;
    private pontuacao pontuacaoObj;
    [SerializeField]
    private GameObject gameStart;

    //====Metodo que previne erro de falta de referencia
    private void Start() {
        this.gatoObj = GameObject.FindObjectOfType<gato>();
        this.pontuacaoObj = GameObject.FindObjectOfType<pontuacao>();
    }

    public void TerminaJogo() {
       //Para o passar do tempo no jogo
       Time.timeScale = 0;
       //Exibe a imagem de fim de jogo 
       this.gameOver.SetActive(true);
    }

    public void ReiniciaJogo() {
        //Esconde a imagem de fim de jogo
        this.gameOver.SetActive(false);
        //Retorna o tempo normal do jogo
        Time.timeScale = 1;
        this.gatoObj.Reiniciar();
        this.DestroiObstaculos();
        this.pontuacaoObj.ZeraPontuacao();
    }

    public void IniciaJogo()
    {
        //Esconde a imagem de inicio de jogo
        this.gameStart.SetActive(false);
        //Retorna o tempo normal do jogo
        Time.timeScale = 1;
        this.gatoObj.Reiniciar();
        this.DestroiObstaculos();
        this.pontuacaoObj.ZeraPontuacao();
    }

    public void DestroiObstaculos() {
        obstaculo[] obstaculos = GameObject.FindObjectsOfType<obstaculo>();
        foreach (obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
