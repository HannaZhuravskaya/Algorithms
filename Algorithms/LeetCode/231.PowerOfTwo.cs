using System;
using FluentAssertions;

public class IsPowerOfTwoTask
{
    public bool IsPowerOfTwo(int n) 
    {
        if(n <= 0)
            return false;

        var str = Convert.ToString(n, 2);

        var cnt = 0;
        foreach (int digit in str)
        {
            if(digit == '1')
               ++cnt;

            if(cnt > 1)
                return false;
        }

        return cnt == 1;
    }

    public static void Check()
    {
        var obj = new IsPowerOfTwoTask();

        obj.IsPowerOfTwo(int.MinValue).Should().Be(false);
        obj.IsPowerOfTwo(int.MaxValue).Should().Be(false);
        obj.IsPowerOfTwo(0).Should().Be(false);
        obj.IsPowerOfTwo(1).Should().Be(true);
        obj.IsPowerOfTwo(2).Should().Be(true);
    }
}