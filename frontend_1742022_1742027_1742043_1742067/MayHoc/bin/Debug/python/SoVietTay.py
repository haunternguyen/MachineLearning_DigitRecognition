# coding: utf-8
import numpy as np
import cv2
import imutils
from cnn.neural_network import CNN
from keras.optimizers import SGD
import argparse

# Thuat toan tim
# loading our ANN model
# print('\n Compiling model...')
# print('Hello')
# Parse the Arguments
ap = argparse.ArgumentParser()
ap.add_argument("-v", "--DuongVao", type=str)
ap.add_argument("-r", "--DuongRa", type=str)
args = vars(ap.parse_args())


def greet(DuongVao, DuongRa):
    # khoi tao

    sgd = SGD(lr=0.01, decay=1e-6, momentum=0.9, nesterov=True)
    clf = CNN.build(width=28, height=28, depth=1, total_classes=10,
                    Saved_Weights_Path="cnn_weights.hdf5")
    clf.compile(loss="categorical_crossentropy",
                optimizer=sgd, metrics=["accuracy"])
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
    # cv2.imshow('Detection', img)
    cv2.imwrite(DuongRa, img)
    print('Nhan dang xong')
    print(args["DuongVao"])
    print('########')
    print(args["DuongRa"])


# Ket thuc thuat toan
greet(args["DuongVao"], args["DuongRa"])
