using UnityEngine;
using System.Collections;

public class Renombrador : MonoBehaviour {

    public string nombreArchivos = "Hijo_";

	public void RenombrarHijos()
    {
        int contador = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = nombreArchivos + contador;
            contador++;
        }
    }
}
