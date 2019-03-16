package de.mleusch.unittestsample;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.Spy;
import org.mockito.runners.MockitoJUnitRunner;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class BMICalculatorTest {

    BMICalculator bmiCalc;

    Calculator calc;



    @Before
    public void before() {
        bmiCalc = new BMICalculator();
        calc = mock(Calculator.class);
    }

    @Test
    public void getRecommendation_ok() {
        int size = 177;
        int weight = 65;


        when(calc.multiply(weight, 10000)).thenReturn(weight*10000.0);
        when(calc.multiply(size, size)).thenReturn((double) (size*size));
        when(calc.divide(weight*10000.0, size*size)).thenReturn(weight*10000.0/size*size);


        String result = bmiCalc.getRecommendation(size, weight);
        Assert.assertEquals("OK", result);
    }

    @Test
    public void getRecommendation_invalid() {
        String result = bmiCalc.getRecommendation(12, 65);
        Assert.assertEquals("Invalid values", result);
    }

    @Test
    public void getRecommendation_toofat() {
        String result = bmiCalc.getRecommendation(140, 65);
        Assert.assertEquals("Too fat!", result);
    }

    @Test
    public void getRecommendation_toothin() {
        String result = bmiCalc.getRecommendation(177, 35);
        Assert.assertEquals("Eat more!", result);
    }
}