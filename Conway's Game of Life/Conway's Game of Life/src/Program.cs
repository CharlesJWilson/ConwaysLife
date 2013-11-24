using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conway.src.Grid;

namespace Conway.src
{
    class Program
    {
        static int generations;
        static void Main(string[] args)
        {
            LifeSimulation sim = new LifeSimulation(10);

            // initialize with a blinker
            sim.ToggleCell(5, 5);
            sim.ToggleCell(5, 6);
            sim.ToggleCell(5, 7);

            sim.BeginGeneration();
            sim.Wait();
            OutputBoard(sim);

            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
            aTimer.Interval = 10000;
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Start();

            Console.WriteLine("Press \'q\' to quite");
            while(Console.Read()!='q')//for (; ; )
            {
                sim.Update();
                sim.Wait();
                //OutputBoard(sim);
                generations = ++generations;
            }

            //sim.Update();
            //sim.Wait();
            //OutputBoard(sim);

            //Console.ReadKey();
        }

        private static void OnTimedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Number of generations is: " + generations);
        }

        private static void OutputBoard(LifeSimulation sim)
        {
            var line = new String('-', sim.Size);
            Console.WriteLine(line);

            for (int y = 0; y < sim.Size; y++)
            {
                for (int x = 0; x < sim.Size; x++)
                {
                    Console.Write(sim[x, y] ? "1" : "0");
                }

                Console.WriteLine();
            }
        }
    }
}
