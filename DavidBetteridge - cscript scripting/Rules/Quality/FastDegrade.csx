// Decreases twice the speed of a normal item.
// Can not be less than 0
Quality -= 2;

if (PreviousSellin <= 0)
    Quality -= 2;

System.Math.Max(0, Quality)