using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FishingGame
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private string species;
        [SerializeField] private float length;
        [SerializeField] private int dollarValue;

        public void SetStats(string newSpecies, float newLength, int newDollarValue)
        {
            species = newSpecies;
            length = newLength;
            dollarValue = newDollarValue;
        }

        public string GetSpecies()
        {
            return species;
        }

        public float GetLength()
        {
            return length;
        }

        public int GetDollarValue()
        {
            return dollarValue;
        }

        public void IsFishEaten()
        {
            Destroy(gameObject);
        }

    }
}

