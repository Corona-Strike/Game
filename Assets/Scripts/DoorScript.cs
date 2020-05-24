using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //  Состояние двери  - открывается, неподв, 
    enum State {GoingUp, Opened, GoingDown, Closed};


    [SerializeField] private float delayTime = 4.0f;
    private float closeTime = -0.1f;
    private float diffY = 0.03f;
    private int steps = 0;

    private State currentState = State.Closed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //   Движение вверх!
        if (currentState == State.GoingUp)
        {
            if (steps < 100)
            {
                transform.position = transform.position + Vector3.up * diffY;
                steps++;
            }
            else
                currentState = State.Opened;
        }
        else if (currentState == State.GoingDown)
        {
            if (Time.realtimeSinceStartup < closeTime)
                return;

            if (steps > 0)
            {
                transform.position = transform.position - Vector3.up * diffY;
                steps--;
            }
            else
                currentState = State.Closed;
        }

    }

    public void Open()
    {
        if (currentState == State.Closed || currentState == State.GoingDown)
            currentState = State.GoingUp;

        //  Начинает открывание двери при срабатывании триггера
        //  transform.position = transform.position + Vector3.up * diffY;
    }

    public void Close()
    {
        //  Установить время срабатывания closeTime - текущее + delay
        closeTime = Time.realtimeSinceStartup + delayTime;
        if (currentState == State.Opened || currentState == State.GoingUp)
            currentState = State.GoingDown;
    }
}
