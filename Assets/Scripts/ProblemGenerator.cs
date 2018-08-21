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
        

        firstOperand = Mathf.RoundToInt(Random.Range(2, 100));
        secondOperand = Mathf.RoundToInt(Random.Range(firstOperand,100));

        if (isMultiplication)
            answer = firstOperand * secondOperand;
        else
            answer = secondOperand / firstOperand;

        answer = Mathf.RoundToInt(answer);

    }

    private bool getOperation()
    {
        return isMultiplication;
    }

    private int getFirstOperand()
    {
        return firstOperand;
    }

    private int getSecondOperand()
    {
        return secondOperand;
    }

    private int getAnswer()
    {
        return answer;
    }
}