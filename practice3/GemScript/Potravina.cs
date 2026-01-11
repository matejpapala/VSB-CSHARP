using System;
using System.Xml.Serialization;

namespace GemScript;

public class Potravina : SkladovaPolozka
{
    [XmlAttribute("trvanlivost")]
    public DateTime DatumTrvanlivosti{get;set;}
    
    public override bool JeKriticka()
    {
        if(DatumTrvanlivosti < DateTime.Today) {
            return true;
        }else {
            return false;
        }
    }

    public override string ToString()
    {
        string start = (JeKriticka()) ? "!Potravina" : "Potravina";
        return $"{start} | ID: {Id} | {Nazev} | Mnozstvi: {Mnozstvi} | Expirace: {DatumTrvanlivosti}";
    }
}
