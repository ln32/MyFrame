using System;
using UnityEngine;

namespace ProtoGacha_Additional
{
    public class FeverHandler
    {
        public float _feverPer;
        public float _feverTime;

        private bool myBool = false;
        public DateTime startTime;

        private bool timeStored;

        public bool GetIsStored()
        {
            return timeStored || IsFeverTime();
        }

        public void AddFeverPercent_byCreateItem(float input)
        {
            do
            {
                if (IsFeverTime())
                    break;

                _feverPer += input;

                if (_feverPer >= 1)
                    // Fever Sequence
                    if (true)
                    {
                        _feverPer--;
                        SetTimer();
                    }
            } while (false);
        }

        public float GetFeverPercent()
        {
            var returnF = Mathf.Min(_feverPer, 1f);
            return returnF;
        }

        public void SetTimer()
        {
            Debug.Log("SetTimer!");
            startTime = DateTime.UtcNow;
            timeStored = true;
        }

        public bool IsFeverTime()
        {
            if (!timeStored)
            {
                Debug.LogWarning("Time not stored yet. Call StoreTime() first.");
                return false;
            }

            var timeElapsed = DateTime.UtcNow - startTime;
            var TimeGap = 10f - timeElapsed.TotalSeconds;
            return TimeGap > 0;
        }
    }
}