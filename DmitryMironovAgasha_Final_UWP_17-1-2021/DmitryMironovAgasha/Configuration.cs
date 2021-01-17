using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DmitryMironovAgasha
{
    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "Dmitry Mironov's Application";

   

        //List of Pages within our application (Xaml Pages)
        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title = "Answer 1", ClassType = typeof(Example1) },
            new Scenario() { Title = "Answer 2", ClassType = typeof(Example2) },
            new Scenario() { Title = "Answer 3", ClassType = typeof(Example3) },
            new Scenario() { Title = "Answer 4", ClassType = typeof(Example4) },
            new Scenario() { Title = "Answer 5", ClassType = typeof(Example5) }
            //new Scenario() { Title = "", ClassType = typeof(Example5) }
        };

    }
    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }

}
