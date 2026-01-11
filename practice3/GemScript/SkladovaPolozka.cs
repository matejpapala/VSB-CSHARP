using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace GemScript;

public abstract class SkladovaPolozka
{
    [XmlAttribute("id")]
    [JsonPropertyName("id")]
    public int Id{get;set;}
    [JsonPropertyName("nazev")]
    [XmlElement("Nazev")]
    public string Nazev{get;set;}
    [XmlIgnore]
    public double Vaha{get;set;}
    [JsonPropertyName("mnozstvi")]
    [XmlElement("PocetKusu")]
    public int Mnozstvi{get;set;}

    public abstract bool JeKriticka();
}
