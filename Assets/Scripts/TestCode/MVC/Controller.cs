using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Controller
    {
        /* назначаем нужные ссылки (отслеживаем взаимодействие игрока
        с триггером - положение игрока и вьюшки игрока с триггером) */

        private Transform _playerT;
        private View _triggerT;
        private View _playerView;

        /* в конструкторе инициализируем ссылки)*/
        public Controller(View player, View trigger)
        {
            _playerView = player;
            _playerT = player._transform; // ссылка на transform из View
            _triggerT = trigger; // ссылка на trigger из Main 

            // подписываемся на событие через обработчик ControllerRecieveAction
            // при возникновении события OnLevelObjectContact из View, которое
            // срабатывает с триггере, когда в него попадает игрок 
            _triggerT.OnLevelObjectContact += ControllerRecieveAction;
        }

        // обработчик для события, имеет такую же сигнатуру как и Action 
        private void ControllerRecieveAction(Collider contactView, int Val, Transform valT)
        {
            Debug.Log("Обработчик события: Имя объекта в триггере " + contactView.gameObject.name);

            // уничтожаем игрока через Destroy (метод класса gameObject)
            GameObject.Destroy(contactView.gameObject);
        }

        // метод апдейта (только своего, не MonoBehaviour)
        public void MyUpdate()
        {
            
        }
    }
}


/*
Скрипт отвечает за обработку события, подписка на событие (или например отписка, когда 
контроллер будет уничтожаться после зваимодействия).
Содержит конструктор, не наследуется от MonoBehaviour, класс сам по себе, инициализируется 
в скрипте Main.
 */