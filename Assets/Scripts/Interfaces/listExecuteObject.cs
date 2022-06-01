using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maze
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    /* ���������� IEnumerator � IEnumerable ��������� ���������� ��������� 
     ������������� ��������
     ��������� IEnumerable ���������� ������ �� ������������� */
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public object Current => _interactiveObject[_index];
        /* �������� ��������� ������ �������� �������� � ��������� */
        public int Length => _interactiveObject.Length;
        // ��� ���������� ���-�� ��������� � ������� (�����)

        public ListExecuteObject()
        {
            Bonus[] BonusObject = Object.FindObjectsOfType<Bonus>();
            for (int i = 0; i < BonusObject.Length; i++)
            {
                if(BonusObject[i] is IExecute intObj)
                {
                    AddExecuteObject(intObj);
                }
            }
        }

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public void AddExecuteObject(IExecute execute)
        // ����� ���������� ������� � �������
        {
            if(_interactiveObject == null) // ���� � ������� ������ ���
            {
                _interactiveObject = new[] {execute}; // ������ ������
                return;
            }

            Array.Resize(ref _interactiveObject, Length+1); 
            // ���� ���������� ������, 
            _interactiveObject[Length-1] = execute;
            // ��������� �� ��������� ������� ������
        }


        public bool MoveNext()
        // ����� ��������� ������ ���������, �� 1 ������� �����
        {
            if (_index == Length-1) // �������� �� ����������� �� ���������
            {
                Reset();
                return false; // ���� ����������� ������������������
            }

            _index++;
            return true; // ���� �� ����������� ������������������
        }

        public void Reset()
        // ���������� ������ � ������ ���������
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        /* IEnumerator ���������� ���������� ��� �������� ����������
         �������� � ���������� */
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

