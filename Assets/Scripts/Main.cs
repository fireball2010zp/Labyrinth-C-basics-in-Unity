using System;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {

        private ListExecuteObject _interactiveObject;

        private InputController _inputController;
        // ссылка на объект, инициализация в Awake

        [SerializeField] private BadBonus badBonus;

        [SerializeField] private GameObject _player;

        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            // обращение к базовому классу через дочерний

            _interactiveObject = new ListExecuteObject();
            // создали лист перечислимых интерактивных объектов

            _interactiveObject.AddExecuteObject(_inputController);
            // добавляем лист в InputController

            badBonus.OnCaughtPlayer += GameOver;
            // подписываем обработчика событий
        }

        // обработчик взаимодействия с BadBonus
        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
            _player.transform.position = new Vector3(22f, 1f, -20f);
        }

        void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            // цикл перебирает интерактивные объекты
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }
                _interactiveObject[i].Update();
                // вызываем апдейты в InputController
            }


        }
    }
}

