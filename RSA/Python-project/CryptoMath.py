import math
import random


class CryptoMath:

    @staticmethod
    def isPrime(num: int) -> bool:
        if num <= 1:
            return False
        if num <= 3:
            return True

        startVal = int(round(math.sqrt(num) + 1))
        for i in range(2, startVal):
            if num % i == 0:
                return False
        return True

    @staticmethod
    def randPrime():
        val = random.getrandbits(12)
        if (val % 2 == 0) and (val != 2):
            val += 1
        while not CryptoMath.isPrime(val):
            val += 2
        return val
