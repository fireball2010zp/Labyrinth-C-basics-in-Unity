using UnityEditor;
using UnityEngine;

public class Window : EditorWindow // реализует методы и дизайн редактора
    // а MonoBehaviour поведение на сцене
{
    public Color myColor;         // Градиент цвета
    public MeshRenderer GO;      // Ссылка на рендер объекта

    public Material newMat;
    private Transform MainCam;

    // конструктор для класса Window - вызов
    [MenuItem("Инструменты /Окна/ Генератор бонусов")] // кастомизация атрибутами
    public static void ShowMyWindow()
    {
        GetWindow(typeof(Window), false, "Генератор бонусов");
    }


    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Меш объекта", GO, typeof(MeshRenderer), true) as MeshRenderer;
        // EditorGUILayout - автоматическое позиционирование
        newMat = EditorGUILayout.ObjectField("Материал объекта", newMat, typeof(Material), true) as Material;

        if (GO)
        {
            myColor = RGBSlider(new Rect(10, 50, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
            GO.sharedMaterial.color = myColor; // Покраска объекта
            // sharedMaterial даёт ссылку на материал
        }
        else
        {
            if(GUI.Button(new Rect(10, 60, 100, 30), "Создать"))
            {
                MainCam = Camera.main.transform;

                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // после создания объекта создаём его меш
                MeshRenderer GORenderer = temp.GetComponent<MeshRenderer>();
                // далее назначаем материал, т.к. стандартный редактировать не можем
                GORenderer.sharedMaterial = newMat;
                // задаем позицию объекта (перед камерой -10f)
                temp.transform.position = new Vector3(MainCam.position.x, MainCam.position.y, MainCam.position.z-10f);
                GO = GORenderer;
            }
        }

        // раелизация возможности удалять объект прямо со сцены
        if(GUI.Button(new Rect(10, 160, 100, 30), "Удалить"))
        {
            DestroyImmediate(GO.gameObject);
            // после удаления объекта зануляем ссылку
            GO = null;
        }
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // ДЗ добавить MinValue
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    }
}

