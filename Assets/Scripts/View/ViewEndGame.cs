using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class ViewEndGame : MonoBehaviour
    {
        public Text _endGameLabel;


        public ViewEndGame(GameObject endGamePrefab)
        {
            _endGameLabel = endGamePrefab.GetComponent<Text>();
            _endGameLabel.text = string.Empty;
        }

        // метод для вывода поражения (BadBonus)
        public void GameOver(string name, Color color)
        {
            _endGameLabel.text = $"Game Over. Bonus Name: {name}. Color: {color}";
        }

        // метод для вывода победы (GoodBonus = 5)
        public void Victory(int value)
        {
            _endGameLabel.text = $"Victory. GoodBonus: {value}";
        }
    }
}

