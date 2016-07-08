using UnityEngine;
using System.Collections;

public class SeparadorHijos : MonoBehaviour {

    public float separation;
    public int quantityPerLine;
    public bool startFromCenter;
    public int row;
    public int column;

    public void Separate()
    {
        int counterX = 0;
        int counterY = 0;
        int Hijos = row * column;
        
        if (startFromCenter)
        {
            EverybodyToZero();
        }

        Debug.Log(Hijos/quantityPerLine);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(
                (-1 * ((separation / 2) * (quantityPerLine - 1))) + (counterX * separation),
                ((separation / 2) * ((Hijos / quantityPerLine) - 1)) - (counterY * separation),
                0
                );

            if (counterX + 1 < quantityPerLine)
            {
                counterX++;
            }
            else
            {
                counterX = 0;
                counterY++;
            }
        }
    }

    public void EverybodyToZero()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }

    public void MakeSquare(int row, int column)
    {
        int Quantity = row * column;

        EverybodyAppear();

        for (int i = transform.childCount - 1; i >= Quantity; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        this.row = row;
        this.column = column;

        quantityPerLine = row;
        Separate();
    }

    public void MakeSquare()
    {
        int Quantity = row * column;

        EverybodyAppear();

        for (int i = transform.childCount -1; i >= Quantity; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        quantityPerLine = row;
        Separate();
    }

    private void EverybodyAppear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
