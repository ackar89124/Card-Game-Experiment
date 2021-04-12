using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public List<Card> cards = new List<Card>();
    public int maxHealth = 100;
    private int health;
    private int totalCost = 0;
    public int character = 0;
    public string deckName = "Deck";
    //private Random random = new Random();

    public Deck()
    {
        health = BalancedHealth();
    }

    public void SetName(string nam)
    {
        deckName = nam;
    }
    public void Sort()
    {
        // sort based on cost
    }
    public void Insert(Card c)
    {
        // add card to deck 24,5,16 : 28,9,17
        cards.Add(c);
    }
    public void DeleteCard(int i)
    {
        // remove card at position
        cards.RemoveAt(i);
    }
    public void DeleteCard(Card c)
    {
        // remove card at position
        cards.Remove(c);
    }
    public bool Save()
    {
        // save deck
        return true;
    }
    /*public void SetRandom(Random ran)
    {
        random = ran;
    }*/

    public void Randomize()
    {
        // create a deck out of random cards
        List<Card> tempCards = new List<Card>();
        Card c;
        while (cards.Count > 0)
        {
            c = cards[Random.Range(0, cards.Count)];
            tempCards.Add(c);
            cards.Remove(c);
        }
        cards = tempCards;
        //random = new Random();
    }

    public string DeckAsString()
    {
        string data = "$,";
        data += deckName + "," + character.ToString() + "," + CardsIdsToString();
        return data;
    }

    public string CardsIdsToString()
    {
        string temp = "";
        foreach (Card card in cards)
        {
            temp += card.id + ",";
        }
        temp = temp.Remove(temp.Length - 1);
        return temp;
    }

    public Card Drawing()
    {
        // draw from top/bottom of deck
        Card card = cards[0];
        DeleteCard(0);
        return card;
    }

    public int CurrentHp()
    {
        return health;
    }

    /// Experimental health system 
    public int BalancedHealth()
    {
        health = maxHealth - totalCost;
        return health;
        /// different classes can have different max health but different min/max size of their decks
        /// Class: Barbarian; each card they play, they draw a card meaning that they never have to rest, cost of cards increase or max health decrease
        /// Class: Squire; standard no buffs and no penitlies (maybe a slight increase to max health to make it the best actual class, but the least interesting)
        /// Class: Rouge; reduced health, always draws 2 when stepping back, debuff to def cards
        /// Class: Baron; extra health, bonus to block cards, debuff to attack cards
        /// Class: Bard; bonus to specials but debuff to attack and defencive cards
        /// Class: Warpreist; heals a small amount (up to max) each rest, less money or only ever draw one card form rest
        /// Classes: each class is a charater with their own deck slots, like duel links, this means it can stop some confussion, better ui options and allows charaters to have different restrictions and point costs
        /// What happens when you attack after an attack? higher overides? parry? pierce damage? no effect happens and the first attack deals damage but the the orginal attacker can respond (for instance with a block card) to the attack made by the attacked... basicly, they just hit each other and carry on as normal, make a card effect chain... thats going to be a problem. 
        /// After an attack is made, damage will not be dealt untill the attack responds: attack card = ???, block card: reduce damage by number, special card: applies effect (blocks damage, inflicts damage, heals or whatever, damage is not treated as attack card and block does not count as block card. You can only counter a special effect with a card that targets a special card), step back: take damage and draw on card.
    	/// Secondwind abillity (could activate card or activate abbility based on card drawm)
    }
}
