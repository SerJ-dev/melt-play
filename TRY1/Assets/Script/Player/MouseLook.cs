using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //настройка сеансы 
    private Camera _camera;
    public float SenX = 5, SensY = 10;
    //на сколько поворачивать камеру по X и по Y
    float moveY, moveX;
    //флаги движения по осям 
    public bool RootX = true, //разрешаем или запрещаем перемещение по оси X 
    RootY = true; //разрешаем или запрещаем перемещение по оси X
    public bool TestY = true,  //включаем ограничение поворота камеры вдоль оси Y
    TestX = false; //включение ограничения поворота камеры вдоль оси X
    public Vector2 MinMax_Y = new Vector2(-40, 40),    //ограничение по оси Y
    MinMax_X = new Vector2(-360, 360);  //ограничение по оси X
    CharacterController MyPawnBody; //контроллер игрока для вращения камерой
    // Start is called before the first frame update
    //функция расчета угла поворота
    static float ClampAngle(float angle, float min, float max)
    {
        //если угол прошел расстояние от 0 до -360 то обнуляем его 
        if (angle < -360F) angle += 360F;
        //если угол прошел расстояние от 0 до 360 то обнуляем его 
        if (angle > 360F) angle -= 360F;
        //рассчитываем среднее значение поворота относительно угла 
        return Mathf.Clamp(angle, min, max);
    }
    void Start()
    {
        _camera = GetComponent<Camera>();
        MyPawnBody = GetComponent<CharacterController>();
    }
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }


    // Update is called once per frame
    void Update()
    {
        //получаем угол на который мышь улетела от центра экрана по Y
        if (RootY) moveY -= Input.GetAxis("Mouse Y") * SensY;
        //ограничиваем угол поворота камеры чтобы она не вращалась под ноги 
        if (TestY) moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
        //получаем угол на который мышь улетела от центра экрана по Х
        if (RootX) moveX += Input.GetAxis("Mouse X") * SenX;
        //ограничиваем угол поворота камеры чтобы она не вращалась по оси X
        if (TestX) moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y);
        //поворачиваем тело персонажа по осям 
        MyPawnBody.transform.rotation = Quaternion.Euler(moveY, moveX, 0);  
    }
}
