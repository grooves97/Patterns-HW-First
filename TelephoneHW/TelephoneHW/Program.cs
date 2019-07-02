using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneHW
{
    public interface IAbstractProductAccumulator
    {
        string UsefulFunctionAccumulator();
    }

    public interface IAbstractProductDisplay
    {
        string UsefulFunctionDisplay();
        string AnotherUsefulFunctionDisplay(IAbstractProductAccumulator collaborator);
    }

    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    public interface IAbstractFactory
    {
        IAbstractProductAccumulator CreateProductAccumulator();

        IAbstractProductDisplay CreateProductDisplay();
    }

    /// <summary>
    /// Фабрика Samsung
    /// </summary>
    public class SamsungFactory : IAbstractFactory
    {
        public IAbstractProductAccumulator CreateProductAccumulator()
        {
            return new ProductAccumulatorSamsung();
        }

        public IAbstractProductDisplay CreateProductDisplay()
        {
            return new ProductDisplaySamsung();
        }
    }

    /// <summary>
    /// Фабрика Nokia
    /// </summary>
    public class NokiaFactory : IAbstractFactory
    {
        public IAbstractProductAccumulator CreateProductAccumulator()
        {
            return new ProductAccumulatorNokia();
        }

        public IAbstractProductDisplay CreateProductDisplay()
        {
            return new ProductDisplayNokia();
        }
    }

    /// <summary>
    /// Accumulator Samsung
    /// </summary>
    public class ProductAccumulatorSamsung : IAbstractProductAccumulator
    {
        public string UsefulFunctionAccumulator()
        {
            return "The result of the product Samsung Accumulator.";
        }
    }

    /// <summary>
    /// Display Samsung
    /// </summary>
    public class ProductDisplaySamsung : IAbstractProductDisplay
    {
        public string AnotherUsefulFunctionDisplay(IAbstractProductAccumulator collaborator)
        {
            var result = collaborator.UsefulFunctionAccumulator();

            return $"The result of the Samsung Display collaborating with the ({result})";
        }

        public string UsefulFunctionDisplay()
        {
            return "The result of the Samsung product Display.";
        }
    }

    /// <summary>
    /// Accumulator Nokia
    /// </summary>
    public class ProductAccumulatorNokia : IAbstractProductAccumulator
    {
        public string UsefulFunctionAccumulator()
        {
            return "The result of the product Nokia Accumulator.";
        }

    }

    /// <summary>
    /// Display Nokia
    /// </summary>
    public class ProductDisplayNokia : IAbstractProductDisplay
    {
        public string UsefulFunctionDisplay()
        {
            return "The result of the product Nokia Display.";
        }

        public string AnotherUsefulFunctionDisplay(IAbstractProductAccumulator collaborator)
        {
            var result = collaborator.UsefulFunctionAccumulator();

            return $"The result of the Nokia Display collaborating with the ({result})";
        }
    }

    public class Client
    {
        public void Main()
        {
            // Клиентский код может работать с любым конкретным классом
            // фабрики.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new SamsungFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new NokiaFactory());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            IAbstractProductAccumulator productA = factory.CreateProductAccumulator();
            IAbstractProductDisplay productB = factory.CreateProductDisplay();

            Console.WriteLine(productB.UsefulFunctionDisplay());
            Console.WriteLine(productB.AnotherUsefulFunctionDisplay(productA));
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
