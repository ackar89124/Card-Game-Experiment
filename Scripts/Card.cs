using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public int type;
    public int cost;
    public int id;
    public string name;
    //public int abiVal;
    public List<Effect> effects;

    public Card(int num, string nam, int pri, int typ, List<Effect> lis)
    {
        id = num;
        name = nam;
        cost = pri;
        type = typ;
        //abiNam = abi;
        //abiVal = val;
        effects = new List<Effect>();
        effects = lis;
    }

    public string CardToString()
    {
        string temp = "";
        temp += id + ",";
        temp += name + ",";
        temp += cost + ",";
        temp += type + ",(";
        foreach (Effect effect in effects)
        {
            temp += (effect.type + "/" + effect.type) + "|";
        }
        temp = temp.Remove(temp.Length - 1);
        temp += ")";
        return temp;
    }

    public string ReturnAllInfomation()
    {
        string temp = "Card:" + id + " has a cost of " + cost + " and is ";
        switch (type)
        {
            case (1):
                temp += "an attack card.";
                break;
            case (2):
                temp += "a blocking card.";
                break;
            case (3):
                temp += "a special card.";
                break;
            default:
                temp += "an error card.";
                break;
        }
        temp += "\n";
        /*for (int i = 0; i < effects.Count; i++)
        {
            temp += ReturnEffect(effects[i].type, effects[i].strength);
            if (i != effects.Count - 1)
            {
                temp += ", ";
            }
        }
        temp += ".";*/
        return temp;
    }
    /*
        public string ReturnEffect(int type, int strength)
        {
            string temp;
            switch (type)
            {
                case 1:
                    temp = "Damage opponent for: " + strength + " points";
                    break;
                case 2:
                    temp = "Block: " + strength + " points of damage";
                    break;
                case 3:
                    temp = "Heal yourself for: " + strength + " points";
                    break;
                default:
                    temp = "Card Type Error";
                    break;
            }
            return temp;
        }*/

    public List<string> UsableEffectData()
    {
        List<string> list = new List<string>();
        string temp = "To be overwritten";
        switch (type)
        {
            case 1:
                temp = "Attack";
                break;
            case 2:
                temp = "Reaction";
                break;
            case 3:
                temp = "Special";
                break;
            default:
                temp = "Card Type Error";
                break;
        }
        list.Add(temp);
        foreach (Effect effect in effects)
        {
            switch (effect.type)
            {
                case 1: 	// Normal Damage
                    temp = "Dmg " + effect.strength;
                    break;
                case 2: 	// Block Normal Damage
                    temp = "Blc " + effect.strength;
                    break;
                case 3:		// Increase Health
                    temp = "Hp+ " + effect.strength;
                    break;
                case 4:		// Non-blockable Damage
                    temp = "ApD " + effect.strength;
                    break;
                case 5:		// Block Any Damage
                    temp = "Wrd " + effect.strength;
                    break;
                case 6:		// Draw Card
                    temp = "Drw " + effect.strength;
                    break;
                case 7:		// Discard Card
                    temp = "Drp " + effect.strength;
                    break;
                case 8:		// Opponent Discards Card
                    temp = "Dis " + effect.strength;
                    break;
                case 9:		// Heal Opponent
                    temp = "Hp- " + effect.strength;
                    break;
                case 10:	// Opponent Draws
                    temp = "ODr " + effect.strength;
                    break;
                case 11:	// Damage Self with Non-blockable Damage
                    temp = "Scr " + effect.strength;
                    break;
                default:
                    temp = "Error";
                    break;
            }
            list.Add(temp);
        }
        return list;
    }
}

