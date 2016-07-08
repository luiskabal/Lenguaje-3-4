using UnityEngine;
using UnityEngine.UI;

public class BigBoss : MonoBehaviour {
    
    public Stars Estrellas;
    public Badges Medallas;
    public Clock Reloj;
    public Fx Sonidos;
    public Music Musica;
    public Lives Vidas;
    public Countdown CuentaAtras;
    public Text mainMessage;

    public AudioSource[] otrosAudios;
    public int stars = 3;
    public int hitsToStar = 1;
    public bool showCounter = false;
    public bool showMultiCheck = false;
    public bool muestraTiempo;
    public int cantidadVidas= 3;
    public int personajeVidas;
    public bool hasTimeLimit; // esta act. tiene un tiempo límite?
    public int tiempoJuego; // tiempo limite de la act.

    private bool diagIsOpen; // esta abierto el texto azul?
    
    void Start()
    {
        //Agregar sonidos al fx
        ConfigurarSonidos();

        //Configura estrellas y logros
        Estrellas.Configure(stars, hitsToStar, showCounter, showMultiCheck);

        //Configura Reloj
        Reloj.SetTime(tiempoJuego);

        //Recupera vidas
        Vidas.SetLives(cantidadVidas, personajeVidas);
        Vidas.RestoreAllLife(true);
    }

    private void ConfigurarSonidos()
    {
        if(otrosAudios.Length >= 1)
        {
            AudioSource[] Aux = new AudioSource[Sonidos.soundSource.Length];

            for (int i = 0; i < Sonidos.soundSource.Length; i++)
            {
                Aux[i] = Sonidos.soundSource[i];
            }

            Sonidos.soundSource = new AudioSource[Aux.Length];

            for (int i = 0; i < Sonidos.soundSource.Length; i++)
            {
                if(i < Aux.Length)
                {
                    Sonidos.soundSource[i] = Aux[i];
                }
                else
                {
                    Sonidos.soundSource[i] = otrosAudios[i - Aux.Length];
                }
            }
        }
    }
    
	public void Comenzar()
    {
        //Tirar Countdown
        CuentaAtras.gameObject.SetActive(true);
        CuentaAtras.comienza();

        //Después de Countdown tirar tiempo de juego
        Invoke("StartClock", CuentaAtras.tiempoEspera);
    }

    private void StartClock()
    {
        //contador de tiempo para puntos...
        Reloj.StartCounter();

        //si hay limite de tiempo, correr
        if (hasTimeLimit)
            Reloj.Run();
    }

    public bool CheckOverClock()
    {
        if (hasTimeLimit)
            return Reloj.TimeOver;
        else
            return false;
    }

    public void ResetClock()
    {
        Reloj.Reset();
    }

    public void ShowCross()
    {
        Estrellas.Fail();
    }

    public void ShowCross(Vector3 myPos)
    {
        Estrellas.Fail(myPos);
    }

    public void TakeLife()
    {
        Vidas.TakeLife();   
    }

    public bool Bad()
    {
        if (!Vidas.TakeLife())
        {
            ShowCross();
            Sonidos.PlaySingle(1);
			return false;
        }
        else
        {
            Musica.StopMusic();
            Medallas.SetPerdido(Reloj.GetCounter(), Estrellas.GetHits(), cantidadVidas - Vidas.GetRemaining(), 100);
            Sonidos.PlaySingle(3);
			return true;
        }
    }

    public bool Bad(Vector3 myPos)
    {
        if (!Vidas.TakeLife())
        {
            ShowCross(myPos);
            Sonidos.PlaySingle(1);
			return false;
        }
        else
        {
            Musica.StopMusic();
            Medallas.SetPerdido(Reloj.GetCounter(), Estrellas.GetHits(), cantidadVidas - Vidas.GetRemaining(), 100);
            Sonidos.PlaySingle(3);
			return true;
        }
    }

    public bool Good()
    {
        if (!Estrellas.Hit())
        {
            Sonidos.PlaySingle(0);
            return false;
        }
        else
        {
            Musica.StopMusic();
            Medallas.SetGanado(Reloj.GetCounter(), Estrellas.GetHits(), cantidadVidas - Vidas.GetRemaining(), 100);
            Sonidos.PlaySingle(2);
            return true;
        }
    }

    public bool Good(Vector3 myPos)
    {
        if (!Estrellas.Hit(myPos))
        {
            Sonidos.PlaySingle(0);
            return false;
        }
        else
        {
            Musica.StopMusic();
            Medallas.SetGanado(Reloj.GetCounter(), Estrellas.GetHits(), cantidadVidas - Vidas.GetRemaining(), 100);
            Sonidos.PlaySingle(2);
            return true;
        }
    }

    public void GainLife()
    {
        Vidas.GainLife(1);
    }

    public void MakeSomeNoise(int sonido)
    {
        Sonidos.PlaySingle(Sonidos.soundSource.Length + sonido);
    }

    public void GodMode(bool star)
    {
        if (star)
        {
            for (int i = 0; i < hitsToStar; i++)
            {
                Good();
            }
        }
        else
        {
            Good();
        }
    }

    public int GetHPS()
    {
        return hitsToStar;
    }

    public bool GetComprobacionCountDown()
    {
        return CuentaAtras.comprobacion;
    }

    public void SetComprobacionCountDown(bool opcion)
    {
        CuentaAtras.comprobacion = opcion;
    }

    public bool StarWon()
    { 
        return Estrellas.GetWon();
    }

    public void SuddenDeath()
    {
        Medallas.SetPerdido(Reloj.GetCounter(), Estrellas.GetHits(), cantidadVidas - Vidas.GetRemaining(), 100);
        Sonidos.PlaySingle(3);
    }

    public void SetMainMessage(string msg)
    {
        mainMessage.text = msg;
    }

    public int GetStarNum()
    {
        return Estrellas.GetWonStars();
    }

    public void PlayDefaultMusic()
    {
        Musica.PlaySingle(0);
    }

    public bool IsMusicPlaying()
    {
        return Musica.IsPlaying();
    }

    public void SetDialogueIsOpen(bool opcion)
    {
        diagIsOpen = opcion;
    }

    public bool GetDiagIsOpen()
    {
        return diagIsOpen;
    }
}
