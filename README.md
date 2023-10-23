# DAinGD-lab4
# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #4 выполнил(а):
- Миронова Наталья Андреевна
- РИ220930
- 
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Цель работы
Изучение модели работы перцептрона посредством использования Unity.

## Задание 1
### в проекте Unity реализовать перцептрон, который умеет производить вычисления:
### OR | 0+0=0 0+1=1 1+0=1 1+1=1
### AND | 0+0=0 0+1=0 1+0=0 1+1=1
### NAND | 0+0=1 0+1=1 1+0=1 1+1=0
### XOR | 0+0=0 0+1=1 1+0=1 1+1=0

Ход работы:
- Создала проект Unity и добавила туда скрипт Perceptron, добавила его на пустой GameObject и просмотрела, как действует Console. 

![image](https://github.com/knightalli/DAinGD-lab4/assets/127225486/f3617045-cd57-42fc-a1a4-1edc2e7bb1ac)


```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
    public double[] input;
    public double output;
}

public class Perceptron : MonoBehaviour
{

    public TrainingSet[] ts;
    double[] weights = { 0, 0 };
    double bias = 0;
    double totalError = 0;

    double DotProductBias(double[] v1, double[] v2)
    {
        if (v1 == null || v2 == null)
            return -1;

        if (v1.Length != v2.Length)
            return -1;

        double d = 0;
        for (int x = 0; x < v1.Length; x++)
        {
            d += v1[x] * v2[x];
        }

        d += bias;

        return d;
    }

    double CalcOutput(int i)
    {
        double dp = DotProductBias(weights, ts[i].input);
        if (dp > 0) return (1);
        return (0);
    }

    void InitialiseWeights()
    {
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1.0f, 1.0f);
        }
        bias = Random.Range(-1.0f, 1.0f);
    }

    void UpdateWeights(int j)
    {
        double error = ts[j].output - CalcOutput(j);
        totalError += Mathf.Abs((float)error);
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = weights[i] + error * ts[j].input[i];
        }
        bias += error;
    }

    double CalcOutput(double i1, double i2)
    {
        double[] inp = new double[] { i1, i2 };
        double dp = DotProductBias(weights, inp);
        if (dp > 0) return (1);
        return (0);
    }

    void Train(int epochs)
    {
        InitialiseWeights();

        for (int e = 0; e < epochs; e++)
        {
            totalError = 0;
            for (int t = 0; t < ts.Length; t++)
            {
                UpdateWeights(t);
                Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
            }
            Debug.Log("TOTAL ERROR: " + totalError);
        }
    }

    void Start()
    {
        Train(8);
        Debug.Log("Test 0 0: " + CalcOutput(0, 0));
        Debug.Log("Test 0 1: " + CalcOutput(0, 1));
        Debug.Log("Test 1 0: " + CalcOutput(1, 0));
        Debug.Log("Test 1 1: " + CalcOutput(1, 1));
    }

    void Update()
    {

    }
}
```

## Задание 2
###  Построить графики зависимости количества эпох от ошибки  обучения. Указать от чего зависит необходимое количество эпох обучения.
Ход работы:
- Я проанализировала данные, полученные после запуска персептрона для каждой логики, и оформила их в таблицу.
- Для первых трех логик персептрон быстро обучается и к 7 эпохе уже перестает делать ошибки, а отличии от логики XOR, которая в ростом количества эпох совершает больше и больше ошибок.

![image](https://github.com/knightalli/DAinGD-lab4/assets/127225486/058b7773-5643-4160-950a-0e25dd2bead9)



## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.
Ход работы:
- 

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private int numberType;
    private Material material;
    [SerializeField] private int numberTrigger;
    [SerializeField] private Material[] materials;

    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) ORScene();
        if (SceneManager.GetActiveScene().buildIndex == 1) ANDScene();
        if (SceneManager.GetActiveScene().buildIndex == 2) NANDScene();
        if (SceneManager.GetActiveScene().buildIndex == 3) XORScene();
        Destroy(other.gameObject);
    }

    private void ORScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }
    }

    private void ANDScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }
    }

    private void NANDScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }
    }

    private void XORScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }
    }
}
```
![4ad](https://github.com/knightalli/DAinGD-lab4/assets/127225486/cbd4144b-6572-4bd3-9a9a-aa3a423d8aac)



## Выводы
Я научилась реализовывать персептрон на Unity3D. Также проанализировала эпохи и построила график. Также с помощью кубиков визуализировала действия логик OR, AND, NAND, XOR.



| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
