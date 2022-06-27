using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    /* скрипт никак не связан с Unity */
    {
        private PlayerController _player;
        // вызов игрока по базовому классу

        private float horizontal;
        private float vertical;
        // оси

        public InputController(PlayerController player)
        // конструктор с ссылкой на Unit, инициализация в теле
        {
            _player = player;
        }

        public void Update()
        // Update - уже отвязанный от MonoBehaviour, не путать!
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            // запрашваем оси из класса Input

            _player.Move(horizontal, 0f, vertical);
            /* формируем метод перемещения игрока
               можем прописывать любые запрошенные оси,
               место для реализации любого метода управления */


            if (Input.GetKeyDown(KeyCode.Q))
            {
                _player.SavePlayer();
            }

        }
    }
}

