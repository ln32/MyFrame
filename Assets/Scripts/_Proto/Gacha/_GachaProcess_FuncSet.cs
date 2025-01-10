using System;

namespace ExecuteGacha_FuncSet
{
    public static class GradeSelector
    {
        private static int GradeSelectorNum;

        // 누적 확률 계산 함수
        private static float[] CalculateCumulativeProbabilities(float[] probs)
        {
            var cumulative = new float[probs.Length];
            var sum = 0f;

            for (var i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                cumulative[i] = sum;
            }

            return cumulative;
        }

        public static int ExecuteTable(this float[] pTable)
        {
            var seed = DateTime.UtcNow.Ticks;
            var random = new Random((int)(seed & 0xFFFFFFFF) + GradeSelectorNum++);

            var cumulativeProbabilities = CalculateCumulativeProbabilities(pTable);
            var randomValue = random.NextDouble();

            for (var i = 0; i < cumulativeProbabilities.Length; i++)
                if (randomValue <= cumulativeProbabilities[i])
                    return i + 1;

            return 1;
        }
    }
}