using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopObstaculo: MonoBehaviour {
    //Declara variável para armazenar o tempo de duração de um loop
    [SerializeField]
    private float tempo;

    //Declara variável para armazenar o Prefab (prefabs são configurações pré-definidas de como objetos devem ser instanciados)
    [SerializeField]
    private GameObject prefab;
    private float loop;

    private void Awake() {
        this.loop = this.tempo;
    }

    //Método que implementa um temporizador para contabilizar o tempo de duração até o fim do loop
    //Quando o temporizadors zerar, novos obstáculos serão criados (inicia-se novo loop)
    void Update() {
        this.loop -= Time.deltaTime;
        if (this.loop < 0) {

            //Método que instancia os novos obstáculos, utilizando configurações pré-definidas (prefab) e definindo a posição e rotação dos obstáculos
            GameObject.Instantiate(this.prefab, this.transform.position, Quaternion.identity);
            this.loop = this.tempo;
        }
    }

}
