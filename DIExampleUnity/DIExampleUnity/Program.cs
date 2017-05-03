using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;


namespace DIExampleUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer con = new UnityContainer();
            con.RegisterType<Customer>();
            con.RegisterType<IDal,SQLServerDal>();
            con.RegisterType<IDal,OricalServerDal>();

            Customer c = con.Resolve<Customer>();
            c.CName = "Tets customer";
            c.Add();

            Console.ReadKey();
        }
    }

    public class Customer
    {
        public Customer(IDal o)
        {
            Odal = o;
        }
        private IDal Odal;   
        public string CName { get; set; }

        public void Add() 
        {
            // dal
            Odal.Add();
        }
    }

    public class SQLServerDal : IDal
    {
        public void Add()
        {
            // dal
            Console.WriteLine("insertedSQL");
        }
    }

    public class OricalServerDal : IDal
    {
        public void Add()
        {
            // dal
            Console.WriteLine("insertedOrical");
        }
    }

    public interface IDal
    {
        void Add();
    }
}
