using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private View _player;
        [SerializeField] private View _trigger;

        private Controller _controller;

        void Awake()
        {
            _controller = new Controller(_player, _trigger);
        }

        void Update()
        {
            _controller.MyUpdate();
        }
    }
}


