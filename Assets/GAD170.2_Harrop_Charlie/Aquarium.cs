using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace FishingGame
{
    public class Aquarium : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Fish fishPrefab;

        [Header("Collections")]
        [SerializeField] private string[] fishTypes = new string[8] { "Tilipia", "Salmon", "Walleye", "Shad", "Lingcod", "Lionfish", "Albacore", "Chub" };
        [SerializeField] private List<Fish> allFish;
        

        private void Start()
        {
            CreateFish();

        }

        private void CreateFish()
        {

            fishPrefab.SetStats(fishTypes[Random.Range(0, 8)], Random.Range(10.0f, 80.0f), Random.Range(20, 200));
            Fish newFish = Instantiate(fishPrefab, transform);
            allFish.Add(newFish);
        }

        //Connected to Throw Back button
        public void ThrowBack()
        {
            NewTurn();
        }

        //Connected to Keep Fish button
        public void KeepFish()
        {
            NewTurn();
        }

        public void NewGame()
        {

        }

        public void NewTurn()
        {
            CreateFish();

        }

        public void EndTurn()
        {

        }

        public void GameOver()
        {

        }
    }
}
