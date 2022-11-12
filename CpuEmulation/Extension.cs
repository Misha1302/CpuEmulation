using System.Collections;

namespace CpuEmulation;

public static class Extension
{
    /// <summary>
    ///     Gets range of values to bitarray
    /// </summary>
    /// <param name="bitArray">Array to get values</param>
    /// <param name="startIndex">Start index of getting values for bitArray</param>
    /// <param name="endIndex">End index of getting values for bitArray</param>
    public static BitArray GetRange(this BitArray bitArray, int startIndex, int endIndex)
    {
        var range = new BitArray(endIndex - startIndex);
        var index = 0;
        for (var i = startIndex; i < endIndex; i++)
        {
            range[index] = bitArray[i];
            index++;
        }

        return range;
    }

    /// <summary>
    ///     Sets range of values to bitarray
    /// </summary>
    /// <param name="bitArray">Array to set values</param>
    /// <param name="range">Array containing values to set</param>
    /// <param name="startIndex">Start index of setting values for bitArray</param>
    /// <param name="endIndex">End index of setting values for bitArray</param>
    public static void SetRange(this BitArray bitArray, BitArray range, int startIndex, int endIndex)
    {
        var index = 0;
        for (var i = startIndex; i < endIndex; i++)
        {
            bitArray[i] = range[index];
            index++;
        }
    }

    /// <summary>
    ///     Converts bitArray to int
    /// </summary>
    /// <param name="bitArray"></param>
    /// <returns></returns>
    public static int ToInt32(this BitArray bitArray)
    {
        var l = 0;
        var i = 1;

        for (var index = bitArray.Count - 1; index >= 0; index--)
        {
            l += (bitArray[index] ? 1 : 0) * i;
            i *= 2;
        }

        if (!bitArray[0]) return l;
        return -l;
    }

    /// <summary>
    ///     Converts number to bitarray
    /// </summary>
    public static BitArray ToBitArray(this int number)
    {
        var bitArray = new BitArray(32);
        var currentPowerOfTwo = 1073741824;
        for (var i = bitArray.Count - 1; i > 0; i--)
        {
            if (number >= currentPowerOfTwo)
            {
                number -= currentPowerOfTwo;
                bitArray[^i] = true;
            }
            else
            {
                bitArray[^i] = false;
            }

            currentPowerOfTwo /= 2;
        }

        bitArray[0] = number < 0;
        return bitArray;
    }

    /// <summary>
    ///     Compares two bitarray
    /// </summary>
    /// <returns>true - if the arrays are equal, false otherwise</returns>
    public static bool Identical(this BitArray array0, BitArray array1)
    {
        for (var i = 0; i < array0.Length; i++)
            if (array0[i] != array1[i])
                return false;

        return true;
    }
}