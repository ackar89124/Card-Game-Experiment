using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<Card> hand;
    public Deck deck;
    private Deck Permininent;
    public int hp;
    //public int character;
    public Player enemy;

    public Player()
    {
        hand = new List<Card>();
        deck = new Deck();
        hp = 100;
        //character = 0;
    }

    public void Link(Player target)
    {
        enemy = target;
    }

    public void SetDeck(Deck d)
    {
        Permininent = d;
    }

    /*public void PlayCard(int c)
    {
        Card card = hand.RemoveCard(c);
        ApplyEffect(card.effects);
    }

    public void PlayCard(Card card)
    {
        hand.RemoveCard(card);
        ApplyEffect(card.effects);
    }

    private void ApplyEffect(List<Effect> effects)
    {

    }*/
}
