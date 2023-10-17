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
### OR | дать комментарии о корректности работы
### AND | дать комментарии о корректности работы
### NAND | дать комментарии о корректности работы
### XOR | дать комментарии о корректности работы

Ход работы:
- Я проанализировала в проекте Unity варианты возможного усложнения переменных и решила увеличивать (или уменьшать) все переменные одновременно. Я нашла максимально усложненный и играбельный(для меня) вариант и, отталкиваясь от него, подобрала значения для 2-9 уровней.

![image](https://github.com/knightalli/DAinGD-lab3/assets/127225486/5a54c2f1-2551-4523-8409-c594f13b1f40)

## Задание 2
###  Построить графики зависимости количества эпох от ошибки  обучения. Указать от чего зависит необходимое количество эпох обучения.
Ход работы:
- Я продублировала сцену и поменяла переменные "Speed", "TimeBetweenEgg", "LeftRightDistance", "ChanceDirection".

![image](https://github.com/knightalli/DAinGD-lab3/assets/127225486/730f9bbd-b682-4234-9e13-abc6d9ae7e18)


## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.
Ход работы:
- Я создала новую таблицу, подключила API и вставила данные, которые получила в первом задании. Также я добавила рандомное число для того, чтобы каждую загрузку слегка отличались значения переменных, но не так сильно, чтобы это слишком влияло на игру.

```py
import gspread
import numpy as np
gc = gspread.service_account(filename='work4-402209-5356a8a03952.json')
sh = gc.open("UnityWorkShop 3")
speed = 4.00
timeEgg = 2.00
lrDist = 10.00
chanceDir = 0.01
i = 0
end = 8
while i <= end:   
    tempRand = np.random.randint(-100, 100, 3)    
    i += 1
    if i == 0:
        continue
    else:        
        sh.sheet1.update(('A' + str(i+2)), speed+2.3*i+(tempRand[0]/1000))
        sh.sheet1.update(('B' + str(i+2)), timeEgg-0.15*i+(tempRand[1]/1000))
        sh.sheet1.update(('C' + str(i+2)), lrDist+0.5*i+(tempRand[2]/1000))
        sh.sheet1.update(('D' + str(i+2)), chanceDir+0.0005*i)
        sh.sheet1.update(('E' + str(i+1)), i)
        print('ok')
```

![image](https://github.com/knightalli/DAinGD-lab3/assets/127225486/6b4ddf02-7a79-489e-8555-17826b373248)


## Выводы

Я создала 10 сцен в игре Dragon Picker, проанализировала входные данные. Попробовала разные изменения переменных и создала уровни с разными сложностями. Ещё раз заполнила таблицу с помощью Python. 


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
