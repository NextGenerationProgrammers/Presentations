package de.mleusch.unittestsample;

public class Calculator {

    public String add(String num1, String num2) {
        return String.valueOf(Integer.parseInt(num1) + Integer.parseInt(num2));
    }

    public int add(int num1, int num2) {
        return  num1 + num2;
    }

    public double divide(double num1, double num2) {
        if (num2 == 0) { //Should return 0 if divisor is 0
            return 0;
        }
        return num1/num2;
    }

    public double multiply(double num1, double num2) {
        return num1 * num2;
    }
}
