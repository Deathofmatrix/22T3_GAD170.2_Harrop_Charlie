using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FishingGame
{
    public class TextDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textFieldUI;

        public void AddText(string textToAdd)
        {
            textFieldUI.text += textToAdd + "\n";
        }

        public void ChangeText(string textToChange)
        {
            textFieldUI.text = textToChange;
        }

        public void ClearText()
        {
            textFieldUI.text = "";
        }

        public void Problems()
        {
            ClearText();
            AddText("Something has gone wrong!!");
        }
    }
}

