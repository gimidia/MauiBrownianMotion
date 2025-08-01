﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBrownianMotion.Models;

public static class BrownianModel
{
    public static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
    {
        if (numDays <= 0)
            throw new ArgumentException("O número de dias deve ser um valor positivo.", nameof(numDays));
        if (initialPrice < 0)
            throw new ArgumentException("O preço inicial não pode ser negativo.", nameof(initialPrice));
        if (sigma < 0)
            throw new ArgumentException("O valor de Sigma não pode ser negativo.", nameof(sigma));

        Random rand = new();
        double[] prices = new double[numDays];
        prices[0] = initialPrice;

        for (int i = 1; i < numDays; i++)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

            double retornoDiario = mean + sigma * z;
            prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
        }

        return prices;
    }
}

