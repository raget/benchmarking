using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class LinqBenchmark
    {
        private IList<Customer> customers = new List<Customer>();

        [Params(10, 100)]
        public int SequenceLength;
        
        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < SequenceLength; i++)
            {
                var id = "id_" + i;
                var name = "user_" + i;
                customers.Add(new Customer(id, name));
            }
        }

        [Benchmark]
        public Customer Linq()
        {
            return customers.FirstOrDefault(c => c.Name == "user_" + (SequenceLength - 5));
        }

        [Benchmark]
        public Customer ForEach()
        {
            foreach (var customer in customers)
            {
                if (customer.Name == "user_" + (SequenceLength - 5))
                    return customer;
            }
            return null;
        }
        [Benchmark]
        public Customer For()
        {
            for (var i = 0; i < customers.Count; i++)
            {
                if (customers[i].Name == "user_" + (SequenceLength - 5))
                    return customers[i];
            }
            return null;
        }
    }

    public class Customer
    {
        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
