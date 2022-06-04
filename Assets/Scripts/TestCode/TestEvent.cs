using UnityEngine.Events;
using UnityEngine;

namespace GeekBrains
{
    delegate void UI();

    class MyEvent
    {
        public event UI UserEvent;

        public void OnUserEvent()
        {
            UserEvent();
        }
    }

    public class TestEvent : MonoBehaviour
    {
        string UILogin;
        string UIAge;

        public UnityEvent TestUnityIvent;

        private void OnEnable()
        {
            if(TestUnityIvent == null)
            {
                TestUnityIvent= new UnityEvent();
            }

            TestUnityIvent.AddListener(UserInfoHandler);
        }

        private void OnDisable()
        {
            if (TestUnityIvent == null)
            {
                TestUnityIvent = new UnityEvent();
            }

            TestUnityIvent.RemoveListener(UserInfoHandler);
        }

        public void UserInfoHandler()
        {
            Debug.Log("Произошло событие: " + UILogin + " " + UIAge);
        }

        void Start()
        {
            MyEvent tempEvent = new MyEvent();

            UILogin = "User";
            UIAge = "19";

            tempEvent.UserEvent += UserInfoHandler;
            tempEvent.OnUserEvent();
            // первый вызов тестового события

            TestUnityIvent.Invoke();
            // второй вызов тестового события
        }
    }
}


