using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////// VARIABLES \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //EXERCICE 1

            /*Console.WriteLine("Tapez votre nom");
            string nom;
            nom=Console.ReadLine();
            Console.WriteLine("Votre nom est "+nom);*/

            //EXERCICE 2

            /*Console.WriteLine("Tapez un nombre");
            string nombre;
            if (int.tryParse(Console.ReadLine(),nombre)
            Console.WriteLine("Votre nombre est " + nombre);
            else
            Console.WriteLine("Ce n'est pas un nombre ");
            */

            //EXERCICE 3
            //string nb1;
            //string nb2;
            //int somme;
            //Console.WriteLine("Tapez un nombre");
            //nb1 = Console.ReadLine();
            //Console.WriteLine("Tapez un 2e nombre");
            //nb2 = Console.ReadLine();
            //somme = int.Parse(nb1) + int.Parse(nb2);
            //Console.WriteLine("Votre nombre est " + somme);

            //EXERCICE 4

            /*Console.WriteLine("Tapez un float");
            double nom;
            nom = float.Parse(Console.ReadLine());
            Console.WriteLine("Votre nombre est " + nom);*/

            //EXERCICE 5

            /*string nb1;
            string nb2;
            string nb3;
            double moy;
            Console.WriteLine("Tapez un nombre");
            nb1 = Console.ReadLine();
            Console.WriteLine("Tapez un 2e nombre");
            nb2 = Console.ReadLine();
            Console.WriteLine("Tapez un 3e nombre");
            nb3 = Console.ReadLine();
            moy =(float.Parse(nb1) + float.Parse(nb2)+ float.Parse(nb3))/3;
            Console.WriteLine(moy);*/

            //EXERCICE 6

            /*double l;
            double L;
            double surface;
            Console.WriteLine("largeur");
            l = float.Parse(Console.ReadLine());
            Console.WriteLine("longueur");
            L = float.Parse(Console.ReadLine());
            surface = l * L;
            Console.WriteLine("La surface du rectangle est : " + surface);*/

            //EXERCICE 7

            /*char c='a';
            Console.WriteLine("caractère : " + c + " Unicode : " + (int)c);*/

            //EXERCICE 8

            /*string l;
            Console.WriteLine("chaine de caractère");
            l = Console.ReadLine();
            Console.WriteLine(l.ToUpper());*/

            ////////////////////////////////////////////// Opérateurs Conversions \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //EXERCICE 1

            /*char l;
            char ll;
            Console.WriteLine("caractère");
            l = char.Parse(Console.ReadLine());
            ll = (char) ((int)l + 1);
            Console.WriteLine(ll);*/

            //EXERCICE 2

            /*char a = '0';
            char b = '1';
            char c= '2';
            char d = '3';
            char e = '4';
            char f = '5';
            char g = '6';
            char h = '7';
            char i = '8';
            char j = '9';
            Console.WriteLine("0 : "+(int)a);
            Console.WriteLine("1 : " + (int)b);
            Console.WriteLine("2 : " + (int)c);
            Console.WriteLine("3 : " + (int)d);
            Console.WriteLine("4 : " + (int)e);
            Console.WriteLine("5 : " + (int)f);
            Console.WriteLine("6 : " + (int)g);
            Console.WriteLine("7 : " + (int)h);
            Console.WriteLine("8 : " + (int)i);
            Console.WriteLine("9 : " + (int)j);*/

            //EXERCICE 3

            /*float M = float.Parse(Console.ReadLine());
            float k = float.Parse(Console.ReadLine());
            Console.WriteLine((int)(M / k));*/

            //EXERCICE 4

            ////////////////////////////////////////////// Traitements Conditionnels \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //EXERCICE 1

            /*Console.WriteLine("Votre age ?");
            int age = int.Parse(Console.ReadLine());
            if (age>=18)
            {
                Console.WriteLine("Vous êtes majeur");
            }
            else
            {
                Console.WriteLine("Vous êtes mineur (UNE MINE)");
            }*/

            //EXERCICE 2

            /*Console.WriteLine("Donnez une valeur");
            int nb = int.Parse(Console.ReadLine());
            if (nb<0)
            {
                nb = nb * -1;
            //nb*= -1;
            }
            Console.WriteLine(nb);*/

            //EXERCICE 3

            /*Console.WriteLine("Donnez une note");
            int note = int.Parse(Console.ReadLine());
            if (note<8)
            {
                Console.WriteLine("ajourné");
            }else if(note<10){
                Console.WriteLine("rattrapage");
            }
            else
            {
                Console.WriteLine("admis");
            }*/

            //EXERCICE 4

            /*Console.WriteLine("Donnez un montant");
            float montant = float.Parse(Console.ReadLine());
            float franchise =(float) (montant * 0.1);
            if (franchise<4000)
            {
                Console.WriteLine("franchise : "+franchise);
            }
            else
            {
                Console.WriteLine("Pas de franchise");
            }*/

            //EXERCICE 5

            /*Console.WriteLine("Donnez une valeur");
            int v1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une valeur");
            int v2 = int.Parse(Console.ReadLine());
            if (v1!=v2)
            {
                Console.WriteLine("2 valeurs distinctes");
            }
            else
            {
                Console.WriteLine("1 valeur distincte");
            }*/

            //EXERCICE 6

            /*Console.WriteLine("Donnez une valeur");
            int v1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une valeur");
            int v2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une valeur");
            int v3 = int.Parse(Console.ReadLine());

            if (v1<v2 && v1<v3)
            {
                Console.WriteLine(v1+" est la plus petite valeur");
            }
            else if(v2<v3 && v2<v1)
            {
                Console.WriteLine(v2+" est la plus petite valeur");
            }
            else
            {
                Console.WriteLine(v3+" est la plus petite valeur");
            }*/

            //EXERCICE 7

            /*Console.WriteLine("Donnez une valeur");
            int v1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une valeur");
            int v2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez un opérateur (+,-,*,/)");
            char op = char.Parse(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine(v1 + v2);
                    break;
                case '-':

                    Console.WriteLine(v1 - v2);
                    break;
                case '*':

                    Console.WriteLine(v1 * v2);
                    break;
                case '/':
                    
                    Console.WriteLine(((float)v1 / (float)v2));
                    break;
                default:
                    Console.WriteLine("Erreur d'opérateur");
                    break;
            }*/

            //EXERCICE 8

            /*Console.WriteLine("Donnez la valeur de la ligne");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la colonne");
            int j = int.Parse(Console.ReadLine());
            if (i%2==1 && j%2==1)
            {
                Console.WriteLine("case noir");
            }
            else
            {
                Console.WriteLine("case blanche");
            }*/

            //EXERCICE 9

            /*Console.WriteLine("Donnez la valeur de la ligne");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la colonne");
            int j = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la ligne");
            int i2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la colonne");
            int j2 = int.Parse(Console.ReadLine());

            if ((i+2==i2 && j+1==j2) || (i + 2 == i2 && j - 1 == j2) || (i - 2 == i2 && j + 1 == j2) || (i - 2 == i2 && j - 1 == j2))
            {
                Console.WriteLine("Le cavalier peut se déplacer");
            }
            else
            {
                Console.WriteLine("Le cavalier ne peut pas se déplacer");
            }*/

            //EXERCICE 10

            /*Console.WriteLine("Quelle pièce ?");
            Console.WriteLine("0=Cavalier");
            Console.WriteLine("1=Tour");
            Console.WriteLine("2=Fou");
            Console.WriteLine("3=Dame");
            Console.WriteLine("4=Roi");
            int piece = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la ligne");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la colonne");
            int j = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la ligne");
            int i2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez la valeur de la colonne");
            int j2 = int.Parse(Console.ReadLine());
            switch (piece)
            {
                case 0:
                    if ((i + 2 == i2 && j + 1 == j2) || (i + 2 == i2 && j - 1 == j2) || (i - 2 == i2 && j + 1 == j2) || (i - 2 == i2 && j - 1 == j2))
                    {
                        Console.WriteLine("Le cavalier peut se déplacer");
                    }
                    else
                    {
                        Console.WriteLine("Le cavalier ne peut pas se déplacer");
                    }
                    break;
                case 1:
                    if ((i==i2 && j!=j2) || (i!=i2 && j==j2))
                    {
                        Console.WriteLine("La tour peut se déplacer");
                    }
                    else
                    {
                        Console.WriteLine("La tour ne peut pas se déplacer");
                    }
                    break;
                case 2:
                    if (Math.Abs(i-i2)==Math.Abs(j-j2))
                    {
                        Console.WriteLine("Le fou peut se déplacer");
                    }
                    else
                    {
                        Console.WriteLine("Le fou ne peut pas se déplacer");
                    }
                    break;
                case 3:
                    if ((Math.Abs(i - i2) == Math.Abs(j - j2)) || (i == i2 && j != j2) || (i != i2 && j == j2))
                    {
                        Console.WriteLine("La dame peut se déplacer");
                    }
                    else
                    {
                        Console.WriteLine("La dame ne peut pas se déplacer");
                    }
                    break;
                case 4:
                    if ((i-1==i2 && j-1==j2) || (i - 1 == i2 && j == j2) || (i - 1 == i2 && j + 1 == j2) || (i== i2 && j - 1 == j2) || (i == i2 && j + 1 == j2) || (i + 1 == i2 && j - 1 == j2) || (i + 1 == i2 && j== j2) || (i + 1 == i2 && j + 1 == j2))
                    {
                        Console.WriteLine("Le roi peut se déplacer");
                    }
                    else
                    {
                        Console.WriteLine("Le roi ne peut pas se déplacer");
                    }
                    break;
            }*/

            //EXERCICE 11

            /*Console.WriteLine("Donnez heures de début");
            int heureD = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez minutes de début");
            int minD = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez heures de fin");
            int heureF = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez minutes de fin");
            int minF = int.Parse(Console.ReadLine());

            if ((heureF<heureD) || (heureF==heureD && minF<minD))
            {
                Console.WriteLine("Erreur lors de la saisie des heures (date de fin inférieur à la date de début)");
            }
            else
            {
                if (heureD==heureF)
                {
                    Console.WriteLine("Temps écoulés : "+(minF-minD) +" min");
                }
                else
                {
                    if (minF>=minD)
                    {
                        Console.WriteLine("Temps écoulés : " + (heureF-heureD) + "h"+(minF-minD)+" min");
                    }
                    else
                    {
                        //10h30 11h29 ou 10h30 12h29
                        int diff=60 - minD + minF;
                        //Si une heure ne sait pas encore écoulée
                        if (heureD+1 == heureF)
                        {
                            Console.WriteLine("Temps écoulés : 00h" + diff + " min");
                        }
                        else // Si une heure s'est déja écoulée (on retire une heure à la différence d'heure car la suivante ne s'est pas écoulée)
                        {
                            Console.WriteLine("Temps écoulés : " + ((heureF - heureD)-1) + "h" + diff + " min");
                        }
                        
                    }
                }
            }*/

            //EXERCICE 12

            /*Console.WriteLine("Donnez un jour");
            int jour = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez un mois");
            int mois = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une année");
            int annee = int.Parse(Console.ReadLine());

            bool bissex;
            //Check annee bissextile
            if (annee%4==0)
            {
                if (annee % 100 == 0)
                {
                    if (annee%400 == 0)
                    {
                        bissex = true;
                    }
                    else
                    {
                        bissex = false;
                    }
                }
                else
                {
                    bissex = true;
                }
            }
            else
            {
                bissex = false;
            }

            if (mois==2)
            {
                if (jour==28)
                {
                    if (bissex)
                    {
                        Console.WriteLine("Jour suivant : "+ (jour+1)+"/"+mois+"/"+annee);
                    }
                    else
                    {
                        Console.WriteLine("Jour suivant : 1/" + (mois+1) + "/" + annee);
                    }
                }
                else
                {
                    if(jour == 29)
                    {
                        Console.WriteLine("Jour suivant : 1/" + (mois + 1) + "/" + annee);
                    }
                    else
                    {
                        Console.WriteLine("Jour suivant : " + (jour + 1) + "/" + mois + "/" + annee);
                    }
                }
            }
            else
            {
                //mois de 31 jours
                if(mois==1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12)
                {
                    if (jour==31)
                    {
                        if (mois==12)
                        {
                            Console.WriteLine("Jour suivant : 1/1/" + (annee + 1));
                        }
                        else
                        {
                            Console.WriteLine("Jour suivant : 1/" + (mois+1) + "/" + annee);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jour suivant : " + (jour + 1) + "/" + mois + "/" + annee);
                    }
                }
                else //mois de 30 jours
                {
                    if (jour==30)
                    {
                        Console.WriteLine("Jour suivant : 1/" + (mois + 1) + "/" + annee);
                    }
                    else
                    {
                        Console.WriteLine("Jour suivant : " + (jour + 1) + "/" + mois + "/" + annee);
                    }
                }
                
            }*/

            //Exercice 13

            /*Console.WriteLine("Donnez une borne a");
            int num1;
            String borneA = Console.ReadLine();
            Console.WriteLine("Donnez une borne b");
            int num2;
            String borneB = Console.ReadLine();

            if (int.TryParse(borneA,out num1)==false | int.TryParse(borneB, out num2)==false)
            {
                Console.WriteLine("Erreur de saisie");
            }
            else
            {
                if (num1>num2)
                {
                    Console.WriteLine("La borne A doit être inférieur à la borne B");
                }
                else
                {
                    Console.WriteLine("les bornes sont bien saisie");
                }
            }*/

            //EXERCICE 14

            /*Console.WriteLine("Donnez une borne a");
            int num1;
            String borneA = Console.ReadLine();
            Console.WriteLine("Donnez une borne b");
            int num2;
            String borneB = Console.ReadLine();

            if (int.TryParse(borneA, out num1) == false | int.TryParse(borneB, out num2) == false)
            {
                Console.WriteLine("Erreur de saisie");
            }
            else
            {
                if (num1 > num2)
                {
                    Console.WriteLine("La borne A doit être inférieur à la borne B");
                }
                else
                {
                    Console.WriteLine("les bornes sont bien saisie");
                }
            }
            Console.WriteLine("Donnez une valeur");
            int x = int.Parse(Console.ReadLine());
            if (x>=num1 && x<=num2)
            {
                Console.WriteLine("La valeur est dans les bornes");
            }
            else
            {
                Console.WriteLine("La valeur n'est pas dans les bornes");
            }*/

            //EXERCICE 15

            /*Console.WriteLine("Donnez xHautGauche");
            int xHautGauche;
            String xh = Console.ReadLine();

            Console.WriteLine("Donnez yHautGauche");
            int yHautGauche;
            String yh = Console.ReadLine();

            Console.WriteLine("Donnez xBasDroite");
            int xBasDroite;
            String xb = Console.ReadLine();

            Console.WriteLine("Donnez yBasDroite");
            int yBasDroite;
            String yb = Console.ReadLine();

            if (int.TryParse(xh, out xHautGauche) == false | int.TryParse(yh, out yHautGauche) == false | int.TryParse(xb, out xBasDroite) == false | int.TryParse(yb, out yBasDroite) == false)
            {
                Console.WriteLine("Erreur de saisie");
            }*/

            //EXERCICE 16
            /*Console.WriteLine("Donnez xHautGauche");
            int xHautGauche;
            String xh = Console.ReadLine();

            Console.WriteLine("Donnez yHautGauche");
            int yHautGauche;
            String yh = Console.ReadLine();

            Console.WriteLine("Donnez xBasDroite");
            int xBasDroite;
            String xb = Console.ReadLine();

            Console.WriteLine("Donnez yBasDroite");
            int yBasDroite;
            String yb = Console.ReadLine();

            Console.WriteLine("Donnez une coordonnée x");
            int x =int.Parse(Console.ReadLine());

            Console.WriteLine("Donnez une coordonnée y");
            int y = int.Parse(Console.ReadLine());

            if (int.TryParse(xh, out xHautGauche) == false | int.TryParse(yh, out yHautGauche) == false | int.TryParse(xb, out xBasDroite) == false | int.TryParse(yb, out yBasDroite) == false)
            {
                Console.WriteLine("Erreur de saisie");
            }
            if (x>xHautGauche && x<xBasDroite && y>yHautGauche && y<yBasDroite)
            {
                Console.WriteLine("Le point se trouve dans le rectangle");
            }
            else
            {
                Console.WriteLine("Le point ne se trouve pas dans le rectangle");
            }*/

            ////////////////////////////////////////////// Boucles \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //Exercice 1

            /*int a = 1, b = 0, n = 5;
            while (a <= n)
                b += a++;
            Console.WriteLine(a + " , " + b);*/

            //Note : 6 , 15
            /* 
             * 2 , 1
             * 3 , 3
             * 4 , 6
             * 5 , 10
             * 6 , 15
             */

            //EXERCICE 2

            /*int a = 0, b = 0, c = 0, d = 3, m = 3, n = 4;
            for (a = 0; a < m; a++)
            {
                d = 0;
                for (b = 0; b < n; b++)
                    d += b;
                c += d;
            }
            Console.WriteLine(a + " , " + b + " , " + c + " , " + d + " . ");*/
            //Note : a=3 , b=4 , c=18 , d=6


            //EXERCICE 3

            /*int a, b, c, d;
            a = 1; b = 2;
            c = a / b;
            d = (a == b) ? 3 : 4;
            Console.WriteLine(c + " , " + d + " . ");
            a = ++b;
            b %= 3;
            Console.WriteLine(a + " , " + b + " . ");
            b = 1;
            for (a = 0; a <= 10; a++)
                c = ++b;
            Console.WriteLine(a + " , " + b + " , " + c + " , " + d + " . ");*/

            //Note : 1- c=0 , d=4
            // 2- a=3 , b=0
            // 3- a=11 , b=12 , c=12, d=4

            //EXERCICE 4

            /*Console.WriteLine("Donnez une valeur numérique");
            int nb = int.Parse(Console.ReadLine());

            for (int i = nb; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            int i = nb;
            while (i >= 0)
            {
                Console.WriteLine(i);
                i--;
            }

            int i = nb;
            do
            {
                Console.WriteLine(i);
                i--;
            } while (i >= 0);*/

            //EXERCICE 5

            /*Console.WriteLine("Donnez une valeur numérique");
            int nb = int.Parse(Console.ReadLine());
            int fact = 1;

            for (int i = 0; i <= nb; i++)
            {
                fact *= i;
            }
            Console.WriteLine(fact);

            int i = 1;
            while (i <= nb)
            {
                fact *= i;
                i++;
            }
            Console.WriteLine(fact);

            int i = 1;
            do
            {
                fact *= i;
                i++;
            } while (i <= nb);
            Console.WriteLine(fact);*/

            //EXERCICE 6

            /*Console.WriteLine("Donnez une valeur numérique");
            int nb = int.Parse(Console.ReadLine());

            for (int i=0;i<=10;i++)
            {
                Console.WriteLine(i+" * "+nb+" = "+(nb*i));
            }*/

            //EXERCICE 7

            /*Console.Write("*");
            for (int i = 0; i <= 10; i++)
            {
                Console.Write("   " + i);
            }

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine();
                Console.Write(i);
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write("   " + i * j);
                }
            }*/

            //Exercice 8

            /*Console.WriteLine("Donnez une valeur numérique");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Donnez une 2e valeur numérique");
            int n = int.Parse(Console.ReadLine());
            int total=1;
            if (n < 0)
            {
                Console.WriteLine("n négatif");
            }
            else
            {
                for (int i = 1; i < n; i++)
                {
                    total *= b;
                }
            }
            Console.WriteLine(total);*/

            //Exercice 9

            /*Console.WriteLine("Donnez une valeur numérique");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write("X ");
                }
            }*/


            //Exercice 10

            /*String saisie="=";
            float nb;
            float total = 0;
            bool init = true;
            do
            {
                if (init)
                {
                    Console.WriteLine("Saisissez un opérande");
                    saisie = Console.ReadLine();
                    total = float.Parse(saisie);
                    
                }
                
                if (saisie != "=")
                {
                    if (init)
                    {
                        Console.WriteLine("Saisissez un opérateur (+,-,*,/)");
                        saisie = Console.ReadLine();
                        init = false;
                    }
                    
                    Console.WriteLine("Saisissez un opérande");
                    nb = float.Parse(Console.ReadLine());
                    switch (saisie)
                    {
                        case "+":
                            total += nb;
                            break;
                        case "-":
                            total -= nb;
                            break;
                        case "*":
                            total *= nb;
                            break;
                        case "/":
                            if (nb==0)
                            {
                                Console.WriteLine("Division par 0");
                            }
                            else
                            {
                                total /= nb;
                            }
                            break;
                    }
                    Console.WriteLine("Total = "+total);
                    Console.WriteLine("Saisissez un opérateur (+,-,*,/) *** = pour terminer ***");
                    saisie = Console.ReadLine();
                }
            } while (saisie != "=");
            Console.WriteLine("Fin du calcul,total = " + total);*/

            //Exercice 11

            /*String saisie = "=";
            float nb;
            float total = 0;
            bool init = true;
            float tempTotal;
            do
            {
                if (init)
                {
                    Console.WriteLine("Saisissez un opérande");
                    saisie = Console.ReadLine();
                    total = float.Parse(saisie);

                }

                if (saisie != "=")
                {
                    if (init)
                    {
                        Console.WriteLine("Saisissez un opérateur (+,-,*,/,$)");
                        saisie = Console.ReadLine();
                        init = false;
                    }

                    Console.WriteLine("Saisissez un opérande");
                    nb = float.Parse(Console.ReadLine());
                    switch (saisie)
                    {
                        case "+":
                            total += nb;
                            break;
                        case "-":
                            total -= nb;
                            break;
                        case "*":
                            total *= nb;
                            break;
                        case "/":
                            if (nb == 0)
                            {
                                Console.WriteLine("Division par 0");
                            }
                            else
                            {
                                total /= nb;
                            }
                            break;
                        case "$":
                            tempTotal = total;
                            for (int i=0;i<nb;i++)
                            {
                                total += tempTotal * nb;
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Total = " + total);
                    Console.WriteLine("Saisissez un opérateur (+,-,*,/) *** = pour terminer ***");
                    saisie = Console.ReadLine();
                }
            } while (saisie != "=");
            Console.WriteLine("Fin du calcul,total = " + total);*/

            //Exercice 12

            /*String saisie;
            double nb;
            double total;
            double tempTotal;

            //Initialisation de la calculatrice
            Console.WriteLine("Saisissez un opérande");
            saisie = Console.ReadLine();
            total = double.Parse(saisie);
            Console.WriteLine("Saisissez un opérateur (+,-,*,/,$,%,!)");
            saisie = Console.ReadLine();

            do
            {
                if (saisie != "=")
                {
                    //opérations unaires
                    if (saisie=="%" || saisie=="!")
                    {
                        nb = 0;
                    }
                    else
                    {
                        Console.WriteLine("Saisissez un opérande");
                        nb = double.Parse(Console.ReadLine());
                    }

                    switch (saisie)
                    {
                        case "+":
                            total += nb;
                            break;
                        case "-":
                            total -= nb;
                            break;
                        case "*":
                            total *= nb;
                            break;
                        case "/":
                            if (nb == 0)
                            {
                                Console.WriteLine("Division par 0");
                            }
                            else
                            {
                                total /= nb;
                            }
                            break;
                        case "$":
                            tempTotal = total;
                            for (int i = 0; i < nb; i++)
                            {
                                total += tempTotal * nb;
                            }
                            break;
                        case "%":
                            total = Math.Sqrt(total);
                            break;
                        case "!":
                            tempTotal = total;
                            total = 0;
                            for (int i=0;i<=tempTotal;i++)
                            {
                                total += i;
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Total = " + total);
                    Console.WriteLine("Saisissez un opérateur (+,-,*,/) *** = pour terminer ***");
                    saisie = Console.ReadLine();
                }
            } while (saisie != "=");
            Console.WriteLine("Fin du calcul,total = " + total);*/

            static int demanderEntierPositif(string texte)
            {
                int valeur;
                bool conversionReussie;
                do
                {
                    Console.WriteLine(texte);
                    conversionReussie = int.TryParse(Console.ReadLine(), out valeur);

                } while (!conversionReussie || valeur < 0);
                return valeur;
            }

            static double demanderDouble(string texte)
            {
                double nb;
                bool ok;
                do
                {
                    Console.Write(texte);
                    ok = double.TryParse(Console.ReadLine(), out nb);
                } while (!ok);
                return nb;
            }

            static double demanderDoubleNonNull(string texte)
            {
                double n;
                bool conversionReussie;
                do
                {
                    Console.WriteLine(texte);
                    conversionReussie = double.TryParse(Console.ReadLine(), out n);
                } while (!conversionReussie || n != 0);
                return n;
            }

            static char demanderOperateur()
            {
                bool ok = true;
                char op;
                bool condition;

                do
                {
                    Console.Write("Entrez un opérateur +,-,*,/,$,!,V : ");
                    ok = char.TryParse(Console.ReadLine(), out op);
                    condition = !ok || (op != '+' && op != '-' && op != '*' && op != '/' && op != '$' && op != '!' && op != 'V' && op != 'v');
                    if (condition)
                        Console.WriteLine("Saisie incorrecte.");

                } while (condition);
                return char.ToUpper(op);
            }

            static double calcul(double valeur,char operateur)
            {
                double nb=1;
                switch (operateur)
                {
                    case ('V'):
                        nb =Math.Sqrt(valeur);
                        break;
                    case ('!'):
                        for (int x = 1; x <= valeur; x++)
                        {
                            nb *= x;
                        }
                        break;
                    default:
                        break;
                }
                return nb;
            }

            static double calculSimple(double valeur1, char operateur, double valeur2)
            {
                double resultat=0;
                switch (operateur)
                {
                    case '+':
                        resultat = valeur1 + valeur2;
                        break;
                    case '-':
                        resultat = valeur1 - valeur2;
                        break;
                    case '*':
                        resultat = valeur1 * valeur2;
                        break;
                    case '/':
                        resultat = valeur1 / valeur2;
                        break;
                    case '$':
                        resultat = Math.Pow(valeur1, valeur2);
                        break;
                    default:
                        break;
                }
                return resultat;
            }

            //double value1, value2;
            //char operateur;

            //value1 = demanderDouble("Donnez un double");
            //do
            //{
            //    operateur = demanderOperateur();
            //    switch (operateur)
            //    {
            //        case '-':
            //        case '+':
            //        case '*':
            //            value2 = demanderDouble("Donnez un double");
            //            value1 = calculSimple(value1,operateur, value2);
            //            break;
            //        case '/':
            //            value2 = demanderDoubleNonNull("Donnez un double non null");
            //            value1 = calculSimple(value1,operateur,value2);
            //            break;
            //        case '$':
            //            value2 = demanderEntierPositif("Donnez un entier positif");
            //            value1 = calculSimple(value1, operateur ,value2);
            //            break;
            //        case '!':
            //            if (value1 % 1 == 0 && value1 > 0) // On vérifie que value1 est un Entier et qu'il est positif.
            //            {
            //                value1 = calcul(value1, operateur);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Calcul impossible !");
            //            }
            //            break;
            //        case 'V':
            //            if (value1 > 0) // On vérifie que value1 est positif.
            //            {
            //                value1 = calcul(value1, operateur);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Calcul impossible !");
            //            }
            //            break;
            //        case '=':
            //            break;
            //        default:
            //            Console.WriteLine("Opérateur incorrect.");
            //            break;
            //    }

            //    Console.WriteLine("Résultat = " + value1);
            //    if (operateur == '=')
            //    {
            //        Console.WriteLine("Merci d'avoir utiliser cette calculatrice made in AFPA.");
            //    }
            //} while (operateur != '=');

            ////////////////////////////////////////////// Chaine de caractères \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //Exercice 1
            /*String phrase = "Les framboises sont perchées sur le tabouret de mon grand-père.";

            for (int i=0;i<phrase.Length;i++)
            {
                Console.Write(phrase.Substring(i,1));
            }*/

            //Exercice 2

            /*Console.WriteLine("Entrez une chaine de caractère");
            String t = Console.ReadLine();
            Console.WriteLine("Entrez un indice i");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez un indice j");
            int j = int.Parse(Console.ReadLine());
            String t2="";
            for (int k=i;k<=j;k++)
            {
                t2 = t2 + t.Substring(k,1);
            }
            Console.WriteLine(t2);*/

            //Exercice 3

            /*Console.WriteLine("Entrez une chaine de caractère");
            String t = Console.ReadLine();
            Console.WriteLine("Entrez un indice i");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez un indice j");
            int j = int.Parse(Console.ReadLine());
            String t2 ="";
            
            t2=t.Insert(0,t.Substring(i,(j-i+1))) ;
            t2 = t2.Substring(0, (j - i + 1)); ;
            String t2 = "";

            t2 = t.Insert(0, t.Substring(i, (j - i + 1)));
            t2 = t2.Substring(0, (j - i + 1));
            Console.WriteLine(t2);*/

            //EXERCICE 4

            /*Console.WriteLine("Entrez une chaine de caractère");
            String t = Console.ReadLine();
            Console.WriteLine("Entrez un caractère");
            String a = Console.ReadLine();
            Console.WriteLine("Entrez un caractère");
            String b = Console.ReadLine();
            String t2=t.Replace(a,b) ;
            Console.WriteLine(t2);*/

            //Exercice 5

            //Console.WriteLine("Entrez une chaine de caractère");
            //String t = Console.ReadLine();
            //Console.WriteLine("Entrez un caractère");
            //String a = Console.ReadLine();
            //Console.WriteLine("Entrez un caractère");
            //String b = Console.ReadLine();
            //String t2="";
            //String c;
            //for (int i=0;i<t.Length; i++)
            //{
            //    c=t.Substring(i,1);
            //    if (c==a)
            //    {
            //        t2 = t2 + b;
            //    }
            //    else
            //    {
            //        t2 = t2 + c;
            //    }
            //}
            //Console.WriteLine(t2);


            //EXERCICE 6

            /*Console.WriteLine("Entrez un nom de fichier");
            String t = Console.ReadLine();
            int i=t.LastIndexOf(".");
            Console.WriteLine("Nom du fichier : " + t.Substring(0, i));
            Console.WriteLine("Nom de l'extension : " + t.Substring(i+1));*/

            //EXERCICE 7

            //Console.WriteLine("Entrez une expression arithmétique");
            //String t = Console.ReadLine();
            //String c;
            //int countOuv = 0;
            //int countFer = 0;
            //String erreur =  "bien";
            /*for (int i = 0; i < t.Length; i++)
            {
                c = t.Substring(i, 1);
                if (c == "(")
                {
                    countOuv++;
                }
                else if (c == ")")
                {
                    countFer++;
                }
                if (countOuv < countFer)
                {
                    erreur = "mal";
                }
            }
            if (countFer!=countOuv)
            {
                erreur = "mal";
            }
            Console.WriteLine("L'expression est "+erreur+" parenthésée");*/

            //int i = 0;
            //do
            //{
            //    c = t.Substring(i, 1);
            //    if (c == "(")
            //    {
            //        countOuv++;
            //    }
            //    else if (c == ")")
            //    {
            //        countFer++;
            //    }
            //    if (countOuv < countFer)
            //    {
            //        erreur = "mal";
            //    }
            //    i++;
            //} while (i<t.Length && erreur=="bien");
            //if (countFer!=countOuv)
            //{
            //    erreur = "mal";
            //}
            //Console.WriteLine("L'expression est " + erreur + " parenthésée");

            ////////////////////////////////////////////// Tableaux \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            //Exercice 1

            /*char[] c = new char[4];
            c[0] = 'a';
            c[3] = 'J';
            c[2] = 'k';
            c[1] = 'R';
            for (int k = 0; k < 4; k++)
                Console.WriteLine(c[k]);
            for (int k = 0; k < 4; k++)
                c[k]++;
            foreach (char i in c)
                Console.WriteLine(i);

            // Note : a R k J , b S l K*/

            //Exercice 2

            /*int[] k;
            k = new int[10];
            k[0] = 1;
            for (int i = 1; i < 10; i++)
                k[i] = 0;
            for (int j = 1; j <= 3; j++)
                for (int i = 1; i < 10; i++)
                    k[i] += k[i - 1];
            foreach (int i in k)
                Console.WriteLine(i);

            // Note : 1 3 6 10 15 21 28 36 45 55*/

            //EXERCICE 3 

            /*int[] k;
            k = new int[10];
            k[0] = 1;
            k[1] = 1;
            for (int i = 2; i < 10; i++)
                k[i] = 0;
            for (int j = 1; j <= 3; j++)
                for (int i = 1; i < 10; i++)
                    k[i] += k[i - 1];
            foreach (int p in k)
                Console.WriteLine(p);

            //Note : 1 4 9 16 25 36 49 64 81 100*/

            //Exercice 4

            /*int[] T = new int[10] {1,2,3,4,5,6,7,8,9,10};
            foreach (int p in T)
                Console.WriteLine(p);*/

            //Exercice 5
            /*int[] T = new int[10];
            for (int i =0;i<T.Length;i++)
            {
                T[i] = i + 1;
            }
            foreach (int p in T)
                Console.WriteLine(p);*/

            //Exercice 6

            /*int[] T = new int[10];
            int somme = 0;
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = i + 1;
            }
            foreach (int p in T)
                somme+=p;
            Console.WriteLine(somme);*/

            //Exercice 7

            /*int[] T = new int[10];
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = i + 1;
            }
            Console.WriteLine("Donnez une valeur");
            int t=int.Parse(Console.ReadLine());

            Console.WriteLine(Array.Exists(T, elt=> elt==t));*/

            //EXERCICE 8

            //int[] T = new int[10];
            //int[] T2 = new int[10];
            //for (int i = 0; i < T.Length; i++)
            //{
            //    T[i] = i + 1;
            //}
            //for (int i = 0; i < T2.Length; i++)
            //{
            //    if (i+1>= T.Length)
            //    {
            //        T2[i] = T[(T.Length - 1) - i];
            //    }
            //    else
            //    {
            //        T2[i] = T[i + 1];
            //    } 
            //}
            //foreach (int elt in T2)
            //    Console.Write(elt);



            //int nb = 4;
            //int[] t = new int[10];
            //int[] tt = new int[10];
            //for (int i = 0; i < t.Length; i++)
            //{
            //    t[i] = i + 1;
            //}

            //for (int i = 0; i < t.Length - nb; i++)
            //{
            //    tt[i] = t[i + nb];
            //}
            //for (int i = t.Length - nb; i < t.Length; i++)
            //{
            //    tt[i] = t[i - (t.Length - nb)];
            //}

            //foreach (var elem in t)
            //{
            //    Console.Write(elem);
            //}
            //Console.WriteLine();
            //foreach (var elem in tt)
            //{
            //    Console.Write(elem);
            //}

            //Exercice 9

            //int[] t = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int temp;
            //int n = 2;


            //do
            //{

            //    temp = t[t.Length - 1];
            //    for (int i = t.Length - 1; i > 0; i--)
            //    {
            //        t[i] = t[i - 1];
            //    }
            //    t[0] = temp;
            //    n--;
            //} while (n > 0);



            //foreach (var elem in t)
            //{
            //    Console.Write(elem);
            //}
            //Console.WriteLine();


            //Exercice 10

            //int[] T = new int[10];
            //int temp;
            //for (int i = 0; i < T.Length; i++)
            //{
            //    T[i] = i + 1;
            //}

            //for (int i = 0; i < T.Length/2; i++)
            //{
            //    temp=T[i];
            //    T[i] = T[(T.Length-1)-i];
            //    T[(T.Length - 1) - i] =temp;
            //}

            //foreach (var elem in T)
            //{
            //    Console.Write(elem);
            //}

            //Exercice 11

            //int[] T = new int[20];
            //for (int i=0;i<T.Length;i++)
            //{
            //    T[i] = (i * i) % 17;
            //}
            //foreach (var elem in T)
            //{
            //    Console.WriteLine(elem);
            //}

            //Exercice 12

            //int[] T = new int[20];

            //for (int i = 0; i < T.Length; i++)
            //{
            //    T[i] = (i * i) % 17;
            //}

            //int min = T[0];
            //int max = T[0];
            //for (int i = 0; i < T.Length; i++)
            //{
            //    if (min > T[i])
            //    {
            //        min = T[i];
            //    }
            //    if (max < T[i])
            //    {
            //        max = T[i];
            //    }
            //}
            //foreach (var elem in T)
            //{
            //    Console.WriteLine(elem);
            //}
            //Console.WriteLine("max : " + max + " min : " + min);

            //Exercice 13

            //int[] T = new int[20];

            //for (int i = 0; i < T.Length; i++)
            //{
            //    T[i] = (i * i) % 17;
            //}
            //Console.WriteLine("Donnez une valeur");
            //int x = int.Parse(Console.ReadLine());
            //for (int i = 0; i < T.Length; i++)
            //{
            //    if (T[i]==x)
            //    {
            //        Console.WriteLine(x +" se trouve en indice : "+i+" du tableau");
            //    }
            //}
            //foreach (var elem in T)
            //{
            //    Console.WriteLine(elem);
            //}

            //Exercice 14

            //int[] T = new int[20];
            //int[] Q = new int[20];
            //int indice = 0;
            //for (int i = 0; i < T.Length; i++)
            //{
            //    T[i] = (i * i) % 17;
            //}
            //Console.WriteLine("Donnez une valeur");
            //int x = int.Parse(Console.ReadLine());
            //for (int i = 0; i < T.Length; i++)
            //{
            //    if (T[i] == x)
            //    {
            //        Q[indice]= i;
            //        indice++;
            //    }
            //}
            //Array.Resize(ref Q, indice);
            //if (Q.Length>0)
            //{
            //    foreach (var elem in Q)
            //    {
            //        Console.WriteLine(x + " se trouve en indice : " + elem + " du tableau");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(x + " ne se trouve pas dans le tableau");
            //}

            //Exercice 16


            int[] T = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = rnd.Next(-20,20);
            }
            int tranche=3;
            int sommeTranche=0;
            for (int j = 0; j < tranche; j++)
            {
                sommeTranche += T[j];
            }
            int minTranche=sommeTranche;
            sommeTranche = 0;
            for (int i=0;i<T.Length-1-tranche;i++)
            {
                for (int j = 0; j < tranche; j++)
                {
                    sommeTranche += T[i + j];
                }
                if (sommeTranche<minTranche)
                {
                    minTranche = sommeTranche;
                }
                sommeTranche = 0;
            }

            Console.WriteLine("La tranche minimal est : "+minTranche);

            foreach (var elem in T)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
