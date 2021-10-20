using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Randomizer
{
    static public int RandomizeByChancesArr(float[] chances)
    {
        
        float chancesSum = CalculateChancesSum(chances);
        float winnerTicket = Random.Range(0, chancesSum);

        return FindOutTheWinner(chances, winnerTicket);
    }


    static float CalculateChancesSum(float[] chances)
    {
        float chancesSum = 0;

        for (int i = 0; i < chances.Length; i++)
        {
            chancesSum += chances[i];
        }

        return chancesSum;
    }

    static int FindOutTheWinner(float[] chances, float winnerTicket)
    {
        
        int contenderNumber;
        float ticketsChecked = 0;

        for (contenderNumber = 0; contenderNumber < chances.Length; contenderNumber++)
        {
            float currentChance = chances[contenderNumber];
            if (winnerTicket - ticketsChecked <= currentChance)
                break;
            else
                ticketsChecked += currentChance;
        }

        return contenderNumber;
    }
}
