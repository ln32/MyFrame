using ExecuteGacha_FuncSet;

public interface iGachaProcessHandler<TFactoryData, TProductData>
{
    // Factory 생산자 데이터
    TFactoryData factoryData { get; }

    // 유효성검사 ( ex. 소모 자원 존재 )
    bool AvailableCheck();

    // 본인 데이터를 통한 float[] 확률표 받아오기
    float[] GetRatioTable(TFactoryData myData);

    // 자원 소모 진행
    TProductData SetProductData(int returnValue);

    // 자원 소모 진행
    void SetSpendDelta();

    // 유효성 검사 실패 시 action
    void NotAvailableAction();

    // 가챠 결과 action
    void SuccessAction_GUI(TProductData _ReturnData);


    // 가챠 진행
    public void ExecuteGacha()
    {
        if (!AvailableCheck())
        {
            NotAvailableAction();
            return;
        }

        var table = GetRatioTable(factoryData);
        var output = table.ExecuteTable();


        if (AvailableCheck())
        {
            SetSpendDelta();
            SuccessAction_GUI(SetProductData(output));
        }
        else
        {
            NotAvailableAction();
        }
    }
}