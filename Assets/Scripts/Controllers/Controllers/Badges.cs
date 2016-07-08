using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Badges : MonoBehaviour
{
    public GameObject panelGanar;
    public GameObject panelPerder;
    public Loading loadingCanvas;
    public float[] tiempos;
	public Text[] cantidadesGanar;
	public Text[] cantidadesPerder;

	private float segundos;

    public void SetGanado(float segundos, int logrados, int perdidos, int puntaje)
    {
		this.segundos = segundos;
		
		cantidadesGanar [0].text = logrados.ToString();
		cantidadesGanar [1].text = perdidos.ToString();
		cantidadesGanar [2].text = puntaje.ToString();

        panelGanar.GetComponentInParent<Canvas>().enabled = true;
        panelGanar.GetComponent<Animator>().SetTrigger("WIN");
    }
    
	public void SetPerdido(float segundos, int logrados, int perdidos, int puntaje)
    {
		this.segundos = segundos;
		
		cantidadesPerder [0].text = logrados.ToString();
		cantidadesPerder [1].text = perdidos.ToString();
		cantidadesPerder [2].text = puntaje.ToString();

        panelPerder.GetComponentInParent<Canvas>().enabled = true;
        panelPerder.GetComponent<Animator>().SetTrigger("LOSE");
    }

    private string cambioUnidades(int numeroNumero)
    {
        if (numeroNumero < 10)
        {
            return "0" + numeroNumero;
        }
        else
        {
            return numeroNumero.ToString();
        }
    }

    public void SetTiempos(float tiempo1, float tiempo2)
    {
        tiempos = new float[3];

        tiempos[0] = tiempo1;
        tiempos[1] = tiempo2;
        tiempos[2] = 9999;
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        loadingCanvas.DoLoadLevel(scene.name);
    }

    public void LoadWorldSelectScene()
    {
        loadingCanvas.DoLoadLevel("Planetario");
    }
}
