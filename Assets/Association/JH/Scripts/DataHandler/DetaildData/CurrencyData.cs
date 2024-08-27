using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrencyDataHandler
{
    int Gold { get; set; }
    int Dia { get; set; }
    int Ruby { get; set; }
    int Ticket_0 { get; set; }
    int Ticket_1 { get; set; }
    int Ticket_2 { get; set; }
}

internal class CurrencyData : MonoBehaviour, ICurrencyDataHandler
{
    [NamedArrayAttribute(new string[] { "Gold", "Dia", "Ruby", "Ticket_0", "Ticket_1", "Ticket_2" })]
    [SerializeField] internal List<int> _CurrencyData = new List<int>();

    public int Gold
    {
        get { return _CurrencyData[0]; }
        set
        {
            _CurrencyData[0] = value;
        }
    }

    public int Dia
    {
        get { return _CurrencyData[1]; }
        set
        {
            _CurrencyData[1] = value;
        }
    }

    public int Ruby
    {
        get { return _CurrencyData[2]; }
        set
        {
            _CurrencyData[2] = value;
        }
    }
    public int Ticket_0
    {
        get { return _CurrencyData[3]; }
        set
        {
            _CurrencyData[3] = value;
        }
    }
    public int Ticket_1
    {
        get { return _CurrencyData[4]; }
        set
        {
            _CurrencyData[4] = value;
        }
    }
    public int Ticket_2
    {
        get { return _CurrencyData[5]; }
        set
        {
            _CurrencyData[5] = value;
        }
    }
}


public class NamedArrayAttribute : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAttribute(string[] names) { this.names = names; }
}