using System;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {

        private ListExecuteObject _interactiveObject;

        private InputController _inputController;
        // ������ �� ������, ������������� � Awake

        [SerializeField] private BadBonus badBonus;

        [SerializeField] private GameObject _player;

        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            // ��������� � �������� ������ ����� ��������

            _interactiveObject = new ListExecuteObject();
            // ������� ���� ������������ ������������� ��������

            _interactiveObject.AddExecuteObject(_inputController);
            // ��������� ���� � InputController

            badBonus.OnCaughtPlayer += GameOver;
            // ����������� ����������� �������
        }

        // ���������� �������������� � BadBonus
        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
            _player.transform.position = new Vector3(22f, 1f, -20f);
        }

        void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            // ���� ���������� ������������� �������
            {
                if(_interactiveObject[i] == null)
                {
                    continue;
                }
                _interactiveObject[i].Update();
                // �������� ������� � InputController
            }


        }
    }
}

