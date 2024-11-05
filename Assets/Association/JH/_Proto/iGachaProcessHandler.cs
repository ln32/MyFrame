public interface iGachaProcessHandler<GachaDataClass, ResultDataClass>
{
    // 본인 데이터 ( class로 데이터 따로관리 고민중 )
    GachaDataClass myData { get; }

    ResultDataClass ResultData { get; }

    // 유효성검사 ( 소모 자원 존재라던가 )
    bool AvailableCheck();

    // 본인 데이터를 통한 float[] 확률표 받아오기
    float[] GetTargetTable(GachaDataClass myData);

    // 자원 소모 진행
    ResultDataClass SetReturnData(int returnValue);

    // 자원 소모 진행
    void SetTicketDelta();
        
    // 가챠 결과 반영
    void ApplyResult(ResultDataClass _ReturnData);


    // 유효성 검사 실패 시 action
    void NotAvailableAction();

    // 가챠 결과 action
    void SuccessAction(ResultDataClass _ReturnData);


    // 가챠 진행
    public void ExcuteGacha()
    {
        if (!AvailableCheck())
        {
            NotAvailableAction();
            return;
        }

        float[] target = GetTargetTable(myData);
        int resultIndex = target.ExcuteTable();
        ResultDataClass resultData = SetReturnData(resultIndex);

        if (AvailableCheck())
        {
            SetTicketDelta();
            ApplyResult(resultData);

            SuccessAction(resultData);
            return;
        }
        else
        {
            NotAvailableAction();
            return;
        }
    }
}
