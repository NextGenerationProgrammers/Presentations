import sys
from Key import Key


class RSA:

    key = Key()

    def encrypt(self, crypt):
        return int(crypt ** self.key.getValues()["e"]) % self.key.getValues()["N"]

    def decrypt(self, crypt):
        return int(crypt ** self.key.getValues()["d"]) % self.key.getValues()["N"]


class App:
    @staticmethod
    def run(argv):
        cypher = RSA()
        action = argv[1][0].upper()
        if action == "K":
            cypher.key.randKey()
            keys = cypher.key.getValues()
            print(keys)
        elif action == "E":
            if len(sys.argv) != 5:
                print("invalid Arguments")
                return
            keyVal = {}
            keyVal["N"] = int(argv[3])
            keyVal["e"] = int(argv[4])
            cypher.key.setValues(keyVal)
            if not cypher.key.isEncryptValid():
                print(cypher.key.getError())
                return
            val = cypher.encrypt(int(argv[2]))
            print(val)
        elif action == "D":
            if len(sys.argv) != 5:
                print("invalid Arguments")
                return
            keyVal = {}
            keyVal["N"] = int(argv[3])
            keyVal["d"] = int(argv[4])
            cypher.key.setValues(keyVal)
            if not cypher.key.isDecryptValid():
                print(cypher.key.getError())
                return
            val = cypher.decrypt(int(argv[2]))
            print(val)
        else:
            print("No such function: " + argv[1])


if (__name__ == "__main__") & (sys.argv is not None) & (len(sys.argv) >= 2) & (len(sys.argv) <= 5):
    App.run(sys.argv)
