using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public struct intchain
{

    private static readonly Dictionary<double, string> _abbreviations = new() {
        { 1000, "k" },
        { 1000000, "m" },
        { 1000000000, "b" },
        { 1000000000000, "t" },
        { 1000000000000000, "q" },
        { 1000000000000000000, "Q" },
        { 1000000000000000000000.0, "s" },
        { 1000000000000000000000000.0, "S" },
        { 1000000000000000000000000000.0, "o" },
        { 1000000000000000000000000000000.0, "n" },
        { 1000000000000000000000000000000000.0, "d" },
        { 1000000000000000000000000000000000000.0, "und" },
        { 1000000000000000000000000000000000000000.0, "duod" },
        { 1000000000000000000000000000000000000000000.0, "tred" },
        { 1000000000000000000000000000000000000000000000.0, "qaut" },
        { 1000000000000000000000000000000000000000000000000.0, "quin" },
        { 1000000000000000000000000000000000000000000000000000.0, "BigNumber" },
    };


    public static string FormatLargeNumber(double number)
    {
        string format = number.ToString("F1");

        if (number < 1000)
        {
            return format;
        }

        foreach (var abbreviation in _abbreviations.Reverse())
        {
            if (number >= abbreviation.Key)
            {
                if (abbreviation.Value == "BigNumber")
                {
                    return format = "BigNumber";
                }
                return (number / abbreviation.Key).ToString("F1") + "" + abbreviation.Value;
            }
        }
        return format;
    }
}
