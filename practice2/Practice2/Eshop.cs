using System;
using System.Collections;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Practice2;

public class Eshop : IEnumerable<OrderForEnumeration>
{
    public List<Order> orders = new List<Order>();

    public void Add(Order order) {
        orders.Add(order);
    }

    public List<Order> DeserializeFromJson(string path) {
        var options = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var text = File.ReadAllText(path);
        List<Order> result = JsonSerializer.Deserialize<List<Order>>(text, options);
        return result;
    }

    public IEnumerator<OrderForEnumeration> GetEnumerator()
    {
        foreach(Order order in orders) {
            foreach(Item item in order.Items) {
                yield return new OrderForEnumeration(order.CustomerName, item.ProductName, order.TotalAmount);
            }
        }
    }

    public void Sort(IComparer<Order> comparer) {
        orders.Sort(comparer);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void SaveToBinary() {
        using (FileStream fs = new FileStream("data.bin", FileMode.Create))
        using (BinaryWriter binaryWriter = new BinaryWriter(fs)) {
            binaryWriter.Write(orders.Count);
        foreach(Order order in orders) {
            binaryWriter.Write(order.CustomerName);
            binaryWriter.Write(order.Items.Count);
            foreach(Item item in order.Items) {
                binaryWriter.Write(item.ProductName);
                binaryWriter.Write(item.Quantity);
            }
        }
        }
    }

    public void PrintStats() {
        Dictionary<string, int> productSalesStats = new Dictionary<string, int>();

        foreach(Order order in orders) {
            foreach(Item item in order.Items) {
                if(productSalesStats.ContainsKey(item.ProductId)) {
                    productSalesStats[item.ProductId] += item.Quantity;
                }else {
                    productSalesStats.Add(item.ProductId, item.Quantity);
                }
            }
        }

        foreach(var entry in productSalesStats) {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    public void SerializeToXml() {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
        using(FileStream fs = new FileStream("data.xml", FileMode.Create)) {
            xmlSerializer.Serialize(fs, orders);
        }
    }

    public void SerializeToJson() {
        using(FileStream fs = new FileStream("serialized.json", FileMode.Create)) {
            var options = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            };
            JsonSerializer.Serialize(fs, orders, options);
        }
    }
}
