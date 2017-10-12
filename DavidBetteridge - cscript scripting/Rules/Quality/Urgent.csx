// Increases in quality as the event approaches, but cannot exceed 50
if (PreviousSellin <= 0) Quality = 0;
if (PreviousSellin >= 1 && PreviousSellin <= 5) Quality += 3;
if (PreviousSellin > 5 && PreviousSellin <= 10) Quality += 2;
if (PreviousSellin > 10) Quality += 1;

System.Math.Min(50, Quality)