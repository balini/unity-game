using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculo : MonoBehaviour {
    [SerializeField]
    private float vel = 0.03f;
    //Define a velocidade em que o obstaculo se movimenta

    void Update()
    {
        this.transform.Translate(Vector3.left * this.vel);
        //Esse método nativo do Unity (Translate) passa a direção de movimentação do objeto (no caso, da direita para a esquerda)
        //Vector3 possui coordenadas nos eixos x, y, z
    }
} 
