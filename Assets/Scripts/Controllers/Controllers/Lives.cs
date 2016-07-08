using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Image currentAvatar;
    public Text livesText;
	public Sprite[] lifePortraits;

	private int currentLives;
	private int maxLives;

	// Use this for initialization
	void Start () 
	{
		//currentLives = 9;
		//maxLives = currentLives;
        currentAvatar.GetComponent<Image>().sprite = lifePortraits[0];
        //livesText.text = "x "+ Halp.cambioUnidades(currentLives);
    }
	
	public bool TakeLife() 
	{
        currentLives = currentLives - 1;

        if (currentLives <= 0)
        {
            currentLives = 0;
            livesText.text = "x " + Halp.cambioUnidades(currentLives);
            return true;
        }
        else
        {
            //ANIMATOR ??
            //gameObject.GetComponent<Animator>().SetTrigger("LifeOn");
            livesText.text = "x " + Halp.cambioUnidades(currentLives);
            return false;
        }  
    }

	public void GainLife (int lifeRestored)
	{
        if (currentLives < maxLives)
        {
            for (int i = 0; i < lifeRestored; i++)
            {
                //ANIMATOR ??
                //gameObject.GetComponent<Animator>().SetTrigger("LifeOn");
            }

            currentLives++;
        }

        livesText.text = "x " + Halp.cambioUnidades(currentLives);
    }


	public void RestoreAllLife(bool instant)
	{
        //ANIMATOR ??
        //gameObject.GetComponent<Animator>().SetTrigger("LifeOn");
        currentLives = maxLives;
        livesText.text = "x " + Halp.cambioUnidades(currentLives);
    }

	public int GetRemaining()
	{
		return currentLives;
	}
	
    public void SetLives(int lives, int personaje)
    {
        currentLives = lives;
        maxLives = lives;

        currentAvatar.GetComponent<Image>().sprite = lifePortraits[personaje];
        livesText.text = "x " + Halp.cambioUnidades(currentLives);
    }

    public void SetAvatar(int option)
    {
        currentAvatar.GetComponent<Image>().sprite = lifePortraits[option];
    }
}
