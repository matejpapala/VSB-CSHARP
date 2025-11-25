using System.Text;

namespace Kontakty;

class Program
{
    static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>()
        {
            new Contact() { Name = "Jan", Age = 30, Email = "jan.csharp@vsb.cz", Weight = 85.6, IsAlive = true },
            new Contact() { Name = "Tereza", Age = 89, Email = "tereza.csharp@vsb.cz", Weight = 61, IsAlive = false },
            new Contact() { Name = "Karel", Age = null, Email = "karel.csharp@vsb.cz", Weight = 102.5, IsAlive = true },
            new Contact() { Name = "Tomáš", Age = 14, Email = "tomas.csharp@vsb.cz", Weight = 45, IsAlive = true },
        };
        // TextFile(contacts);
        // BinaryFile(contacts);
        // MemoryFile(contacts);

        int[] numbers = [2, 4, 1 ,32, 51, 12, 145, 123, 3, -1, 32, 435, 13, 51, 21, 91, 85];
        Array.Sort(numbers, new NumberComparer());
        List<int> numbersList = new List<int>(numbers);
        // numbersList.Sort();

        // Console.WriteLine(string.Join(",", numbersList));

        contacts.Sort(new ContactComparer());
        foreach(Contact con in contacts) {
            Console.WriteLine(con.Name);
        }

}

private static void MemoryFile(List<Contact> contacts) 
    {
        using (MemoryStream fs = new MemoryStream()) {
        using (StreamWriter writer = new StreamWriter(fs, leaveOpen: true))
        {
        foreach(Contact con in contacts) {
                writer.Write(con.Name);
                writer.Write(';');
                writer.Write(con.Age);
                writer.Write(';');
                writer.Write(con.Email);
                writer.Write(';');
                writer.Write(con.Weight);
                writer.Write(';');
                writer.Write(con.IsAlive);
                writer.WriteLine();
        }
        }

        fs.Seek(0, SeekOrigin.Begin);
        using StreamReader reader = new StreamReader(fs);
        while(true) {
            string line = reader.ReadLine();
            if(line == null) break;
            string[] parts = line.Split(';');
            Contact tmp = new Contact(){
              Name = parts[0],
              Age = string.IsNullOrEmpty(parts[1]) ? null : int.Parse(parts[1]),
              Email = parts[2],
              Weight = double.Parse(parts[3]),
              IsAlive = bool.Parse(parts[4])  
            };
            Console.WriteLine(line);
        }
        }
        
    }


private static void BinaryFile(List<Contact> contacts) {
    using (FileStream fs = new FileStream("contactsBin.bin", FileMode.Create))
    {
        using(BinaryWriter bw = new BinaryWriter(fs))
        {
            foreach(Contact con in contacts) {
                bw.Write(con.Name);
                bw.Write(con.Age.HasValue);
                if(con.Age.HasValue) {
                    bw.Write(con.Age.Value);
                }
                bw.Write(con.Email);
                bw.Write(con.Weight);
                bw.Write(con.IsAlive);
            }
        }
    }
    using(FileStream fs = new FileStream("contactsBin.bin", FileMode.Open)) {
        using(BinaryReader br = new BinaryReader(fs)) {
            while(true){
                if(fs.Position == fs.Length) break;
                Console.WriteLine(br.ReadString());
                if(br.ReadBoolean()) {
                    Console.WriteLine(br.ReadInt32());
                }
                Console.WriteLine(br.ReadString());
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadBoolean());
                Console.WriteLine();
            }
            }
    }

}


private static void TextFile(List<Contact> contacts) 
    {
        using (IDisposable tmp = null) {
            // tmp.Dispose();
        } 

        using (FileStream fs = new FileStream("contacts.txt", FileMode.Create)) {
        using (StreamWriter writer = new StreamWriter(fs, leaveOpen: true))
        {
        foreach(Contact con in contacts) {
                writer.Write(con.Name);
                writer.Write(';');
                writer.Write(con.Age);
                writer.Write(';');
                writer.Write(con.Email);
                writer.Write(';');
                writer.Write(con.Weight);
                writer.Write(';');
                writer.Write(con.IsAlive);
                writer.WriteLine();
        }
        }

        fs.Seek(0, SeekOrigin.Begin);
        using StreamReader reader = new StreamReader(fs);
        while(true) {
            string line = reader.ReadLine();
            if(line == null) break;
            string[] parts = line.Split(';');
            Contact tmp = new Contact(){
              Name = parts[0],
              Age = string.IsNullOrEmpty(parts[1]) ? null : int.Parse(parts[1]),
              Email = parts[2],
              Weight = double.Parse(parts[3]),
              IsAlive = bool.Parse(parts[4])  
            };
            Console.WriteLine(line);
        }
        }
        
    }

}