def adding(a, b):
	return a + b

def subtraction(a, b):
	return a-b
	
def isPrime(number):
	isAPrimeNum = False
	for num in range(1, number, -1):
		if number % num== 0:
			return True
	
	return True
	