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

        // метод для вывода
        public void GameOver(string name, Color color)
        {
            _endGameLabel.text = $"Game Over. Bonus Name: {name}. Color: {color}";
        }
    }
}

