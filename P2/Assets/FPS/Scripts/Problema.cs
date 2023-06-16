using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int target;
        int[] numeros = new int[] { 2, 9, 5, 1, 7 };
        //1 2 5 9 7
        int[] output = new int[2];
        target = 6;
        acomodar(numeros);
        SumarDos(numeros, target, output);
        Debug.Log("Indice 1: " + output[0] + " Indice 2: " + output[1]);
    }


    public void SumarDos(int[] nums, int target, int[] output)
    {
        int aux;
        for(int i = 0; i<nums.Length-1 ;i++)
        {
            for(int j = 0; j<nums.Length;j++)
            {
                aux = 0;
                aux = nums[i] + nums[j];
                if(aux == target)
                {
                    output[0] = j;
                    output[1] = i;
                }
            }
        }
    }

    public void acomodar(int[] numeros)
    {
        int temp;
         for (int j = 0; j <= numeros.Length - 2; j++) {
            for (int i = 0; i <= numeros.Length - 2; i++) {
               if (numeros[i] > numeros[i + 1]) {
                  temp= numeros[i + 1];
                  numeros[i + 1] = numeros[i];
                  numeros[i] = temp;
               }
            }
         }
    }
}
