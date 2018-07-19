import pandas as pd
import random

def load_dataset(filename):
    data=pd.read_csv(filename)
    numbers=data['number'].values
    return numbers


def simulaet_1(numbers):
    e=0
    a=0
    h=0
    g=0
    for index in range(100):
        if g in numbers:
            pass


def main():
    a=[1,2,3]
    print a[0:]
    print 'a[2:]',a[2:]
    print 'a[3:]',a[3:]
    print 'a[5:]',a[5:]
    print 'a[1:3]',a[1:3]    
    print 'a[2:1]',a[2:1]
    print 'a[2:3]',a[2:3]
    print 'a[2:3]',a[3:1]
    print 'a[2:3]',a[-1:1]
    
    
#    numbers=load_dataset('marksix.csv')
#    for index in range(1000):
#        start=random.randint(0,len(numbers))
#        print numbers[start:start+100]

if __name__ == '__main__':
    main()