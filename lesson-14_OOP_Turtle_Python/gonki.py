from turtle import *
from random import randint # import random number as integer's number
from time import *

finish = 200

screen = Screen()

t1 = Turtle()       # create a obejct "turtle N1" from class "Turtle"
t1.shape("turtle")  # create form object on turtle
t1.color("red")
t1.penup()          # поднимаем черепаху чтобы не рисовала
t1.goto(-200, 20)   # переместить по координатам
t1.pendown()        # опустить черепаху, чтобы потом рисовала.

t2 = Turtle()       # create a obejct "turtle N1" from class "Turtle"
t2.shape("turtle")  # create form object on turtle
t2.color("blue")
t2.penup()          # поднимаем черепаху чтобы не рисовала
t2.goto(-200, -20)   # переместить по координатам
t2.pendown()        # опустить черепаху, чтобы потом рисовала.

def razmetka():     # ф-ция рисует разметку на поле в виде точек.
    t = Turtle()
    t.speed(0)
    for i in range(21): # i = 0; i < 21; i++ (C#)
        t.penup()
        t.goto(-200 + i * 20, 50)
        t.pendown()
        t.goto(-200 + i * 20, -100)
    t.hideturtle()

razmetka()

def catch1(x, y): # even handler (обработчик события)
    t1.write('Ouch!', font=('Arial', 14, 'normal')) # func write to screen, when подгоняешь
    t1.fd(randint(10, 15)) # turtle made a random step from 10 to 15.


def catch2(x, y): # even handler (обработчик события)
    t2.write('Ouch22!', font=('Arial', 14, 'normal')) # func write to screen, when подгоняешь
    t2.fd(randint(10, 15)) # turtle made a random step from 10 to 15.

t1.onclick(catch1)
t2.onclick(catch2)


while t1.xcor() < finish and t2.xcor() < finish:
    t1.forward(randint(2, 7))
    t2.forward(randint(2, 7))
    sleep(0.1)


screen.exitonclick()