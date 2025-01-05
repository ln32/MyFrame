using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMoneyDataHandler
{
    int Gold { get; set; }
    int Dia { get; set; }
    int Ruby { get; set; }
    int Ticket_0 { get; set; }
    int Ticket_1 { get; set; }
    int Ticket_2 { get; set; }
}

internal class MoneyDataHandler : MonoBehaviour, IMoneyDataHandler
{
    [NamedArrayAttribute(new string[] { "Gold", "Dia", "Ruby", "Ticket_0" , "Ticket_1" , "Ticket_2" })]
    [SerializeField] List<int> moneyData = new List<int>();

    public int Gold
    {
        get { return moneyData[0]; }
        set
        {
            moneyData[0] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }

    public int Dia
    {
        get { return moneyData[1]; }
        set
        {
            moneyData[1] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }

    public int Ruby
    {
        get { return moneyData[2]; }
        set
        {
            moneyData[2] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }
    public int Ticket_0
    {
        get { return moneyData[3]; }
        set
        {
            moneyData[3] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }
    public int Ticket_1
    {
        get { return moneyData[4]; }
        set
        {
            moneyData[4] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }
    public int Ticket_2
    {
        get { return moneyData[5]; }
        set
        {
            moneyData[5] = value;
            Console.WriteLine($"Name�� {value}�� �����Ǿ����ϴ�.");
        }
    }

}


public class NamedArrayAttribute : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAttribute(string[] names) { this.names = names; }
}