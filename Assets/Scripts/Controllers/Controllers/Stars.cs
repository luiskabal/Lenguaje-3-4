using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stars : MonoBehaviour {

    public Animator[] stars_01;
    public Animator[] stars_02;
    public Animator[] stars_03;
    public Animator[] stars_04;
    public Animator[] stars_05;

    public GameObject[] stars_panel;
    
    public Animator good;
    public Animator checkCross;

    public GameObject counter;
    public Text current_text;
    public Text total_text;

    private int stars;
    private int hit_per_star;
    private bool show_counter;
    private bool multi_check;
    private bool star_won;

    private int counting_stars;
    private int current_hit;
    private int total_hits;

    public bool AddStar()
    {
        bool respuesta;

        //ganamos una estrella, resetear counter si existe
        if (show_counter)
        {
            current_hit = 0;
            current_text.text = "0";
            star_won = true;
        }
        else
        {
            star_won = true;
        }
        
        switch (stars)
        {
            case 1:
				stars_01[counting_stars].SetTrigger("ESTRELLA");
                respuesta = true;
                break;
            case 2:
				stars_02[counting_stars].SetTrigger("ESTRELLA");
                counting_stars++;

                if (counting_stars < 2)
                    respuesta = false;
                else
                    respuesta = true;
                break;
            case 3:
				stars_03[counting_stars].SetTrigger("ESTRELLA");
                counting_stars++;

                if (counting_stars < 3)
                    respuesta = false;
                else
                    respuesta = true;
                break;
            case 4:
				stars_04[counting_stars].SetTrigger("ESTRELLA");
                counting_stars++;

                if (counting_stars < 4)
                    respuesta = false;
                else
                    respuesta = true;
                break;
            case 5:
				stars_05[counting_stars].SetTrigger("ESTRELLA");
                counting_stars++;

                if (counting_stars < 5)
                    respuesta = false;
                else
                    respuesta = true;
                break;
            default:
                respuesta = false;
                break;
        }

        return respuesta;
    }

    public bool Hit()
    {
        current_hit++;
        total_hits++;
        //Debug.Log(hit_per_star);
        //Debug.Log(current_hit);
        star_won = false;

        if (current_hit < hit_per_star)
        {
            checkCross.SetTrigger("BIEN");
            //current_text.text = total_hits.ToString();
            current_text.text = current_hit.ToString();
            return false;
        }
        else
        {
            current_text.text = total_text.text;
            good.SetTrigger("EJERCICIO_TERMINADO");
            current_hit = 0;
            return AddStar();
        }
    }

    public bool Hit( Vector3 myPos )
    {
        current_hit++;
        total_hits++;
        star_won = false;

        if (current_hit < hit_per_star)
        {
            checkCross.transform.position = myPos;
            checkCross.SetTrigger("BIEN");
            //current_text.text = total_hits.ToString();
            current_text.text = current_hit.ToString();
            return false;
        }
        else
        {
            current_text.text = total_text.text;
            good.SetTrigger("EJERCICIO_TERMINADO");
            current_hit = 0;
            return AddStar();
        }
    }

    public void Configure(int stars, int qty, bool showCounter, bool multicheck)
    {
        setStars(stars);
        setQty(qty);
        setCounter(showCounter);
        SetMultiCheck(multicheck);

        stars_panel[stars - 1].SetActive(true);
        current_hit = 0;
        total_hits = 0;
    }

    public void Fail()
    {
        checkCross.SetTrigger("MAL");
    }

    public void Fail(Vector3 myPos)
    {
        checkCross.transform.position = myPos;
        checkCross.SetTrigger("MAL");
    }

    private void setStars(int stars)
    {
        this.stars = stars;
    }

    public void setQty(int qty)
    {
        hit_per_star = qty;

        current_text.text = "0";
        total_text.text = hit_per_star.ToString();
    }

    public void setCounter(bool show)
    {
        show_counter = show;

        counter.SetActive(show_counter);
        
    }

    private void SetMultiCheck(bool show)
    {
        multi_check = show;
    }

    public int GetHits()
    {
        return total_hits;
    }

    public void TriggerBien()
    {
        good.SetTrigger("EjercicioTerminado");
    }

    public void TriggerTicket(string opcion)
    {
        //forzar al centro
        checkCross.transform.position = new Vector3(0,0,0);
        checkCross.SetTrigger(opcion);
    }

    public void TriggerTicket(string opcion, Vector3 posAt)
    {
        checkCross.transform.position = posAt;
        checkCross.SetTrigger(opcion);
    }

    public bool GetWon()
    {
        if (star_won)
        {
            star_won = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetWonStars()
    {
        return counting_stars;
    }
}
