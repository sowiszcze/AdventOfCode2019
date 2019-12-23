﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day18Task1Solution.Enums
{
    [Flags]
    public enum Lock
    {
        None = 0,
        A = 0b00000000000000000000000001,
        B = 0b00000000000000000000000010,
        C = 0b00000000000000000000000100,
        D = 0b00000000000000000000001000,
        E = 0b00000000000000000000010000,
        F = 0b00000000000000000000100000,
        G = 0b00000000000000000001000000,
        H = 0b00000000000000000010000000,
        I = 0b00000000000000000100000000,
        J = 0b00000000000000001000000000,
        K = 0b00000000000000010000000000,
        L = 0b00000000000000100000000000,
        M = 0b00000000000001000000000000,
        N = 0b00000000000010000000000000,
        O = 0b00000000000100000000000000,
        P = 0b00000000001000000000000000,
        Q = 0b00000000010000000000000000,
        R = 0b00000000100000000000000000,
        S = 0b00000001000000000000000000,
        T = 0b00000010000000000000000000,
        U = 0b00000100000000000000000000,
        V = 0b00001000000000000000000000,
        W = 0b00010000000000000000000000,
        X = 0b00100000000000000000000000,
        Y = 0b01000000000000000000000000,
        Z = 0b10000000000000000000000000
    }
}
