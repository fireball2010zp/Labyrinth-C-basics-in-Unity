using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {

        private ListExecuteObject _interactiveObject;

        private InputController _inputController;
        // ссылка на объект, инициализация в Awake

        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;

        private int _bonusCount;

        [SerializeField] private BadBonus badBonus;
        [SerializeField] private GameObject _player;
        [SerializeField] private Button _restartButton;

        void Awake()
        {
            Time.timeScale = 1f;

            _reference = new Reference();

            _inputController = new InputController(_player.GetComponent<Unit>());
            // обращение к базовому классу через дочерний

            _interactiveObject = new ListExecuteObject();
            // создали лист перечислимых интерактивных объектов

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);

            _restartButton.onClick.AddListener(RestartGame);
            // стандартный Unity-подписчик

            _restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);
            // добавляем лист в InputController

            // badBonus.OnCaughtPlayer += GameOver;
            // подписываем обработчика событий

            // подписка
            foreach (var item in _interactiveObject)
            {
                if(item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddBonus;
                }

                if(item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayer += _viewEndGame.GameOver;
                    badBonus.OnCaughtPlayer += CaughtPlayer;
                }
            }
        }

        private void BadBonus_OnCaughtPlayer(string arg1, Color arg2)
        {
            throw new NotImplementedException();
        }

        private void CaughtPlayer(string value, Color args)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        // метод обработчика
        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewBonus.Display(_bonusCount);
        }

        /*
        // обработчик взаимодействия с BadBonus
        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
            _player.transform.position = new Vector3(22f, 1f, -20f);
        }
        */

        void Update()
        {
            _inputController.Update();

            for (int i = 0; i < _interactiveObject.Length; i++)
            // цикл перебирает интерактивные объекты
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }
                
                //_interactiveObject[i].Update();
                // вызываем апдейты в InputController
            }

            /*
            IEnumerator etr = _interactiveObject.GetEnumerator();

            while (etr.MoveNext())
            {
                Debug.Log(etr.Current);
            }
            etr.Reset();

            */
        }
    }
}

