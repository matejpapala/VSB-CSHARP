using System;

namespace Practice2;

public class Order
{
    public string OrderId{get;set;}
    public string CustomerName{get;set;}
    public string Status{get;set;}
    public List<Item> Items{get;set;}
    public int TotalAmount{get;set;}
}
