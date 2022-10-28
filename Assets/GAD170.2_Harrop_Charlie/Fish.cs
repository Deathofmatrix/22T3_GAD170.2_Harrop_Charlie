using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingGame
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private string species;
        [SerializeField] private float length;
        [SerializeField] private int dollarValue;

        public void SetStats(string newSpecies, float newLength, int newdollarValue)
        {
            species = newSpecies;
            length = newLength;
            dollarValue = newdollarValue;
        }

        public string GetSpecies()
        {
            return species;
        }

        public float GetLenth()
        {
            return length;
        }

        public int GetDollarValue()
        {
            return dollarValue;
        }

        public bool IsFishEaten()
        {
            return true;
        }

    }
}

