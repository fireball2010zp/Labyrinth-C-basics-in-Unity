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
        // ������ �� ������, ������������� � Awake

        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;
        private ViewEndGame _viewVictoryGame;

        private CameraController _cameraController;

        private int _bonusCount;

        [SerializeField] private BadBonus badBonus;
        [SerializeField] private GoodBonus goodBonus;
        [SerializeField] private GameObject _player;
        [SerializeField] private Button _restartButton;

        void Awake()
        {
            Time.timeScale = 1f;

            _reference = new Reference();

            _inputController = new InputController(_player.GetComponent<Unit>());
            // ��������� � �������� ������ ����� ��������

            _cameraController = new CameraController (_player.transform, _reference.MainCamera.transform);

            _interactiveObject = new ListExecuteObject();
            // ������� ���� ������������ ������������� ��������

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.EndGameLabel);
            _viewVictoryGame = new ViewEndGame(_reference.VictoryLabel);


            _restartButton.onClick.AddListener(RestartGame);
            // ����������� Unity-���������

            _restartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);
            // ��������� ���� � InputController

            _interactiveObject.AddExecuteObject(_cameraController);

            // badBonus.OnCaughtPlayer += GameOver;
            // ����������� ����������� ������� => (��. �����)

            // ��������
            foreach (var item in _interactiveObject)
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddPoints += AddBonus;
                }

                if (item is BadBonus badBonus)
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

        // ����� �����������
        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewBonus.Display(_bonusCount);
        }

        /*
        // ���������� �������������� � BadBonus
        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color:" + color);
            _player.transform.position = new Vector3(22f, 1f, -20f);
        }
        */

        public void VictoryGame(string name)
        {
            Debug.Log("Victory!!!");
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
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

            if (_bonusCount == 5)
            {
                _viewVictoryGame.Victory(_bonusCount);
                //goodBonus.OnCaughtPlayer += VictoryGame;
                /* ??? ���������� �� ��������, ������� ����� ������ Restart �
                 ��������� �������� ������� ��������� �������� ����, ��� � �� ���������� */
                _restartButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
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

