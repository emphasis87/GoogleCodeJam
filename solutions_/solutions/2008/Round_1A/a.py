from sys import stdin
from sys import stderr

def getInts():
    return tuple(int(z) for z in stdin.readline().split())

T = getInts().pop()

