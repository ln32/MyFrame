using System;

public static class FuncSet_ExcuteGacha
{

}

public static class GradeSelector
{
    private static readonly float[] probabilities = { 4f, 7f, 12f, 17f, 20f, 17f, 12f, 7f, 4f };

    // 누적 확률 계산 함수
    private static float[] CalculateCumulativeProbabilities(float[] probs)
    {
        float[] cumulative = new float[probs.Length];
        float sum = 0f;

        for (int i = 0; i < probs.Length; i++)
        {
            sum += probs[i];
            cumulative[i] = sum;
        }

        return cumulative;
    }

    public static int ExcuteTable(this float[] pTable)
    {
        long seed = DateTime.UtcNow.Ticks;
        Random random = new Random((int)(seed & 0xFFFFFFFF)); 
        float[] cumulativeProbabilities = CalculateCumulativeProbabilities(pTable);
        double randomValue = random.NextDouble();

        for (int i = 0; i < cumulativeProbabilities.Length; i++)
        {
            if (randomValue <= cumulativeProbabilities[i])
            {
                return i + 1;
            }
        }

        return 1;
    }
}