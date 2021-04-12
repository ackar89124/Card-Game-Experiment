using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppliedEffect
{
    public int[] player1 = new int[9];
    public int[] player2 = new int[9];

    public AppliedEffect()
    {
        Array.Clear(player1, 0, 9);
        Array.Clear(player2, 0, 9);
    }

    public void Apply(List<Effect> effects, int user)
    {
        if (user == 1)
        {
            foreach (Effect effect in effects)
            {
                switch (effect.type)
                {
                    case 1:
                        player2[0] += effect.strength;
                        break;
                    case 2:
                        player1[1] += effect.strength;
                        break;
                    case 3:
                        player1[2] += effect.strength;
                        break;
                    case 4:
                        player2[3] += effect.strength;
                        break;
                    case 5:
                        player1[4] += effect.strength;
                        break;
                    case 6:
                        player1[5] += effect.strength;
                        break;
                    case 7:
                        player1[6] += effect.strength;
                        break;
                    case 8:
                        player2[6] += effect.strength;
                        break;
                    case 9:
                        player2[2] += effect.strength;
                        break;
                    case 10:
                        player2[5] += effect.strength;
                        break;
                    case 11:
                        player1[7] += effect.strength;
                        break;
                    default:
                        Console.WriteLine("application of effect error");
                        break;
                }
            }
        }
        else
        {
            foreach (Effect effect in effects)
            {
                switch (effect.type)
                {
                    case 1:
                        player1[0] += effect.strength;
                        break;
                    case 2:
                        player2[1] += effect.strength;
                        break;
                    case 3:
                        player2[2] += effect.strength;
                        break;
                    case 4:
                        player1[3] += effect.strength;
                        break;
                    case 5:
                        player2[4] += effect.strength;
                        break;
                    case 6:
                        player2[5] += effect.strength;
                        break;
                    case 7:
                        player2[6] += effect.strength;
                        break;
                    case 8:
                        player1[6] += effect.strength;
                        break;
                    case 9:
                        player1[2] += effect.strength;
                        break;
                    case 10:
                        player1[5] += effect.strength;
                        break;
                    case 11:
                        player2[7] += effect.strength;
                        break;
                    default:
                        Console.WriteLine("application of effect error");
                        break;
                }
            }

        }
    }
}