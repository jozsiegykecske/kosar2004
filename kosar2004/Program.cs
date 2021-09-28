using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
  class Program
  {
    static List<kosar> lista = new List<kosar>();
    static void Main(string[] args)
    {
      MasodikFeladat();
      HarmadikFeladat();
      NegyedikFeladat();
      OtodikFeladat();
      HatodikFeladat();
      HetedikFeladat();
      Console.ReadKey();
    }

    private static void HetedikFeladat()
    {
      Console.WriteLine("7.feladat");
      Dictionary<string, int> dick = new Dictionary<string, int>();
      foreach (var l in lista)
      {
        if (!dick.ContainsKey(l.Helyszin))
        {
          dick.Add(l.Helyszin,0);
        }
        else
        {
          dick[l.Helyszin]++;
        }
      }
      foreach (var d in dick)
      {
        if (d.Value>20)
        {
          Console.WriteLine($"\t {d.Key}: {d.Value}");
        }
      }
    }

    private static void HatodikFeladat()
    {
      Console.WriteLine("6.feladat:");
      foreach (var l in lista)
      {
        if (l.Idopont.ToShortDateString()=="2004. 11. 21.")
        {
          Console.WriteLine($"\t{l.Hazai}-{l.Idegen} ({l.Hazai_pont}:{l.Idegen_pont})");
        }
      }
    }

    private static void OtodikFeladat()
    {
      string csapat_neve ="";
      foreach (var l in lista)
      {
        if (l.Hazai.Contains("Barcelona"))
        {
          csapat_neve = l.Hazai;
        }
      }
      Console.WriteLine($"5. feladat: barcelonai csapat neve: {csapat_neve}");
    }

    private static void NegyedikFeladat()
    {
      int szamlalo = 0;
      bool nincs = true;
      while (szamlalo<lista.Count && nincs)
      {
        if (lista[szamlalo].Hazai_pont == lista[szamlalo].Idegen_pont)
        {
          nincs = false;
        }
        szamlalo++;
      }
      if (nincs)
      {
        Console.WriteLine("4.feladat: Volt döntetlen? Nem");
      }
      else
      {
        Console.WriteLine("4.feladat: Volt döntetlen? Igen");
      }
    }

    private static void HarmadikFeladat()
    {
      int hazai = 0,idegen = 0;
      foreach (var l in lista)
      {
        if (l.Hazai=="Real Madrid")
        {
          hazai++;
        }
        if (l.Idegen=="Real Madrid")
        {
          idegen++;
        }
      }
      Console.WriteLine($"3. feladat: Real Madrid: Hazai: {hazai}, Idegen: {idegen}");
    }

    private static void MasodikFeladat()
    {
      StreamReader be = new StreamReader("eredmenyek.csv");
      be.ReadLine();
      while (!be.EndOfStream)
      {
        string[] valami = be.ReadLine().Split(';');
        lista.Add(new kosar(valami[0],valami[1],Convert.ToInt32(valami[2]), Convert.ToInt32(valami[3]),valami[4],Convert.ToDateTime(valami[5])));
      }
      be.Close();
    }
  }
}
