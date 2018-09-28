

class Euclidean:

    @staticmethod
    def EuclideanAlgorythm(e, PhiN, Qs=[]):
        residue = e % PhiN
        Qs.append(int(e / PhiN))
        if residue == 0:
            return PhiN
        return Euclidean.EuclideanAlgorythm(PhiN, residue, Qs)

    @staticmethod
    def extendedEuclideanAlgorythm(e, PhiN):
        Qs = []
        ggT = Euclidean.EuclideanAlgorythm(e, PhiN, Qs)
        return Euclidean.extendedEuclideanAlgorythmInternal(0, ggT, Qs[:-1])

    @staticmethod
    def extendedEuclideanAlgorythmInternal(x, y, Qs):
        newX = y
        newY = x - (Qs[-1] * newX)
        if len(Qs) == 1:
            return {"x": newX, "y": newY}
        return Euclidean.extendedEuclideanAlgorythmInternal(newX, newY, Qs[:-1])
