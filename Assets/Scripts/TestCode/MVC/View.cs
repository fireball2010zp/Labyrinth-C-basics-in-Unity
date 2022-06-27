using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class View : MonoBehaviour
    {
        // обычно определяем такие поля
        [SerializeField] public Transform _transform; // перемещение в пространстве
        [SerializeField] public Collider _collider; // для взаимодействия на сцене
        [SerializeField] public Rigidbody _rb; // физическое тело

        /* т.к. вызов события может быть каждый кадр, поэтому уведомлять подписчика 
        будем через систему Action, т.е. воспользуемся делегатом типа Action с 3-мя 
        параметрами и дополнениями (сеттер и геттер, чтобы OnLevelObjectContact был
        полем)        
         */
        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }

        /* также будет на счене проиходить коллизия, будет отслеживаться на сцене 
        (физика отслеживается в пространстве редактора) вход объекта в триггер 
        через OnTriggerEnter */
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name); // только для отладки
            Collider LevelObject = other; // временная ссылка

            /* далее вызываем событие OnLevelObjectContact, в который передаём 
            коллайдер (other), какое-то число и положение коллайдера */
            OnLevelObjectContact?.Invoke(LevelObject, 12, LevelObject.transform);       
        }

    }
}


/*
Скрипт представлен только ссылками (3 шт) и навешивается на все объекты на сцене 
(Player и Trigger, кроме условной земли (объект Ground)).

Ссылки в инспекторе Unity назначаются в ручную для каждого объекта (Player и Trigger
- у каждого свои Transform, Collider и Rigidbody (только у Player)).

 */

