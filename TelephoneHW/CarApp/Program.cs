using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    public interface IAbstractFactory
    {
        IAbstractProductBody CreateProductBody();
        IAbstractProductEngine CreateProductEngine();
    }

    public interface IAbstractProductEngine
    {
        string UsefulFunctionEngine();
    }

    public interface IAbstractProductBody
    {
        string UsefulFunctionBody();
        string AnotherUsefulFunctionBody(IAbstractProductEngine collaborator);
    }

    public class FordFactory : IAbstractFactory
    {
        public IAbstractProductBody CreateProductBody()
        {
            return new ProductBodyFord();
        }

        public IAbstractProductEngine CreateProductEngine()
        {
            return new ProductEngineFord();
        }
    }

    public class ToyotaFactory : IAbstractFactory
    {
        public IAbstractProductBody CreateProductBody()
        {
            return new ProductBodyToyota();
        }

        public IAbstractProductEngine CreateProductEngine()
        {
            return new ProductEngineToyota();
        }
    }

    public class ProductBodyFord : IAbstractProductBody
    {
        public string AnotherUsefulFunctionBody(IAbstractProductEngine collaborator)
        {
            var result = collaborator.UsefulFunctionEngine();

            return $"The result of the Ford Body collaborating with the ({result})";
        }

        public string UsefulFunctionBody()
        {
            return "The result of the product Ford Body";
        }
    }

    public class ProductEngineFord : IAbstractProductEngine
    {
        public string UsefulFunctionEngine()
        {
            return "The result of the product Ford Engine";
        }
    }

    public class ProductBodyToyota : IAbstractProductBody
    {
        public string AnotherUsefulFunctionBody(IAbstractProductEngine collaborator)
        {
            var result = collaborator.UsefulFunctionEngine();

            return $"The result of the Toyota Body collaborating with the ({result})";
        }

        public string UsefulFunctionBody()
        {
            return "The result of the product Toyota Body";
        }
    }

    public class ProductEngineToyota : IAbstractProductEngine
    {
        public string UsefulFunctionEngine()
        {
            return "The result of the product Toyota Engine";
        }
    }

    public class Client
    {
        public void Main()
        {
            // Клиентский код может работать с любым конкретным классом
            // фабрики.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new FordFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new ToyotaFactory());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            IAbstractProductEngine productA = factory.CreateProductEngine();
            IAbstractProductBody productB = factory.CreateProductBody();

            Console.WriteLine(productB.UsefulFunctionBody());
            Console.WriteLine(productB.AnotherUsefulFunctionBody(productA));
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
