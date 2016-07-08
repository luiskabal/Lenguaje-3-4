using UnityEngine;
using System.Collections;

public class Halp : MonoBehaviour {

    public static string cambioUnidades(int numeroNumero)
    {
        if (numeroNumero == 0)
        {
            return "0";
        }
        else if (numeroNumero < 10)
        {
            return "0" + numeroNumero;
        }
        else
        {
            if (numeroNumero >= 1000)
            {
                string numeroCambiado = numeroNumero.ToString("#,0");
                numeroCambiado = numeroCambiado.Replace(",", ".");
                return numeroCambiado;
            }
            else
            {
                return numeroNumero.ToString();
            }
        }
    }

    public static int[] StartArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        return arr;
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = UnityEngine.Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
