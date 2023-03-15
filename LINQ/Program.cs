using System;
using System.Security.Cryptography.X509Certificates;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");

            //kutsume WhereLINQ meetodi välja
            WhereLINQ();
            ThenByLINQ();
            ThenByDescendingLINQ();
            ToLookUpLINQ();
            JoinLINQ();
            GroupJoinLINQ();
            SelectLINQ();
            AllAndAnyLINQ();
            ContainsLINQ();
            AggregateLINQ();
            AvarageLINQ();
            CountLINQ();
            MaxLINQ();
            SumLINQ();
            FirstOrDefaultLINQ();
            LastOrDefault();
            SingleOrDefault();
            SequenceEqual();
            DefaultIfEmpty();
            EmptyRangeRepeat();
            Distinct();
            Except();
            Intersect();
            Union();
            Skip();
            TakeAndTakeWhile();
        }

        public static void WhereLINQ()
        {
            var peopleAge = PeopleList.peoples
                .Where(x => x.Age > 20 && x.Age < 23);

            foreach (var item in peopleAge)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ThenByLINQ()
        {
            Console.WriteLine("ThenBy järgi reastamine");

            var thenByResult = PeopleList.peoples
                //järjestab nimede järgi ja siis vanuse järgi
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Age);

            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ThenByDescendingLINQ()
        {
            Console.WriteLine("ThenByDescending");

            var thenByDescending = PeopleList.peoples
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.Age);

            foreach (var people in thenByDescending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ToLookUpLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("ToLookUp järgi reastamine");

            var toLookUp = PeopleList.peoples
                .ToLookup(x => x.Age);

            foreach (var people in toLookUp)
            {
                Console.WriteLine("Age group " + people.Key);

                foreach (People p in people)
                {
                    Console.WriteLine("Person name " + p.Name);
                }
            }
        }

        public static void JoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("InnerJoin in LINQ");

            var innerJoin = PeopleList.peoples
                .Join(GenderList.genderList,
                humans => humans.GenderId,
                gender => gender.Id,
                (humans, gender) => new
                {
                    Name = humans.Name,
                    Sex = gender.Sex
                });

            foreach (var people in innerJoin)
            {
                Console.WriteLine(people.Name + " " + people.Sex);
            }
        }

        public static void GroupJoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            var groupJoin = GenderList.genderList
                .GroupJoin(PeopleList.peoples,
                p => p.Id,
                g => g.GenderId,
                (p, peopleGroup) => new
                {
                    Humans = peopleGroup,
                    GenderFullName = p.Sex
                });

            foreach (var people in groupJoin)
            {
                Console.WriteLine(people.GenderFullName);

                foreach (var name in people.Humans)
                {
                    Console.WriteLine(name.Name);
                }
            }
        }

        public static void SelectLINQ()
        {
            Console.WriteLine("Select in LINQ");
            //teha iseseisvalt LINQ Select
            //otsida Internetist vastuseid
            //lõpus kasutada foreachi

            var selectLINQ = PeopleList.peoples
                .Select(p => new
                {
                    name = p.Name,
                    age = p.Age
                });

            foreach (var peopleName in selectLINQ)
            {
                Console.WriteLine(peopleName.name + " " + peopleName.age);
            }
        }

        public static void AllAndAnyLINQ()
        {
            Console.WriteLine("All LINQ");

            bool areAllPeopleTeenagers = PeopleList.peoples
                .All(x => x.Age > 18);
            //k]ik PeopleList-i all olevad isikud peavad olema alla 18 a vanused

            Console.WriteLine(areAllPeopleTeenagers);

            Console.WriteLine("Any LINQ");
            bool isAnyPersonTeenager = PeopleList.peoples
                .Any(x => x.Age > 18);
            //kasvõi üks  andmerida vastab tingimustele, siis tuelb vastus
            Console.WriteLine(isAnyPersonTeenager);
        }

        public static void ContainsLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Contains LINQ");

            //pärib, kas number 10 on numbrite seas
            //niimoodi saab iga numbriga teha
            // kui paneme nr 5, siis tuleb vastuseks true
            bool result = NumberList.numberList.Contains(5);

            Console.WriteLine(result);
        }

        public static void AggregateLINQ()
        {
            string commaSeparatedPersonNames = PeopleList.peoples
                .Aggregate<People, string>(
                "People names: ",
                (str, x) => str += x.Name + ", "
                );

            Console.WriteLine(commaSeparatedPersonNames);
        }

        public static void AvarageLINQ()
        {
            Console.WriteLine("Avarage LINQ");
            //teha Avarage LINQ
            //PeopleList Age kohta teha
            var avarageResult = PeopleList.peoples
                .Average(x => x.Age);

            Console.WriteLine(avarageResult);
        }

        public static void CountLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("LINQ Count");

            var count = PeopleList.peoples.Count();

            Console.WriteLine("Number of people " + count);
        }

        public static void MaxLINQ()
        {
            Console.WriteLine("Max LINQ");

            //var max = PeopleList.peoples.Max();

            //Console.WriteLine("People Id: {0}, Student name: {1}",
            //max.Id, max);
        }

        public static void SumLINQ()
        {
            Console.WriteLine("Sum LINQ");

            var total = NumberList.numberList.Sum();

            Console.WriteLine("Sum of even elements: " + total);
        }

        public static void FirstOrDefaultLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("First or Default");

            var firstOrDefault = NumberList.numberList.LastOrDefault();

            Console.WriteLine(firstOrDefault);
        }

        public static void LastOrDefault()
        {
            Console.WriteLine("Last or Default");

            var lastOrDefault = NumberList.numberList.LastOrDefault();

            Console.WriteLine(lastOrDefault);
        }

        public static void SingleOrDefault()
        {
            IList<int> oneElement = new List<int>() { 7 };

            Console.WriteLine("Single or Default");

            //singleOrDefault lubab ainult ühte elementi kasutada listis
            var singleOrDefault = oneElement.SingleOrDefault();

            Console.WriteLine(singleOrDefault);
        }

        public static void SequenceEqual()
        {
            Console.WriteLine("SequenceEqual LINQ");
            IList<string> stringsList1 = new List<string>()
            { "One", "Two", "Three", "Four", "Five"};

            IList<string> stringsList2 = new List<string>()
            { "One", "Two", "Three", "Four"};

            //see kontrollib, kas seal on väärtuseid või ei ole
            //kas seal on üks ühele olemas väärtused
            bool isEqual = stringsList1.SequenceEqual(stringsList2);

            Console.WriteLine(isEqual);
        }

        public static void ConcatLINQ()
        {

            Console.WriteLine("Concat LINQ");

            IList<int> collection1 = new List<int>() { 1, 2, 3 };
            IList<int> collection2 = new List<int>() { 4, 5, 6 };

            var collection3 = collection1.Concat(collection2);

            foreach (var item in collection3)
            {
                Console.WriteLine(item);
            }
        }

        public static void DefaultIfEmpty()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            IList<int> emptyList = new List<int>();

            Console.WriteLine("DefaultIfEmpty LINQ");

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty(100);

            Console.WriteLine("Count: " + newList1.Count());
            Console.WriteLine("Count: " + newList1.ElementAt(0));

            Console.WriteLine("Count: " + newList2.Count());
            Console.WriteLine("Count: " + newList2.ElementAt(0));
        }

        public static void EmptyRangeRepeat()
        {
            Console.WriteLine("EmptyRangeRepeat LINQ");

            var emptyColletion1 = Enumerable.Empty<string>();
            var emptyColletion2 = Enumerable.Empty<People>();

            Console.WriteLine("Type {0}" + emptyColletion1.GetType().Name);
            Console.WriteLine("Count: {0} " + emptyColletion1.Count());

            Console.WriteLine("Type {0}" + emptyColletion2.GetType().Name);
            Console.WriteLine("Count: {0} " + emptyColletion2.Count());

            var intCollection = Enumerable.Range(3, 9);
            Console.WriteLine("Total count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
            }

            var repeatCollection = Enumerable.Range(3, 9);
            Console.WriteLine("Total count: {0} ", intCollection.Count());

            for (int i = 0; i < repeatCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, repeatCollection.ElementAt(i));
            }
        }

        public static void Distinct()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three" };

            var distinct1 = PeopleList.peoples.Distinct();

            foreach (var str in distinct1)
            {
                Console.WriteLine("Distinct " + str.Name);
            }

            var distinct2 = strList.Distinct();

            foreach (var item in distinct2)
            {
                Console.WriteLine("Distinct 2: " + item);
            }


        }

        public static void Except()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);

            foreach (var item in result)
            {
                Console.WriteLine("Except " + item);
            }
        }

        public static void Intersect()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Intersect(strList2);

            foreach (var item in result)
            {
                Console.WriteLine("Intersect: " + item);
            }

        }

        public static void Union()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };


            var result = strList1.Union(strList2);

            foreach (var item in result)
            {
                Console.WriteLine("Union: " + item);
            }
        }
    
        public static void Skip()
        {
           Console.BackgroundColor = ConsoleColor.Black;
            
            Console.WriteLine("---------Skip---------");
            var skip = PeopleList.peoples.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("----------SkipWhile-------------");
            var skipWhile = PeopleList.peoples.SkipWhile(s => s.Name.Length < 4);
      
            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.Name);
            }
        }
  
        public static void TakeAndTakeWhile()
        {
            IList<string> str = new List<string>() { "Car", "Bus", "Truck", "Airplane" };
            var res = str.TakeWhile(s => s.Length < 4);
            foreach (var arr in res)
                Console.WriteLine(arr);

            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Take(2);

            foreach (var arr in newList)
                Console.WriteLine(str);

        }
        
    
    
    }
       
}