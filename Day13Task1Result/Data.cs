﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day13Task1Result
{
    public static class Data
    {
        public static long[] Program => new long[] { 1, 380, 379, 385, 1008, 2319, 922392, 381, 1005, 381, 12, 99, 109, 2320, 1101, 0, 0, 383, 1101, 0, 0, 382, 20102, 1, 382, 1, 20102, 1, 383, 2, 21102, 1, 37, 0, 1105, 1, 578, 4, 382, 4, 383, 204, 1, 1001, 382, 1, 382, 1007, 382, 40, 381, 1005, 381, 22, 1001, 383, 1, 383, 1007, 383, 21, 381, 1005, 381, 18, 1006, 385, 69, 99, 104, -1, 104, 0, 4, 386, 3, 384, 1007, 384, 0, 381, 1005, 381, 94, 107, 0, 384, 381, 1005, 381, 108, 1105, 1, 161, 107, 1, 392, 381, 1006, 381, 161, 1101, -1, 0, 384, 1106, 0, 119, 1007, 392, 38, 381, 1006, 381, 161, 1101, 1, 0, 384, 20102, 1, 392, 1, 21102, 19, 1, 2, 21102, 1, 0, 3, 21101, 0, 138, 0, 1105, 1, 549, 1, 392, 384, 392, 21001, 392, 0, 1, 21102, 19, 1, 2, 21101, 3, 0, 3, 21101, 161, 0, 0, 1106, 0, 549, 1102, 0, 1, 384, 20001, 388, 390, 1, 21001, 389, 0, 2, 21101, 0, 180, 0, 1106, 0, 578, 1206, 1, 213, 1208, 1, 2, 381, 1006, 381, 205, 20001, 388, 390, 1, 21001, 389, 0, 2, 21101, 205, 0, 0, 1105, 1, 393, 1002, 390, -1, 390, 1102, 1, 1, 384, 20101, 0, 388, 1, 20001, 389, 391, 2, 21101, 0, 228, 0, 1105, 1, 578, 1206, 1, 261, 1208, 1, 2, 381, 1006, 381, 253, 21001, 388, 0, 1, 20001, 389, 391, 2, 21101, 0, 253, 0, 1106, 0, 393, 1002, 391, -1, 391, 1102, 1, 1, 384, 1005, 384, 161, 20001, 388, 390, 1, 20001, 389, 391, 2, 21101, 0, 279, 0, 1106, 0, 578, 1206, 1, 316, 1208, 1, 2, 381, 1006, 381, 304, 20001, 388, 390, 1, 20001, 389, 391, 2, 21102, 1, 304, 0, 1105, 1, 393, 1002, 390, -1, 390, 1002, 391, -1, 391, 1102, 1, 1, 384, 1005, 384, 161, 21002, 388, 1, 1, 21002, 389, 1, 2, 21101, 0, 0, 3, 21102, 338, 1, 0, 1106, 0, 549, 1, 388, 390, 388, 1, 389, 391, 389, 20101, 0, 388, 1, 21001, 389, 0, 2, 21102, 1, 4, 3, 21102, 1, 365, 0, 1106, 0, 549, 1007, 389, 20, 381, 1005, 381, 75, 104, -1, 104, 0, 104, 0, 99, 0, 1, 0, 0, 0, 0, 0, 0, 242, 18, 16, 1, 1, 20, 109, 3, 21202, -2, 1, 1, 21202, -1, 1, 2, 21102, 1, 0, 3, 21102, 414, 1, 0, 1106, 0, 549, 22101, 0, -2, 1, 22101, 0, -1, 2, 21101, 429, 0, 0, 1106, 0, 601, 2101, 0, 1, 435, 1, 386, 0, 386, 104, -1, 104, 0, 4, 386, 1001, 387, -1, 387, 1005, 387, 451, 99, 109, -3, 2105, 1, 0, 109, 8, 22202, -7, -6, -3, 22201, -3, -5, -3, 21202, -4, 64, -2, 2207, -3, -2, 381, 1005, 381, 492, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 481, 21202, -4, 8, -2, 2207, -3, -2, 381, 1005, 381, 518, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 507, 2207, -3, -4, 381, 1005, 381, 540, 21202, -4, -1, -1, 22201, -3, -1, -3, 2207, -3, -4, 381, 1006, 381, 529, 22101, 0, -3, -7, 109, -8, 2106, 0, 0, 109, 4, 1202, -2, 40, 566, 201, -3, 566, 566, 101, 639, 566, 566, 2101, 0, -1, 0, 204, -3, 204, -2, 204, -1, 109, -4, 2106, 0, 0, 109, 3, 1202, -1, 40, 593, 201, -2, 593, 593, 101, 639, 593, 593, 21002, 0, 1, -2, 109, -3, 2105, 1, 0, 109, 3, 22102, 21, -2, 1, 22201, 1, -1, 1, 21102, 431, 1, 2, 21102, 286, 1, 3, 21102, 840, 1, 4, 21101, 0, 630, 0, 1105, 1, 456, 21201, 1, 1479, -2, 109, -3, 2106, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 0, 1, 1, 0, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 2, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0, 2, 2, 2, 0, 1, 1, 0, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 2, 0, 2, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 0, 2, 0, 2, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 2, 0, 0, 2, 0, 1, 1, 0, 2, 0, 2, 2, 0, 0, 0, 2, 0, 0, 2, 0, 2, 2, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 1, 1, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 2, 0, 0, 0, 2, 0, 2, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 2, 2, 0, 2, 0, 0, 0, 1, 1, 0, 2, 2, 0, 2, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 1, 1, 0, 2, 0, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0, 0, 2, 0, 2, 2, 2, 0, 0, 2, 0, 2, 2, 2, 2, 0, 2, 0, 0, 1, 1, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 0, 0, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 2, 0, 0, 2, 2, 0, 2, 2, 2, 0, 1, 1, 0, 0, 0, 2, 0, 2, 2, 2, 0, 2, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 0, 0, 0, 1, 1, 0, 2, 0, 2, 2, 0, 2, 2, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 55, 58, 16, 34, 73, 94, 65, 31, 91, 83, 29, 64, 87, 32, 19, 13, 15, 82, 19, 98, 37, 85, 58, 41, 63, 56, 69, 56, 69, 38, 60, 58, 83, 4, 45, 76, 4, 63, 23, 31, 4, 79, 69, 97, 22, 86, 51, 88, 96, 2, 39, 88, 53, 49, 70, 45, 49, 28, 8, 64, 81, 36, 84, 8, 47, 69, 56, 1, 82, 31, 94, 23, 5, 94, 17, 83, 46, 17, 18, 71, 90, 21, 30, 19, 35, 43, 90, 25, 82, 11, 39, 13, 94, 13, 68, 91, 4, 33, 21, 65, 86, 49, 17, 23, 92, 52, 2, 44, 7, 47, 82, 36, 79, 52, 10, 53, 50, 21, 79, 94, 95, 13, 69, 74, 95, 26, 7, 18, 56, 21, 9, 79, 84, 15, 56, 43, 60, 38, 85, 37, 93, 95, 96, 41, 54, 94, 71, 5, 59, 27, 69, 79, 52, 19, 58, 12, 85, 54, 87, 25, 94, 7, 19, 90, 54, 97, 13, 92, 80, 18, 39, 40, 31, 81, 76, 62, 53, 84, 82, 20, 64, 58, 65, 4, 18, 32, 38, 36, 66, 90, 97, 49, 59, 7, 89, 8, 2, 44, 60, 52, 80, 54, 85, 8, 81, 2, 34, 21, 2, 48, 55, 51, 81, 67, 50, 93, 92, 25, 77, 54, 74, 37, 92, 18, 52, 27, 14, 41, 11, 32, 65, 11, 76, 44, 58, 48, 61, 65, 66, 62, 48, 47, 76, 12, 68, 73, 54, 42, 89, 36, 73, 5, 78, 72, 3, 77, 4, 46, 68, 73, 75, 86, 77, 69, 65, 13, 2, 97, 46, 98, 39, 45, 32, 57, 49, 3, 24, 14, 12, 95, 92, 10, 94, 83, 24, 73, 97, 35, 67, 2, 63, 42, 1, 44, 46, 41, 76, 96, 66, 82, 18, 7, 13, 2, 69, 77, 63, 12, 74, 70, 22, 60, 34, 16, 71, 10, 40, 82, 35, 88, 27, 41, 86, 44, 33, 49, 98, 78, 33, 35, 76, 47, 69, 61, 46, 81, 79, 35, 68, 40, 28, 92, 18, 22, 24, 74, 9, 92, 18, 16, 40, 26, 47, 90, 61, 26, 29, 30, 72, 97, 7, 44, 93, 61, 66, 74, 41, 79, 46, 47, 92, 87, 2, 77, 25, 67, 91, 67, 96, 66, 43, 23, 44, 83, 74, 90, 32, 18, 28, 70, 77, 31, 2, 22, 54, 59, 28, 44, 15, 15, 45, 33, 96, 23, 67, 69, 24, 63, 10, 72, 44, 96, 43, 77, 66, 53, 41, 63, 21, 64, 46, 52, 84, 70, 35, 21, 85, 30, 69, 64, 62, 92, 83, 42, 56, 74, 91, 51, 52, 12, 45, 18, 13, 56, 64, 61, 94, 35, 46, 62, 74, 82, 39, 67, 43, 94, 7, 39, 15, 41, 98, 51, 57, 35, 83, 36, 55, 8, 56, 77, 22, 45, 51, 88, 72, 71, 73, 41, 31, 79, 40, 60, 50, 26, 67, 75, 57, 75, 50, 12, 63, 56, 38, 16, 47, 46, 11, 56, 96, 66, 58, 7, 8, 21, 70, 28, 30, 29, 52, 97, 48, 12, 6, 21, 80, 67, 4, 2, 17, 40, 33, 54, 52, 36, 90, 64, 23, 81, 69, 95, 23, 38, 19, 46, 26, 16, 21, 54, 50, 13, 95, 59, 68, 40, 97, 68, 31, 13, 49, 59, 15, 57, 29, 23, 35, 43, 31, 70, 7, 74, 8, 4, 61, 18, 82, 43, 4, 58, 12, 66, 69, 23, 43, 31, 16, 9, 61, 90, 69, 80, 82, 66, 81, 21, 24, 5, 37, 70, 30, 44, 92, 42, 41, 27, 28, 58, 91, 19, 53, 51, 5, 95, 31, 98, 84, 6, 62, 30, 36, 26, 26, 5, 95, 50, 16, 19, 10, 50, 10, 44, 96, 80, 39, 96, 28, 87, 94, 47, 79, 92, 47, 8, 86, 54, 38, 49, 87, 96, 78, 66, 86, 6, 77, 55, 11, 82, 73, 22, 75, 1, 11, 83, 20, 8, 27, 64, 24, 38, 11, 23, 43, 68, 60, 52, 45, 44, 67, 35, 77, 57, 1, 96, 6, 57, 28, 52, 97, 27, 55, 64, 94, 96, 23, 11, 9, 37, 70, 15, 35, 36, 58, 34, 34, 16, 69, 69, 82, 62, 88, 91, 29, 31, 95, 35, 54, 61, 12, 23, 76, 26, 1, 33, 51, 41, 45, 74, 80, 6, 36, 93, 13, 26, 81, 79, 5, 54, 17, 27, 51, 15, 52, 36, 31, 5, 62, 70, 21, 87, 76, 55, 26, 59, 81, 88, 90, 4, 40, 94, 55, 36, 32, 94, 62, 73, 43, 2, 39, 77, 51, 28, 24, 69, 21, 66, 43, 14, 74, 10, 46, 33, 1, 29, 74, 2, 33, 68, 68, 72, 21, 51, 91, 82, 1, 69, 80, 78, 69, 7, 14, 43, 25, 10, 69, 27, 13, 90, 50, 28, 21, 40, 16, 68, 58, 6, 23, 87, 6, 74, 9, 91, 25, 98, 58, 47, 91, 3, 38, 3, 91, 4, 28, 84, 12, 2, 54, 92, 27, 81, 13, 33, 89, 38, 1, 64, 91, 21, 7, 41, 74, 74, 922392 };
    }
}
