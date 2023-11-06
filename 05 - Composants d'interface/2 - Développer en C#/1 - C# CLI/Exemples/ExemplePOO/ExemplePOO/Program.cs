namespace ExemplePOO
{
    class Program
    {
        static void Main()
        {
            Personnes p = new Personnes();
            p.SetIdClass(1);
            p.IdPersonne = 1;
            int a = p.GetIdClass();
            int b = p.IdPersonne;
            Personnes p1 = new Personnes(10);
            Personnes p2 = new Personnes("test");
            Personnes p3 = new Personnes("test",2,4);
            Console.WriteLine(   p.ToString());
            Console.WriteLine(   p1.ToString());
            Console.WriteLine(   p2.ToString());
            Console.WriteLine(   p3.ToString());
        }
    }
}