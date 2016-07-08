using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public float tiempoEspera;
	public bool comprobacion;
	public bool playClip;
	public int instruccionClipNum;

	private float timer;
	private bool flag = false;
	private Fx FxController;
	private bool replayclip;
	//private bool onlyonce = false;
    private Button opciones;

    void Start()
    {
        opciones = GameObject.Find("menu_btn").GetComponent<Button>();
        FxController = GameObject.Find ("Sonidos").GetComponent<Fx> ();
		//onlyonce = false;
        opciones.interactable = false;
    }

	void Update () 
	{
		if (flag) 
		{
			this.gameObject.SetActive(true);
			timer += Time.deltaTime;
			if(timer > tiempoEspera)
			{
				this.gameObject.SetActive(false);
				comprobacion = true;
                opciones.interactable = true;
                GameObject.FindGameObjectWithTag("Dialogo").GetComponentInChildren<Animator>().SetTrigger("MENSAJE_INTRO");
			}
		}
		
		if (comprobacion && replayclip) 
		{
			FxController.PlaySingle(instruccionClipNum);
			replayclip = false;
		}
	}

	public void comienza()
	{
		timer = 0;
		flag = true;
		comprobacion = false;

		//Debug.Log ("el maldito playclip" + playClip);
		if (playClip) {
			replayclip = true;
		} else {
			replayclip = false;
		}
	}

}
