// The quality increases each time to a maximum of 50
Quality++;

if (PreviousSellin <= 0)
    Quality++;

System.Math.Min(50, Quality)