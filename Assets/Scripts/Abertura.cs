using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Abertura : MonoBehaviour
{

    [SerializeField] private GameObject jogador;
    [SerializeField] private GameObject telaFadeIn;
    [SerializeField] private GameObject caixaDeTexto;

    void Start()
    {
        jogador.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(ExibeTexto());
    }

    private IEnumerator ExibeTexto()
    {
        yield return new WaitForSeconds(1.5f);
        telaFadeIn.SetActive(false);
        caixaDeTexto.GetComponent<Text>().text = "Preciso dar o fora daqui...";

        yield return new WaitForSeconds(2f);
        caixaDeTexto.GetComponent<Text>().text = "";
        jogador.GetComponent<FirstPersonController>().enabled = true;
    }

}
	

