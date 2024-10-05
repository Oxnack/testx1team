using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    private int[,] _peoples = new int[3, 3];
    public int[,] myArray = new int[3,3];

    [SerializeField] private float interval = 1.0f; // Интервал времени между сообщениями
    private float timer = 0.0f;

    private void Start()
    {
        // Создаем двумерный массив
        myArray = new int[rows, columns];
        _peoples = new int[rows, columns];


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                myArray[i, j] = 0;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                _peoples[i, j] = 0;
            }
        }

        myArray[25, 28] = 1;
        myArray[26, 28] = 1;
        myArray[26, 27] = 1;
        myArray[27, 27] = 1;
        myArray[27, 26] = 1;
        myArray[27, 25] = 1;
        myArray[28, 25] = 1;
     

        for (int i = 0; i < rows; i++)
        {
            string row = "";
            for (int j = 0; j < columns; j++)
            {
                row += myArray[i, j] + " ";
            }
            Debug.Log(row);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int neighbours = 0;

                    try
                    {
                        int value = myArray[i - 1, j + 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i, j + 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i + 1, j + 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i + 1, j]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i + 1, j - 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i, j - 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i - 1, j - 1]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    try
                    {
                        int value = myArray[i - 1, j]; // Попытка доступа к элементу массива
                        neighbours += value;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log("Ошибка: Индекс выходит за пределы массива. " + e.Message);
                    }

                    _peoples[i, j] = neighbours;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (_peoples[i, j] == 3)
                    {
                        myArray[i, j] = 1;
                    }
                    else if (_peoples[i, j] < 2 || _peoples[i, j] > 3)
                    {
                        myArray[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _peoples[i, j] = 0;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < columns; j++)
                {
                    row += myArray[i, j] + " ";
                }
                Debug.Log(row);
            }

            timer = 0.0f;
        }
    }

    // Life API

    public void SetLife(int i, int j, int state)
    {
        myArray[i, j] = state;
    }

    public void Restart()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                myArray[i, j] = 0;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                _peoples[i, j] = 0;
            }
        }

        myArray[25, 28] = 1;
        myArray[26, 28] = 1;
        myArray[26, 27] = 1;
        myArray[27, 27] = 1;
        myArray[27, 26] = 1;
        myArray[27, 25] = 1;
        myArray[28, 25] = 1;
    }

}


