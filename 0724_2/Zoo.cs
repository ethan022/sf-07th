using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0724_2
{
    // 인터페이스 정의
    public interface IEatable
    {
        void Eat(string food);
    }

    public interface ITrainable
    {
        void Train(string trick);
        bool IsTrained { get; set; }
    }

    // 추상 클래스 정의
    public abstract class Animal1
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void MakeSound();

        public virtual void Sleep()
        {
            Console.WriteLine($"{Name}이(가) 잠을 잡니다.");
        }
    }

    // TODO: 다음 클래스들을 구현하세요
    // 1. Dog : Animal, IEatable, ITrainable
    public class Dog1 : Animal1, IEatable, ITrainable {

        public bool IsTrained { get; set; }

        public void Eat(string food)
        {
            Console.WriteLine($"{Name} 이(가) {food}를 먹습니다. ");
        }
        public void Train(string trick)
        {
            IsTrained = true;
            Console.WriteLine($"{Name} 이(가) {trick} 훈련을 받습니다. ");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다.");
        }

    }


    // 2. Cat : Animal, IEatable  
    public class Cat1 : Animal1, IEatable
    {

        public void Eat(string food)
        {
            Console.WriteLine($"{Name} 이(가) {food}를 먹습니다. ");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}이(가) 야옹 합니다.");
        }

     
    }

    // 3. Elephant : Animal, IEatable, ITrainable
    public class Elephant1 : Animal1, IEatable, ITrainable
    {

        public bool IsTrained { get; set; }

        public void Eat(string food)
        {
            Console.WriteLine($"{Name} 이(가) {food}를 먹습니다. ");
        }
        public void Train(string trick)
        {
            IsTrained = true;
            Console.WriteLine($"{Name} 이(가) {trick} 훈련을 받습니다. ");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}이(가) 뿌우우웅~ 합니다.");
        }
    }
}
