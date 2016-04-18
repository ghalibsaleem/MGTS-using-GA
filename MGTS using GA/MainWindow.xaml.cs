using MGTS_GA_Brain.Handlers;
using MGTS_GA_Brain.helper;
using MGTS_GA_Brain.helper.GeneticAlgo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MGTS_using_GA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public MainWindow()
        {
            InitializeComponent();
            
            Population population = new Population();
            population.InitializePopulation(@"D:\input.txt");
            GeneticAlgorithm.population = population;
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            GeneticAlgorithm.Evolve();
            Helper.FinalizeIt(GeneticAlgorithm.GetEliteChromosome());
        }
    }
}
