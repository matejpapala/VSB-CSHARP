using System;
using System.Text.Json.Serialization;

namespace GemScript;

public class Elektronika : SkladovaPolozka
{
    public Specifikace Specs{get;set;}

    public class Specifikace {
        [JsonPropertyName("vaha_kg")]
        public double Vaha { get; set; }

        [JsonPropertyName("krehke")]
        public bool Krehke { get; set; }
    }
    public bool JeKrehke{get;set;}
    public override bool JeKriticka()
    {
        if(JeKrehke) {
            return true;
        }else {
            return false;
        }
    }

    public override string ToString()
    {
        string start = (JeKriticka()) ? "!Elektronika" : "Elektronika";
        return $"{start} | ID: {Id} | {Nazev} | Mnozstvi: {Mnozstvi} | Krehke: {JeKrehke}";
    }
}
