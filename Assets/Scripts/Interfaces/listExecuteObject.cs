using System;
using System.Collections;
using UnityEngine;

namespace Maze
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    /* интерфейсы IEnumerator и IEnumerable позвол€ют перебирать коллекции 
     интерактивных объектов
     интерфейс IEnumerable возвращает ссылку на перечислитель */
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public object Current => _interactiveObject[_index];
        /* свойство указывает индекс текущего элемента в коллекции */
        public int Length => _interactiveObject.Length;
        // дл€ считывани€ кол-ва элементов в массиве (длина)

        void Start()
        {

        }

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public void AddExecuteObject(IExecute execute)
        // метод добавлени€ объекта в массива
        {
            if(_interactiveObject == null) // если в массиве ничего нет
            {
                _interactiveObject = new[] {execute}; // создаЄм массив
                return;
            }

            Array.Resize(ref _interactiveObject, Length+1); 
            // если существует массив, 
            _interactiveObject[Length-1] = execute;
            // добавл€ем на последнюю позицию объект
        }


        public bool MoveNext()
        // отдаЄт следующий объект коллекции, на 1 позицию вперЄд
        {
            if (_index == Length-1) // проверка не закончилась ли коллекци€
            {
                Reset();
                return false; // если закончилась последовательность
            }

            _index++;
            return true; // если не закончилась последовательность
        }

        public void Reset()
        // перемещает индекс в начало коллекции
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        /* IEnumerator определ€ет функционал дл€ перебора внутренних
         объектов в контейнере */
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

