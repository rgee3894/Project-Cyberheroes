using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator{

    private bool isMultiplication;
    private int firstOperand, secondOperand, answer;

    public ProblemGenerator()
    {
        if (Random.Range(1, 100) > 50)
            isMultiplication = true;
        else
            isMultiplication = false;
        
        bool isDivisible = false;
        firstOperand = Random.Range(1,10);
        secondOperand = Random.Range(2,10);
        answer = firstOperand * secondOperand;

        if(!isMultiplication)
        {
            int temp = firstOperand;
            firstOperand = answer;
            answer = temp;

        }

    }

    public bool IsMultiplication()
    {
        return isMultiplication;
    }

    public int GetFirstOperand()
    {
        return firstOperand;
    }

    public int GetSecondOperand()
    {
        return secondOperand;
    }

    public int GetAnswer()
    {
        return answer;
    }
}