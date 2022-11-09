using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


namespace FishingGame
{
    public class Aquarium : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Fish fishPrefab;
        [SerializeField] private TextDisplay textDisplay;
        [SerializeField] private TextDisplay aquariumTextDisplay;
        [SerializeField] private TextDisplay eatenTextDisplay;
        [SerializeField] private GameObject restartButton;
        [SerializeField] private GameObject quitButton;

        [Header("Collections")]
        [SerializeField] private string[] fishTypes = new string[8] { "Tilipia", "Salmon", "Walleye", "Shad", "Lingcod", "Lionfish", "Albacore", "Chub" };
        [SerializeField] private List<Fish> allFish;

        [Header("Variables")]
        private int totalScore;
        private int turnCounter;
        private Fish newestFish;
        private int maxTurn = 10;

        private void Start()
        {
            NewGame();
        }

        //Creates the instantiation of the fish class
        private void CreateFish()
        {
            //sets stats and instantiates Fish
            fishPrefab.SetStats(fishTypes[Random.Range(0, 8)], Random.Range(10.0f, 100.0f), Random.Range(20, 200));
            newestFish = Instantiate(fishPrefab, transform);

            //sets the name of the fish
            newestFish.name = "Species:" + newestFish.GetSpecies() + " Length:" + newestFish.GetLength() + "cm Price:$" + newestFish.GetDollarValue();

            //displays the text on screen as well as displays in the console
            textDisplay.ChangeText("Species:" + newestFish.GetSpecies() + "\nLength:" + newestFish.GetLength() + "cm\nPrice:$" + newestFish.GetDollarValue());
            Debug.Log("Species:" + newestFish.GetSpecies() + " Length:" + newestFish.GetLength() + "cm Price:$" + newestFish.GetDollarValue());
        }

        //Connected to Keep Fish button
        public void KeepFish()
        {
            //clear fish eaten
            eatenTextDisplay.ClearText();

            //checks if any fish are eaten in the aquarium as they are caught
            foreach (Fish fish in allFish.ToList())
            {
                if (newestFish.GetLength()/2 > fish.GetLength())
                {
                    totalScore -= fish.GetDollarValue();
                    Destroy(fish.gameObject);
                    allFish.Remove(fish);
                    eatenTextDisplay.AddText("Fish has been eaten");
                }
            }
            //adds new fish to aquarium
            allFish.Add(newestFish);
            //increases total score
            totalScore += newestFish.GetDollarValue();

            Debug.Log("$" + totalScore);

            NewTurn();
        }

        //Connected to Throw Back button
        public void ThrowBack()
        {
            //destroys current fish
            Destroy(newestFish.gameObject);

            NewTurn();
        }

        public void NewTurn()
        {
            //displays the fish that are currently in your aquarium
            aquariumTextDisplay.ClearText();
            aquariumTextDisplay.AddText("Aquarium Value:$" + totalScore + "\n");

            //displays the fish name (stats) in the aquarium from the allfish list
            foreach (Fish fish in allFish)
            {
                aquariumTextDisplay.AddText(fish.name + "\n");
            }

            //turn system
            turnCounter += 1;
            if (turnCounter == maxTurn)
            {
                GameOver();
            }
            else
            {
                CreateFish();
            }
        }

        public void GameOver()
        {
            //displays total score
            textDisplay.ChangeText("Your Aquarium Value:\n" + "$" + totalScore);

            //activates the game over buttons
            restartButton.SetActive(true);
            quitButton.SetActive(true);

        }
        public void NewGame()
        {
            //destroys all the children of the aquarium gameobject which are all the fish the player has
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            //clears all the textboxes
            aquariumTextDisplay.ClearText();
            textDisplay.ClearText();

            //resets the turn timer
            turnCounter = 0;

            //resets score
            totalScore = 0; 

            //clears the list of Fish
            allFish.Clear();

            //bring the correct UI back
            restartButton.SetActive(false);
            quitButton.SetActive(false);

            //makes a new fish
            CreateFish();
        }

        public void Quit()
        {
            //quit option
            Application.Quit();
        }
    }
}
