using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewMovement : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Point4;
	public float speed = 1.2f;
	public float espera = 0;
    public bool startHidden;
    public bool charSelectMode;

    private bool movementLock = true;
    private Vector3 TargetPoint;
    private bool arrived;
    private bool hideOnArrival = false;
	private bool selfDestruct = false;
	private bool facingRight = true;
	private float timer = 0;

    // Use this for initialization
    void Start()
    {
        if (startHidden)
        {
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        arrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementLock)
		{
			timer += Time.deltaTime;
			if(timer >= espera)
			{
	            float step = speed * Time.deltaTime;
	            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetPoint, step);
	            if (gameObject.transform.position == TargetPoint)
	            {
	                movementLock = true;
					arrived = true;
					timer = 0;

	                if (hideOnArrival)
	                {
						//gameObject.GetComponent<SpriteRenderer>().enabled = false;
	                }

					if (selfDestruct)
					{
						DestroyAllPoints();
					}

	                if (charSelectMode)
					{ 
						//gameObject.GetComponent<Animator>().ResetTrigger("walk");
						//gameObject.GetComponent<Animator>().ResetTrigger("WalkBackTrigger");
	                    gameObject.GetComponent<Animator>().SetTrigger("unique");
	                }
	            }
            }				
        }
    }

    public void DoMove(Vector3 objective)
    {
        TargetPoint = objective;
        movementLock = false;
        arrived = false;
    }

    public void DoMove(GameObject objective1)
    {
        Vector3 objective = objective1.transform.position;
        TargetPoint = objective;
        movementLock = false;
        arrived = false;
    }

    public void DoMove(int destination, bool hide, bool destruct)
    {
        if (destination == 1)
        {
            TargetPoint = Point1.transform.position;
            if (charSelectMode)
            {
                //gameObject.GetComponent<Animator>().ResetTrigger("walk");
                //gameObject.GetComponent<Animator>().ResetTrigger("unique");
                FlipGOLeft();
                gameObject.GetComponent<Animator>().SetTrigger("walk");
            }
        }

        if (destination == 2)
        {
            TargetPoint = Point2.transform.position;
            if (charSelectMode)
            {
                //gameObject.GetComponent<Animator>().ResetTrigger("WalkBackTrigger");
                //gameObject.GetComponent<Animator>().ResetTrigger("unique");
                FlipGORight();
                gameObject.GetComponent<Animator>().SetTrigger("walk");
            }
        }

        if (destination == 3)
        {
            TargetPoint = Point3.transform.position;
            if (charSelectMode)
            {
                //gameObject.GetComponent<Animator>().ResetTrigger("WalkBackTrigger");
                //gameObject.GetComponent<Animator>().ResetTrigger("unique");
                gameObject.GetComponent<Animator>().SetTrigger("walk");
            }
        }

        if (destination == 4)
        {
            TargetPoint = Point4.transform.position;
        }

        hideObject(true);

        if (hide)
            hideOnArrival = true;
        else
            hideOnArrival = false;

        if (destruct)
            selfDestruct = true;
        else
            selfDestruct = false;

        movementLock = false;
        arrived = false;

    }

    public void DoMove(int destination)
    {
        if (destination == 1)
        {
            TargetPoint = Point1.transform.position;
            if (charSelectMode)
            {
                //gameObject.GetComponent<Animator>().ResetTrigger("walk");
                //gameObject.GetComponent<Animator>().ResetTrigger("unique");
                //gameObject.GetComponent<Animator>().SetTrigger("WalkBackTrigger");
            }
        }

        if (destination == 2)
        {
            TargetPoint = Point2.transform.position;
            if (charSelectMode)
            {
                //gameObject.GetComponent<Animator>().ResetTrigger("WalkBackTrigger");
                //gameObject.GetComponent<Animator>().ResetTrigger("unique");
                gameObject.GetComponent<Animator>().SetTrigger("walk");
            }
        }

        if (destination == 3)
        {
            Debug.Log("paso por acá");
            TargetPoint = Point3.transform.position;
        }

        if (destination == 4)
        {
            TargetPoint = Point4.transform.position;
        }

        hideObject(true);

        hideOnArrival = false;
        selfDestruct = false;

        movementLock = false;
        arrived = false;

    }

    public void DoStop()
    {
        movementLock = true;
    }

    public bool GetMovement()
    {
        return movementLock;
    }

    public bool GetArrived()
    {
        return arrived;
    }

    public void SetArrived(bool opcion)
    {
        arrived = opcion;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
    }

    public Vector3 GetPos1()
    {
        return Point1.transform.position;
    }

    public Vector3 GetPos2()
    {
        return Point2.transform.position;
    }

    public Vector3 GetPos3()
    {
        return Point3.transform.position;
    }

    public Vector3 GetPos4()
    {
        return Point4.transform.position;
    }

	public void SetPos1( Vector3 newPos )
	{
		Point1 = new GameObject ();
		Point1.transform.position = newPos;
	}
	
	public void SetPos2( Vector3 newPos )
	{
		Point2 = new GameObject ();
		Point2.transform.position = newPos;
	}
	
	public void SetPos3( Vector3 newPos )
	{
		Point3 = new GameObject ();
		Point3.transform.position = newPos;
	}
	
	public void SetPos4( Vector3 newPos )
	{
		Point4 = new GameObject ();
		Point4.transform.position = newPos;
	}

	public void SetPos1( GameObject newPos )
	{
		Point1 = newPos;
	}

	public void SetPos2( GameObject newPos )
	{
		Point2 = newPos;
	}

	public void SetPos3( GameObject newPos )
	{
		Point3 = newPos;
	}

	public void SetPos4( GameObject newPos )
	{
		Point4 = newPos;
	}

    private void hideObject(bool enabler)
    {
        if (gameObject.GetComponent<SpriteRenderer>())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = enabler;
        }

        if (gameObject.GetComponent<Image>())
        {
            gameObject.GetComponent<Image>().enabled = enabler;
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);

        facingRight = !facingRight;
    }

	private void DestroyAllPoints()
	{
		GameObject.Destroy (Point4);
		GameObject.Destroy (Point3);
		GameObject.Destroy (Point2);
		GameObject.Destroy (Point1);
	}

    private void FlipGORight()
    {
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        if (theScale.x < 0)
            theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FlipGOLeft()
    {
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        if (theScale.x > 0)
            theScale.x *= -1;
        transform.localScale = theScale;
    }
}