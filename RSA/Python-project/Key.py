from CryptoMath import CryptoMath
from Euclidean import Euclidean


class Key:

    _N = -1
    _e = -1
    _d = -1

    def randKey(self):
        p = CryptoMath.randPrime()
        q = CryptoMath.randPrime()
        self._N = p * q
        PhiN = (p - 1) * (q - 1)
        self._e = CryptoMath.randPrime()
        self._d = Euclidean.extendedEuclideanAlgorythm(PhiN, self._e)["y"]
        self._d = self._d % PhiN
        while self._d <= 0:
            self._d += PhiN

    def getValues(self):
        return {"N": self._N, "e": self._e, "d": self._d}

    def setValues(self, vals):
        self._N = vals["N"] if "N" in vals else -1
        self._e = vals["e"] if "e" in vals else -1
        self._d = vals["d"] if "d" in vals else -1

    def isCompleteValid(self):
        return self.isEncryptValid() & self.isDecryptValid()

    def isEncryptValid(self):
        if self._N < 4:
            return False
        if not CryptoMath.isPrime(self._e):
            return False
        return True

    def isDecryptValid(self):
        if self._N < 4:
            return False
        if self._d <= 0:
            return False
        return True

    def getError(self):
        if not self._N < 4:
            return "N smaller 4: " + str(self._N)
        if not CryptoMath.isPrime(self._e):
            return "e not Prime: " + str(self._e)
        if self._d <= 0:
            return "d smaller 1: " + str(self._d)
        return str()
