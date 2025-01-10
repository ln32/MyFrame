namespace GachaAddactiveFuncset
{
    public static class FloatArrayData
    {
        public static float[] GetNormalizeForm(this float[] TargetData)
        {
            if (TargetData == null || TargetData.Length == 0 || TargetData[0] == 0) return null;

            var length = TargetData.Length;
            var sum = 0f;

            var NormalizeForm = new float[TargetData.Length];

            for (var i = 0; i < length; i++)
            {
                NormalizeForm[i] = TargetData[i];
                sum += TargetData[i];
            }


            for (var i = 0; i < length; i++) NormalizeForm[i] /= sum;

            return NormalizeForm;
        }

        public static float[] GetSnowballForm(this float[] TargetData)
        {
            if (TargetData == null || TargetData.Length == 0 || TargetData[0] == 0) return null;

            var length = TargetData.Length;
            var sum = 0f;

            var SnowballForm = new float[TargetData.Length];

            for (var i = 0; i < length; i++)
            {
                sum += TargetData[i];
                SnowballForm[i] = sum;
            }


            for (var i = 0; i < length; i++) SnowballForm[i] /= sum;

            return SnowballForm;
        }
    }
}