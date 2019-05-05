using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoDaTocha : MonoBehaviour {
    private int estiloDaLuz;
    [SerializeField] private GameObject luzDaTocha;

	void Update () {
		if(estiloDaLuz == 0)
        {
            StartCoroutine(AnimacaoDaLuz());
        }
	}

    private IEnumerator AnimacaoDaLuz()
    {
        estiloDaLuz = UnityEngine.Random.Range(1, 4);

        if(estiloDaLuz == 1)
        {
            luzDaTocha.GetComponent<Animation>().Play("tocha-anim01");
        }

        if (estiloDaLuz == 2)
        {
            luzDaTocha.GetComponent<Animation>().Play("tocha-anim02");
        }

        if (estiloDaLuz == 3)
        {
            luzDaTocha.GetComponent<Animation>().Play("tocha-anim03");
        }

        yield return new WaitForSeconds(0.99f);
        estiloDaLuz = 0;
    }
}
