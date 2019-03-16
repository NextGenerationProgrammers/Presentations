package de.mleusch.unittestsample;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;

public class CalculatorTest {
    Calculator c;

    @Before
    public void before() {
        c = new Calculator();
    }

    //Fails, bcoz Strings will not be added, they will be concatenated
    @Test
    public void add_numbers_shouldPass() {
        String result = c.add("1", "2");
        Assert.assertEquals("3", result);
    }

    //Passes, bcoz a and b are numbers. They can not be converted to strings
    //This points to a bad method
    @Test(expected = NumberFormatException.class)
    public void add_letters_shouldFail() {
        String result = c.add("a", "b");
    }

    @Test
    public void addInt_numbers_shouldPass() {
        int result = c.add(1, 2);
        Assert.assertEquals(3, result);
    }

    @Test
    public void divideByZero() {
        double result = c.divide(3,0);
        Assert.assertEquals(0, result, 1);
    }

    //Check that the method doesn't operate with ints internally
    @Test
    public void divideReturnsDouble() {
        double result = c.divide(1,2);
        Assert.assertEquals(0.50, result, 1);
        Assert.assertNotEquals(0, result);
    }

    @Test
    public void testMultiply() {
        double result = c.multiply(3,2);
        Assert.assertEquals(6, result, 1);
        Assert.assertNotEquals(0, result);
    }
}