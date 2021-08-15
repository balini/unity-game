using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//=====Importa interface grafica do Unity para poder utilizar o objeto do tipo Text para exibir a pontuacao ao jogador
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {
    [SerializeField]
    private Text pontuacaoTexto;
    private int pontos;
    private AudioSource audioPontuacao;

    //Metodo que procura pelo audio quando uma pontuacao é obtida
    private void Awake() {
        this.audioPontuacao = this.GetComponent<AudioSource>();
    }

    //===Metodo criado para somar a pontuacao a cada obstaculo ultrapassado no jogo
    public void AddPontos() {
        this.pontos++;
        //===Altera o conteudo dentro do texto, ou seja, a quantidade de pontos exibida
        this.pontuacaoTexto.text = this.pontos.ToString();
        this.audioPontuacao.Play();
    }

    //====Metodo para zerar a pontuacao quando o jogo for reiniciado
    public void ZeraPontuacao() {
        this.pontos = 0;
        this.pontuacaoTexto.text = this.pontos.ToString();
    }
}
