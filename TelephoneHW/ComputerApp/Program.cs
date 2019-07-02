using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerApp
{
    public interface IAbstractFactory
    {
        IAbstractProductProcessor CreateProductProcessor();
        IAbstractProductMotherboard CreateProductMotherboard();
    }

    public interface IAbstractProductProcessor
    {
        string UsefulFunctionProcessor();
    }

    public interface IAbstractProductMotherboard
    {
        string UsefulFunctionMotherboard();
        string AnotherUsefulFunctionMotherboard(IAbstractProductProcessor collaborator);
    }

    public class DellFactory : IAbstractFactory
    {
        public IAbstractProductMotherboard CreateProductMotherboard()
        {
            return new ProductMotherboardDell();
        }

        public IAbstractProductProcessor CreateProductProcessor()
        {
            return new ProductProcessorDell();
        }
    }

    public class SonyFactory : IAbstractFactory
    {
        public IAbstractProductMotherboard CreateProductMotherboard()
        {
            return new ProductMotherboardSony();
        }

        public IAbstractProductProcessor CreateProductProcessor()
        {
            return new ProductProcessorSony();
        }
    }

    public class ProductProcessorDell : IAbstractProductProcessor
    {
        public string UsefulFunctionProcessor()
        {
            return "The result of the product Dell Processor";
        }
    }

    public class ProductMotherboardDell : IAbstractProductMotherboard
    {
        public string AnotherUsefulFunctionMotherboard(IAbstractProductProcessor collaborator)
        {
            var result = collaborator.UsefulFunctionProcessor();

            return $"The result of the product Dell Motherboard collaborating with the ({result})";
        }

        public string UsefulFunctionMotherboard()
        {
            return "The result of the product Dell Motherboard";
        }
    }

    public class ProductProcessorSony : IAbstractProductProcessor
    {
        public string UsefulFunctionProcessor()
        {
            return "The result of the product Sony Processor";
        }
    }

    public class ProductMotherboardSony : IAbstractProductMotherboard
    {
        public string AnotherUsefulFunctionMotherboard(IAbstractProductProcessor collaborator)
        {
            var result = collaborator.UsefulFunctionProcessor();

            return $"The result of the product Sony Motherboard collaborating with the ({result})";
        }

        public string UsefulFunctionMotherboard()
        {
            return "The result of the product Sony Motherboard";
        }
    }

    public class Client
    {
        public void Main()
        {
            // Клиентский код может работать с любым конкретным классом
            // фабрики.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new DellFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new SonyFactory());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            IAbstractProductProcessor productA = factory.CreateProductProcessor();
            IAbstractProductMotherboard productB = factory.CreateProductMotherboard();

            Console.WriteLine(productB.UsefulFunctionMotherboard());
            Console.WriteLine(productB.AnotherUsefulFunctionMotherboard(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
