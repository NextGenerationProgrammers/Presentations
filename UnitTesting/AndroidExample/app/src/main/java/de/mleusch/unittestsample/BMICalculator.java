package de.mleusch.unittestsample;

public class BMICalculator {
    String getRecommendation(float size, float weigt) {
        if (size > 240 || size < 100 || weigt > 300 || weigt < 30) {
            return "Invalid values";
        }
        Calculator c = new Calculator();
        double bmi = c.divide(c.multiply(weigt, 10000), c.multiply(size, size));
        String recommendation = "";
        if (bmi < 20) {
            recommendation = "Eat more!";
        } else if (bmi > 25) {
            recommendation = "Too fat!";
        } else {
            recommendation = "OK";
        }
        return recommendation;
    }
}
