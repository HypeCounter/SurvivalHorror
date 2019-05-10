using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlaJogador : MonoBehaviour {

    public int resistencia = 100;
    [SerializeField] private float distanciaParaAlvo;
    [SerializeField] GameObject gameOver;
    [SerializeField] private float tempoMorte = 10;

    public float DistanciaParaAlvo
    {
        get
        {
            return distanciaParaAlvo;
        }
    }

    void Update () {
        RaycastHit raioAuxiliar;
        if(Physics.Raycast(this.transform.position, 
            this.transform.TransformDirection(Vector3.forward), out raioAuxiliar)){
            distanciaParaAlvo = raioAuxiliar.distance;
        }

        Debug.DrawRay(this.transform.position,
            this.transform.TransformDirection(Vector3.forward) * 100, Color.yellow);

        if(resistencia <= 0)
        {
            /// Jogador morto aqui
            /// 
            Death();

           // Time.timeScale = 0;
        }
	}

    private void Death()
    {


        gameOver.SetActive(true);
        StartCoroutine("WaitDeath");  
     
        
    }

    IEnumerator WaitDeath()
    {
        yield return new WaitForSeconds(tempoMorte);
        SceneManager.LoadScene("001");
    }

    public void SofrerDano(int dano)
    {
        this.resistencia -= dano;
        Debug.Log(resistencia);
    }
}
