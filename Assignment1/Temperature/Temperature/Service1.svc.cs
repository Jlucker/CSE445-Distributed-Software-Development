//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 1 part 1
// Description: A service that converts Celsius to Farenheit and Farenheit to Celsius
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Temperature
{
    public class Service1 : IService1
    {
        // the c2f method takes the celsius value as input and returns
        // the converted farenheit value
        public int c2f(int c)
        {
            var f = c * 9/5 + 32;
            return f;
        }

        // the f2c method takes the farenheir value as input and returns
        // the converted celsius value
        public int f2c(int f)
        {
            var c = (f - 32) * 5/9;
            return c;
        }

    }
}
