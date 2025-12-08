using System;

namespace Practice2;

public class OrderForEnumeration
{
    public string CustomerName{get;set;}
    public string ItemName{get;set;}
    public int  TotalAmount{get;set;}

    public OrderForEnumeration(string customer, string item, int total) {
        CustomerName = customer;
        ItemName = item;
        TotalAmount = total;
    }
}
