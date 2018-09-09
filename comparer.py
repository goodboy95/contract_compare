#coding=utf-8
import jieba
def ReadData(stdFile, derivFile):
    cont1 = ''
    cont2 = ''
    with open(stdFile, 'r') as fo1:
        cont1 = fo1.read()
    with open(derivFile, 'r') as fo2:
        cont2 = fo2.read()
    cont1 = cont1.replace(' ', '')
    cont2 = cont2.replace(' ', '')
    #stdList = jieba.cut(cont1, cut_all=False)
    #derivList = jieba.cut(cont2, cut_all=False)
    #print(list(derivList))
    return (list(cont1), list(cont2))

def AddFailMark(failWord):
    if failWord != '\n' and failWord != '\t' and failWord != ' ':
        failWord = '<F>%s</F>' % failWord
    return failWord

''' stdList: Standard Datalist, read from eDoc, assumed no mistakes.
derivList: derived Datalist, read from pdf, might have multiple mistakes.
diffWindow: The cache size of derivedData. 
minMatchChain: Describe how many continuously matches we should get before we accept a match.'''
def Compare(stdList, derivList, diffWindow, minMatchChain):
    derivListCache = []
    newStdList = []
    newDerivList = []
    for swi in range(0, len(stdList)):
        stdWord = stdList[swi]
        succMatch = False
        while len(derivList) > 0 and len(derivListCache) < diffWindow:
            derivListCache.append(derivList.pop(0))
        if stdWord == derivListCache[0]: #match successful
            newDerivList.append(derivListCache.pop(0))
            newStdList.append(stdWord)
        else:
            matchChain = 0
            for i in range(0, len(derivListCache)):
                if swi + matchChain >= len(stdList) or stdList[swi + matchChain] == derivListCache[i]:
                    matchChain += 1
                    if matchChain >= minMatchChain:
                        #push all successful matches into resList
                        for failWord in derivListCache[0:i-matchChain+1]:
                            newDerivList.append(AddFailMark(failWord))
                        for succWord in derivListCache[i-matchChain+1:i+1]:
                            newDerivList.append(succWord)
                        derivListCache = derivListCache[i+1:]
                        succMatch = True
                        break
                else:
                    matchChain = 0
            if succMatch:
                newStdList.append(stdWord)
            else:
                newStdList.append(AddFailMark(stdWord))
    #print(newStdList)
    print(newDerivList)

data = ReadData('./diffTest/wordFile.txt', './diffTest/ocrFile.txt')
Compare(data[0], data[1], 400, 20)