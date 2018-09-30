import unittest
from main import *


class ExampleTest(unittest.TestCase):

	def testAddition(self):
		self.assertEqual(adding(2,3), 5)
		
	def testSubtraction(self):
		self.assertEqual(subtraction(2,3), -1)
		
	def testIsPrime(self):
		self.assertTrue(isPrime(5))
		
	def testIsNotPrime(self):
		self.assertTrue(isPrime(6))
		
if __name__ == "__main__":
	unittest.main()