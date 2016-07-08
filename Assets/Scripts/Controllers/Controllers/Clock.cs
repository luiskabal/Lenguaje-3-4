using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	public float tiempo;
    public bool TimeOver;
    public bool mostrarTiempo = false;
    public UnityEngine.UI.Text ClockNumbers;
    public UnityEngine.UI.Text Reloj;

    private float timer = 0;
    private float ContadorTiempo = 0;
	private bool tictac = false;
    private bool clockRun = false;
    private bool countNow = false;
    private float tiempoTranscurrido;
    private TimeSpan tiempoString;
	
	void Update () 
	{
        if(countNow)
        {
            ContadorTiempo += Time.deltaTime;
        }

        if(clockRun)
        {
            tiempoTranscurrido += Time.deltaTime;
            tiempoString = TimeSpan.FromSeconds(tiempoTranscurrido);
            if (mostrarTiempo)
            {
                Reloj.text = cambioUnidades(tiempoString.Minutes) + ":" +
                             cambioUnidades(tiempoString.Seconds);
            }
        }

		if (tictac) 
		{
			//Debug.Log ("TIC TAC UPDATE , timer="+timer+" tiempo="+tiempo);
			timer += Time.deltaTime;

			if(timer >= tiempo)
			{
				ClockNumbers.text = "--";
				TimeOver = true;
				tictac = false;
			}
			else
			{
				int newIntTime = Convert.ToInt32(tiempo - Mathf.Abs(timer));
				ClockNumbers.text = newIntTime.ToString();
			}
		}
	}

    public TimeSpan GetTiempo()
    {
        return TimeSpan.FromSeconds(tiempoTranscurrido);
    }

    public void StartClock()
    {
        clockRun = true;
    }

    public void StopClock()
    {
        clockRun = false;
    }

	public void Run()
	{
		tictac = true;
	}

	public void Reset()
	{
		tictac = false;
		TimeOver = false;
		ClockNumbers.text = tiempo.ToString();
		timer = 0;
	}

    public void SetTime(float newTime)
    {
        tiempo = newTime;
    }

    public void StopTime()
    {
        tictac = false;
    }

	public float GetCurrentTime()
	{
		return tiempo;
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

    public void StartCounter()
    {
        ContadorTiempo = 0;
        countNow = true;
    }

    public float GetCounter()
    {
        return ContadorTiempo;
    }
}
