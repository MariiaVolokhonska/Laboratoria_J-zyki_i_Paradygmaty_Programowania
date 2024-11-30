import pandas as pd
operation=input("Jaku operacju chcesz dokonać: dodawanie, możenie czy transponowanie macieży? ")
def dodawanie(matrix1, matrix2):
    code = "print([[matrix1[i][j]+matrix2[i][j] for j in range(2)]for i in range(2)])"
    exec(code)

dodawanie([[1,2],[3,4]],[[5,6],[7,8]])

def mnozenie(matrix1,matrix2):
    m3=[]
    for i in range(2):
        for j in range(2):
            m3[i][j]+=matrix1[i][j]*matrix2[j][i]

def transponowanie(matrix):
    print("lalal")