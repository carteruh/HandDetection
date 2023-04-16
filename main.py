import cv2
import mediapipe as mp
import time
import csv
import socket
import pyautogui

cap = cv2.VideoCapture(0)

# TCP_IP = '127.0.0.1'
# TCP_PORT = 135

# Create a TCP socket
# s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
# s.connect((TCP_IP, TCP_PORT))
mpHands = mp.solutions.hands
hands = mpHands.Hands(static_image_mode=False,
                      max_num_hands=4,
                      min_detection_confidence=0.5,
                      min_tracking_confidence=0.5)
mpDraw = mp.solutions.drawing_utils

pTime = 0
cTime = 0

while True:
    success, img = cap.read()
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    results = hands.process(imgRGB)
    #print(results.multi_hand_landmarks)

    if results.multi_hand_landmarks:
        for idx, handLms in enumerate(results.multi_hand_landmarks):
            for id, lm in enumerate(handLms.landmark):
                #print(id,lm)
                if (id == 8):
                    h, w, c = img.shape
                    cx, cy = int(lm.x *w), int(lm.y*h)
                    print(cx, cy)
                    if (lm.x > 0.65):
                        pyautogui.keyDown("left")
                        pyautogui.keyUp("right")
                    elif (lm.x < .65 and lm.x > .35):
                        pyautogui.keyUp("left")
                        pyautogui.keyUp("right")
                    else:
                        pyautogui.keyUp("left")
                        pyautogui.keyDown("right")
                    # if (idx % 5 == 0):
                    #     with open("C:/CV_Development/Pose_estimation_Hand/yolov5/lm_hand.txt", "w", newline= '') as f:
                    #         cx_text, cy_text = str(cx), str(cy)
                    #         f.write(cx_text  + ',' + cy_text)
                    cx_text, cy_text = str(cx), str(cy)
                    message = cx_text + "_" + cy_text
                    # s.sendall(message.encode("utf-8"))
                    # response = s.recv(1024).decode("utf-8")
                    # print(response)
                    #if id ==0:
                    cv2.circle(img, (cx,cy), 3, (255,0,255), cv2.FILLED)


            mpDraw.draw_landmarks(img, handLms, mpHands.HAND_CONNECTIONS)


    cTime = time.time()
    fps = 1/(cTime-pTime)
    pTime = cTime

    cv2.putText(img,str(int(fps)), (10,70), cv2.FONT_HERSHEY_PLAIN, 3, (255,0,255), 3)

    cv2.imshow("Image", img)
    if cv2.waitKey(1) == ord('q'):
        break
# Release the video capture device and close all windows
cap.release()
cv2.destroyAllWindows()
# s.close()