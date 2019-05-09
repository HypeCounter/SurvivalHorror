using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    [SerializeField] private float velocidade = .5f;
    [SerializeField] private GameObject jogador;
    [SerializeField] private int resistencia = 50;
    private Rigidbody rigidbodyZumbi;
    private Animator animatorZumbi;
    private Vector3 direcao;

    private bool estaVivo;

    [Range(5f, 10f)]
    [SerializeField] private float campoDeVisao = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
        animatorZumbi.SetBool("Andando", true);
        estaVivo = true;
        //Debug.Log("Apareceu");
    }

    private void Update()
    {
        if(this.resistencia <= 0)
        {
            estaVivo = false;
            animatorZumbi.SetBool("Atacando", false);
            animatorZumbi.SetBool("Andando", false);
            animatorZumbi.SetBool("Morrendo", true);

            this.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(estaVivo == true)
        {
            MovimentacaoDoZumbi();
        }        
    }


    private void MovimentacaoDoZumbi()
    {
        direcao = jogador.transform.position - this.transform.position;
        float distancia = Vector3.Distance( this.transform.position,
                                            jogador.transform.position);

        float alcance = 1f;
        float raioColisaoZumbi = this.GetComponent<CapsuleCollider>().radius;
        float raioColisaoJogador = jogador.GetComponent<CharacterController>().radius;

        float raioAtaqueZumbi = raioColisaoZumbi + raioColisaoJogador + alcance;

        if(distancia > raioAtaqueZumbi && distancia < campoDeVisao)
        {
            //Movimentacao
           rigidbodyZumbi.MovePosition(
               rigidbodyZumbi.position + (direcao.normalized * velocidade * Time.deltaTime));
            animatorZumbi.SetBool("Atacando", false);
            animatorZumbi.SetBool("Andando", true);
            rigidbodyZumbi.isKinematic = false;
        }
        else if(distancia <= raioAtaqueZumbi)
        {
            //Ataque do zumbi
            animatorZumbi.SetBool("Atacando", true);
            rigidbodyZumbi.isKinematic = true;
        }
        else
        {
            //Zumbi parado
            animatorZumbi.SetBool("Atacando", false);
            animatorZumbi.SetBool("Andando", false);
        }

        RotacionarZumbi();
    }

    private void RotacionarZumbi()
    {
        Vector3 olharParaJogador = new Vector3( jogador.transform.position.x,
                                                this.transform.position.y,
                                                jogador.transform.position.z);

        this.transform.LookAt(olharParaJogador);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Evita que o zumbi seja jogado para tras ao colidir com o player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("colidiu");
            rigidbodyZumbi.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("saiu");
        rigidbodyZumbi.isKinematic = false;
    }

    private void SofrerDano(int dano)
    {
        this.resistencia -= dano;
        Debug.Log(resistencia);
    }

    private void Atacar()
    {
        int dano = 20;
        
        jogador.GetComponent<ControlaJogador>().SofrerDano(dano);
    }
}
