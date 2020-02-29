using System;
using System.Collections.Generic;

namespace Pattern_Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler intel = new Handler(new IntelFactory());
            intel.processor.Model = "i5";
            intel.processor.Price = 200;
            intel.videoCard.Model = "gtx 1080";
            intel.ProcessorInformation();
            intel.VideoCardInformation();

            Singleton s1=Singleton.Sourse("Singleton");
            Console.WriteLine(s1.Name);
            Singleton s2 = Singleton.Sourse("Singleton2");
            Console.WriteLine(s2.Name);

            IFigure figure = new Rectangle(4, 5);
            IFigure clonedFigure=figure.Clone();
            clonedFigure.GetInfo();

            Builder builder = new ConcerneBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
            Console.WriteLine(product);

            Console.Read();
        }
    }

    abstract class Processor
    {
        public abstract string Model { get; set; }
        public abstract int Price { get; set; }

        public abstract void Information();
    }

    abstract class VideoCard
    {
        public abstract string Model { get; set; }

        public abstract void Information();
    }

    class i7:Processor
    {
        public override string Model { get; set; }
        public override int Price { get; set; }

        //public i7(string model,int price)
        //{
        //    this.Model = model;
        //    this.Price = price;
        //}

        public override void Information()
        {
            Console.WriteLine($"Model:{Model}\nPrice:{Price}\n");
        }
    }

    class Razen : Processor
    {
        public override string Model { get; set; }
        public override int Price { get; set; }

        //public Razen(string model,int price)
        //{
        //    this.Model = model;
        //    this.Price = price;
        //}

        public override void Information()
        {
            Console.WriteLine($"Model:{Model}\nPrice:{Price}\n");
        }
    }

    class Gtx:VideoCard
    {
        public override string Model { get; set; }

        //public Gtx(string model)
        //{
        //    this.Model = model;
        //}

        public override void Information()
        {
            Console.WriteLine($"Model:{Model}\n");
        }
    }

    class Vega:VideoCard
    {
        public override string Model { get; set; }

        //public Vega(string model)
        //{
        //    this.Model = model;
        //}

        public override void Information()
        {
            Console.WriteLine($"Model:{Model}");
        }
    }

    abstract class ComputerFactory
    {
        public abstract Processor CreateProcessor();
        public abstract VideoCard CreateVideoCard();
    }

    class IntelFactory : ComputerFactory
    {
        public override Processor CreateProcessor()
        {
            return new i7();
        }

        public override VideoCard CreateVideoCard()
        {
            return new Gtx();
        }
    }

    class AmdFactory:ComputerFactory
    {
        public override Processor CreateProcessor()
        {
            return new Razen();
        }

        public override VideoCard CreateVideoCard()
        {
            return new Vega();
        }
    }

    class Handler
    {
        public Processor processor;
        public VideoCard videoCard;

        public Handler(ComputerFactory computerFactory)
        {
            processor=computerFactory.CreateProcessor();
            videoCard = computerFactory.CreateVideoCard();
        }

        public void ProcessorInformation()
        {
            processor.Information();
        }

        public void VideoCardInformation()
        {
            videoCard.Information();
        }
    }


    public sealed class Singleton
    {
        private Singleton()
        { }

        private static Singleton sourse = null;

        public string Name { get; private set; }

        private Singleton(string name)
        {
            this.Name = name;
        }

        public static Singleton Sourse(string name)
        {
            if (sourse == null)
                sourse = new Singleton(name);
            return sourse;
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle:IFigure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.X, this.Y);
        }

        public void GetInfo()
        {
            Console.WriteLine($"X:{X}\nY:{Y}\n");
        }
    }

    class Circle:IFigure
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public IFigure Clone()
        {
            return new Circle(this.Radius);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Radius:{Radius}\n");
        }
    }

    class Director
    {
        Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    class Product
    {
        List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }
    }

    class ConcerneBuilder:Builder
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("Part 1");   
        }

        public override void BuildPartB()
        {
            product.Add("Part 2");
        }

        public override void BuildPartC()
        {
            product.Add("Part 3");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}
