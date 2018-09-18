#coding=utf-8
#import jieba
def ReadData(stdFile, derivFile):
    cont1 = ''
    cont2 = ''
    with open(stdFile, 'r') as fo1:
        cont1 = fo1.read()
    with open(derivFile, 'r') as fo2:
        cont2 = fo2.read()
    cont1 = cont1.replace(' ', '')
    cont2 = cont2.replace(' ', '')
    cont1 = cont1.replace('\t', '')
    cont2 = cont2.replace('\t', '')
    #cont1 = cont1.replace('\n', '')
    #cont2 = cont2.replace('\n', '')
    #stdList = jieba.cut(cont1, cut_all=False)
    #derivList = jieba.cut(cont2, cut_all=False)
    #print(list(derivList))
    return (list(cont1), list(cont2))

def AddFailMark(failWord):
    if failWord != '\n' and failWord != '\t' and failWord != ' ':
        #failWord = '<F>%s</F>' % failWord
        failWord = '\033[32m%s\033[0m' % failWord
    return failWord

''' stdList: Standard Datalist, read from eDoc, assumed no mistakes.
derivList: derived Datalist, read from pdf, might have multiple mistakes.
diffWindow: The cache size of derivedData. 
minMatchChain: Describe how many continuously matches we should get before we accept a match.'''
def Compare(stdList, derivList, diffWindow, minMatchChain):
    derivPtr = 0
    newStdList = []
    newDerivList = []
    skipWords = 0
    for swi in range(0, len(stdList)):
        if derivPtr + 1 > len(derivList):
            break
        stdWord = stdList[swi]
        succMatch = True
        if skipWords > 0:
            skipWords -= 1
            newStdList.append(stdWord)
            continue
        if succMatch == True and stdWord == derivList[derivPtr]: #match successful
            newDerivList.append(derivList[derivPtr])
            newStdList.append(stdWord)
            derivPtr += 1
        else:
            succMatch = False
            matchChain = 0
            for i in range(derivPtr, diffWindow + derivPtr):
                if swi + matchChain >= len(stdList) or i >= len(derivList) or stdList[swi + matchChain] == derivList[i]:
                    matchChain += 1
                    if matchChain >= minMatchChain:
                        #push all successful matches into resList
                        for failWord in derivList[derivPtr:i-matchChain+1]:
                            newDerivList.append(AddFailMark(failWord))
                        for succWord in derivList[i-matchChain+1:i+1]:
                            newDerivList.append(succWord)
                        derivPtr = i + 1
                        succMatch = True
                        newStdList.append(stdWord)
                        skipWords = matchChain - 1
                        break
                else:
                    matchChain = 0
            if succMatch == False:
                newStdList.append(AddFailMark(stdWord))
    print(''.join(newStdList))
    print('\n')
    print(''.join(newDerivList))

data = ReadData('./diffTest/2-电子版对照.txt', './diffTest/2-打印出纸质版.ocr.txt')
Compare(data[0], data[1], 120, 10)
#Compare(list('Hi, This is Jack, Nice to meet you.'), list('H, This iqqqqqqs Jack, Nice to meet you.'), 15, 3)