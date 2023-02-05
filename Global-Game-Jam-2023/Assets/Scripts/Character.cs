using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int initialHand = 5;
    public abstract void ModifyHealth(int change);
    
    public List<RootData> deck;

    public List<RootData> discards;

    public List<RootData> DrawCards(int numDraws)
    {
        List<RootData> draws = new List<RootData>();
        for (int i = 0; i < numDraws; i++)
        {
            if (deck.Count == 0)
            {
                deck.AddRange(Shuffle(discards));
                discards.Clear();
            }

            if (deck.Count != 0)
            {
                draws.Add(deck[0]);
                deck.RemoveAt(0);
            }
        }

        return draws;
    }

    public List<RootData> Shuffle(List<RootData> cards)
    {
        var output = new List<RootData>();
        int numCards = cards.Count;
        for (int i = 0; i < numCards; i++)
        {
            int selection = Random.Range(0, cards.Count - 1);
            output.Add(cards[selection]);
            cards.RemoveAt(selection);
        }

        return output;
    }
}
