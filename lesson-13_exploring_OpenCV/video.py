# work with web-camera

# from sre_constants import SUCCESS # while this don't need. (!)

from turtle import Screen
import cv2

## # find face for photo
## faces_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")
## img = cv2.imread('face.jpg') # read photo
## img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
## 
## faces = faces_cascades.detectMultiScale(img_gray)
## # print(faces) # coordinates: left top point and right low point square
## 
## for (x, y, w, h) in faces:
##     cv2.rectangle(img, (x, y), (x + w, y + h), (0, 0, 255), 2)
## 
## while True:
##     cv2.imshow('Result', img)
##     if cv2.waitKey(0) & 0xff == ord("q"):
##         break

## # Capture web-camera
## cap = cv2.VideoCapture(0) # подключение камеры
## # cap = cv2.VideoCapture('video.mp4') # подключение видеофайла
## 
## while True:
##     success, frame = cap.read()
##     # _, frame = cap.read() # in Python maybe do it "_,"
##     cv2.imshow("camera", frame) # output to the screen
##     # or
##     # cv2.imshow("camera", frame) 
## 
##     if cv2.waitKey(1) & 0xff == ord("q"): # update a frame of the video in 1ms.
##         break

# find face in videocamera
faces_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")
cap = cv2.VideoCapture(0) # подключение камеры

while True:
    success, frame = cap.read()
    img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = faces_cascades.detectMultiScale(img_gray)
    for (x, y, w, h) in faces:
        cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 0, 255), 2)
    cv2.imshow("Result", frame)
    if cv2.waitKey(1) & 0xff == ord("q"): # update a frame of the video in 1ms.
        break

## # version with stop-frame, preview.
## while True:
##     success, frame = cap.read()
##     img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
##     cv2.imshow("Preview", frame)
##     faces = faces_cascades.detectMultiScale(img_gray)
##     for (x, y, w, h) in faces:
##         cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 0, 255), 2)
##     cv2.imshow("Result", frame)
##     if cv2.waitKey(0) & 0xff == ord("q"): # update a frame of the video in 1ms.
##         break

## # Если в VSC закрывается окно с фото:
## screen = Screen() # in begin
## screen.exitonclick() # to end
