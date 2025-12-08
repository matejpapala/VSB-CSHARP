using System;
using System.Linq.Expressions;

namespace Practice2;

public class OrderComparer : IComparer<Order>
{
    public int Compare(Order? x, Order? y)
    {
        int xStat = GetStatusPriority(x.Status);
        int yStat = GetStatusPriority(y.Status);

        int statusPrio = xStat.CompareTo(yStat);

        if(statusPrio != 0) {
            return statusPrio;
        }

        return x.TotalAmount.CompareTo(y.TotalAmount);
    }

    public int GetStatusPriority(string OrderStatus) {
        switch(OrderStatus) {
            case "Processing":
            return 1;
            case "Shipped":
            return 2;
            case "Delivered":
            return 3;
            default:
            return 4;
        }
    }
}
