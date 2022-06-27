using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Controller
    {
        /* ��������� ������ ������ (����������� �������������� ������
        � ��������� - ��������� ������ � ������ ������ � ���������) */

        private Transform _playerT;
        private View _triggerT;
        private View _playerView;

        /* � ������������ �������������� ������)*/
        public Controller(View player, View trigger)
        {
            _playerView = player;
            _playerT = player._transform; // ������ �� transform �� View
            _triggerT = trigger; // ������ �� trigger �� Main 

            // ������������� �� ������� ����� ���������� ControllerRecieveAction
            // ��� ������������� ������� OnLevelObjectContact �� View, �������
            // ����������� � ��������, ����� � ���� �������� ����� 
            _triggerT.OnLevelObjectContact += ControllerRecieveAction;
        }

        // ���������� ��� �������, ����� ����� �� ��������� ��� � Action 
        private void ControllerRecieveAction(Collider contactView, int Val, Transform valT)
        {
            Debug.Log("���������� �������: ��� ������� � �������� " + contactView.gameObject.name);

            // ���������� ������ ����� Destroy (����� ������ gameObject)
            GameObject.Destroy(contactView.gameObject);
        }

        // ����� ������� (������ ������, �� MonoBehaviour)
        public void MyUpdate()
        {
            
        }
    }
}


/*
������ �������� �� ��������� �������, �������� �� ������� (��� �������� �������, ����� 
���������� ����� ������������ ����� ��������������).
�������� �����������, �� ����������� �� MonoBehaviour, ����� ��� �� ����, ���������������� 
� ������� Main.
 */