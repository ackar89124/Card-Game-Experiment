using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript
{
    public Player player1 = new Player();
    public Player player2 = new Player();
    public AppliedEffect PAE = new AppliedEffect();

    bool chain = false;
    bool turnCounter = true;

    public BattleScript(Player p1, Player p2)
    {
        player1 = p1;
        player2 = p2;
    }

    public void ActivateCard(Player user, Player target, int c)
    {
        Card card;
        if (user == player1)
        {
            card = player1.hand[c];
        }
        else
        {
            card = player2.hand[c];
        }
        ActivateCard(user, target, card);
    }

    public void ActivateCard(Player user, Player target, Card card)
    {

        if (card.type != 2 && chain)
        {
            EndChain();
        }
        else
        {
            chain = true;
        }
        if (user == player1)
        {
            PAE.Apply(card.effects, 1);
        }
        else
        {
            PAE.Apply(card.effects, 2);
        }
        endTurn();
    }

    public void EndChain()
    {
        // Player 1
        // Calculate health
        int hpMod = PAE.player1[0] - PAE.player1[1];
        if (hpMod < 0) { hpMod = 0; }
        hpMod += PAE.player1[3] - PAE.player1[4];
        if (hpMod < 0) { hpMod = 0; }
        hpMod -= PAE.player1[2] - PAE.player1[7];
        player1.hp -= hpMod;
        // Drawing
        for (int d = 0; d < (PAE.player1[5]); d++)
        {
            player1.hand.Add(player1.deck.Drawing());
        }
        // Discard random
        for (int d = 0; d < (PAE.player1[6]); d++)
        {
            player1.hand.RemoveAt(Random.Range(0, player1.hand.Count));
            //player1.hand.RemoveAt(random.Next(0, player1.hand.Count));
        }
        // Player 2
        // Calculate health
        hpMod = PAE.player2[0] - PAE.player2[1];
        if (hpMod < 0) { hpMod = 0; }
        hpMod += PAE.player2[3] - PAE.player2[4];
        if (hpMod < 0) { hpMod = 0; }
        hpMod -= PAE.player2[2] - PAE.player2[7];
        player2.hp -= hpMod;
        // Drawing
        for (int d = 0; d < (PAE.player2[5]); d++)
        {
            player2.hand.Add(player2.deck.Drawing());
        }
        // Discard random
        for (int d = 0; d < (PAE.player2[6]); d++)
        {
            player2.hand.RemoveAt(Random.Range(0, player2.hand.Count));
            //player2.hand.RemoveAt(random.Next(0, player2.hand.Count));
        }

        PAE = new AppliedEffect();
    }

    public void endGame()
    {

    }

    public void endTurn()
    {
        turnCounter ^= true;
    }
}
