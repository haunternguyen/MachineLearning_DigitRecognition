# coding: utf-8

from tkinter import *
from tkinter import filedialog
from tkinter import messagebox
import numpy as np
import cv2
import imutils
from cnn.neural_network import CNN
from keras.optimizers import SGD

global DuongVao
global DuongRa

InPath = ""
OutPath = ""

# Thuat toan tim
# loading our ANN model
print('\n Compiling model...')
sgd = SGD(lr=0.01, decay=1e-6, momentum=0.9, nesterov=True)
clf = CNN.build(width=28, height=28, depth=1, total_classes=10,
                Saved_Weights_Path="cnn_weights.hdf5")
clf.compile(loss="categorical_crossentropy",
            optimizer=sgd, metrics=["accuracy"])


def greet(DuongVao, DuongRa):
    # reading image
    img = cv2.imread(DuongVao)
    # resizing image
    img = imutils.resize(img, width=300)
    # showing original image
    # cv2.imshow("Original",img)
    # converting image to grayscale
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    # showing grayscale image
    # cv2.imshow("Gray Image",gray)

    # creating a kernel
    kernel = np.ones((40, 40), np.uint8)

    # applying blackhat thresholding
    blackhat = cv2.morphologyEx(gray, cv2.MORPH_BLACKHAT, kernel)

    # applying OTSU's thresholding
    ret, thresh = cv2.threshold(
        blackhat, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)

    # performing erosion and dilation
    opening = cv2.morphologyEx(thresh, cv2.MORPH_OPEN, kernel)

    # finding countours in image
    ret, cnts, hie = cv2.findContours(
        thresh.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

    for c in cnts:
        try:
            # creating a mask
            mask = np.zeros(gray.shape, dtype="uint8")

            (x, y, w, h) = cv2.boundingRect(c)

            hull = cv2.convexHull(c)
            cv2.drawContours(mask, [hull], -1, 255, -1)
            mask = cv2.bitwise_and(thresh, thresh, mask=mask)

            # Getting Region of interest
            roi = mask[y - 7:y + h + 7, x - 7:x + w + 7]
            roi = cv2.resize(roi, (28, 28))
            roi = np.array(roi)
            # reshaping roi to feed image to our model
            roi = roi.reshape((-1, 1, 28, 28))

            # predicting
            probs = clf.predict(roi)
            prediction = probs.argmax(axis=1)
            print('Predicted Label: {}'.format(prediction[0]))

            # prediction = model.predict(roi)

            cv2.rectangle(img, (x, y), (x + w, y + h), (0, 255, 0), 1)
            cv2.putText(img, str(
                int(prediction[0])), (x, y), cv2.FONT_HERSHEY_SIMPLEX, 0.8, (255, 0, 0), 1)

        except Exception as e:
            print(e)

    img = imutils.resize(img, width=500)

    # showing the output
    cv2.imshow('Detection', img)
    cv2.imwrite(DuongRa, img)
    print('Nhan dang xong')

# Ket thuc thuat toan


# Tạo form main add title
frmMain = Tk()
frmMain.title("Nhận dạng số viết tay")
frmMain.iconbitmap(default='digit.ico')
# Bắt đầu canh giữa màn hình
# This code helps to disable windows from resizing
frmMain.resizable(False, False)

window_height = 100
window_width = 500

screen_width = frmMain.winfo_screenwidth()
screen_height = frmMain.winfo_screenheight()

x_cordinate = int((screen_width / 2) - (window_width / 2))
y_cordinate = int((screen_height / 2) - (window_height / 2))

frmMain.geometry("{}x{}+{}+{}".format(window_width,
                                      window_height, x_cordinate, y_cordinate))
# Kết thúc canh giữa màn hình

ChuGoiY = ['Chọn đường dẫn cần nhận dạng', 'Chọn nơi xuất ra', ]
DuongVao = StringVar()
DuongRa = StringVar()

# Su kien click


def buttonVaoClick():
    try:
        abc = filedialog.askopenfilename(
            initialdir="E:/Study_IT/HC/Machine Learning/sources/174022/HinhAnh", title="Select file", filetypes=(("jpeg files", "*.jpg"), ("all files", "*.*")))
        # print(abc)
        DuongVao.set(abc)
        global InPath
        InPath = abc
    except Exception as e:
        print(e)
        messagebox.showinfo("Thong Bao", "Loi he thong!")


def buttonRaClick():
    try:
        abc = filedialog.asksaveasfilename(
            initialdir="/", title="Select file", filetypes=(("jpeg files", "*.jpg"), ("all files", "*.*")))
        DuongRa.set(abc)
        global OutPath
        OutPath = abc + '.jpg'
    except Exception as e:
        print(e)
        messagebox.showinfo("Thong Bao", "Loi he thong!")


def buttonOKClick():
    try:
        print('Duong dan')
        print(InPath)
        print(OutPath)
        print('==================')
        greet(InPath, OutPath)
        messagebox.showinfo("Thong Bao", "Luu thanh cong!")

    except Exception as e:
        print(e)


def buttonEXITClick():
    try:
        frmMain.destroy()
    except Exception as e:
        print(e)


# Chia cột và dòng 3 dòng, 3 cột
# Add control lần lượt là Label, Text , Button
Label(text=ChuGoiY[0], relief=RIDGE, width=30).grid(row=0, column=0)
txtChonDuongDan = Entry(frmMain, textvariable=DuongVao,
                        width=40).grid(row=0, column=1)
button = Button(frmMain, text="...", fg="red",
                command=buttonVaoClick).grid(row=0, column=2)

Label(text=ChuGoiY[1], relief=RIDGE, width=30).grid(row=1, column=0)
txtChonNoiXuatHinhAnh = Entry(
    frmMain, textvariable=DuongRa, width=40).grid(row=1, column=1)
button = Button(frmMain, text="...", fg="green",
                command=buttonRaClick).grid(row=1, column=2)
button = Button(frmMain, text="OK", fg="green",
                command=buttonOKClick).grid(row=2, column=0)
button = Button(frmMain, text="EXIT", fg="red",
                command=buttonEXITClick).grid(row=2, column=1)
# Vòng lặp hiển thị form Main
frmMain.mainloop()
