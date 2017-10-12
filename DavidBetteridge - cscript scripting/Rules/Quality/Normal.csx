// Decreases by one each day, but not beyond 0
Quality--;

if (PreviousSellin <= 0)
    Quality--;

System.Math.Max(0, Quality)