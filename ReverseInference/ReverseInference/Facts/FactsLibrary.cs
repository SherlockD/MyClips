using System;
using System.Collections.Generic;

namespace ReverseInference.Fact
{
    public class FactsLibrary
    {
        public static FactsLibrary Instance;

        public FactsLibrary()
        {
            if (Instance == null)
                Instance = this;
        }
        
        public List<Fact> Library = new List<Fact>();

        public bool HasFact(string objectName, string feature) => Library.Find(fact => fact.ObjectName == objectName && fact.Feature == feature) != null;

        public void PrintFacts()
        {
            Console.Clear();
            
            Library.ForEach((fact) =>
            {
                Console.WriteLine($"{fact.ObjectName} : {fact.Feature}");
            });
        }
    }
}