using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace DmitryMironovAgasha
{
    //An empty page that can be used on its own or navigated to within a Frame. 
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;
        public MainPage()
        {
            this.InitializeComponent();

            // Current = This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;
            SampleTitle.Text =  FEATURE_NAME;
        }

        //Invoked when the page is loaded
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Populate the scenario list from the SampleConfiguration.cs file
            var itemCollection = new List<Scenario>();

            //Loop through all the scenarious in List
            foreach (Scenario s in scenarios)
            {

                itemCollection.Add(new Scenario { Title = $"{s.Title}", ClassType = s.ClassType });
            }

            //Connect the List of Scenarious to Xaml Control named ScenarioControl
            //Populates The ListBox With Scenarios
            ListBoxScenarioControl.ItemsSource = itemCollection;


            //Select the xaml ListBox Selected Index
            //if current Width smaller than 640px
            if (Window.Current.Bounds.Width < 640) {
                ListBoxScenarioControl.SelectedIndex = -1;
            }
            else {
                ListBoxScenarioControl.SelectedIndex = 0;
            }
        }


        // This handler-method called whenever the user changes selection in the scenarios list.  
        // This method will navigate to the respective sample scenario page.(Selected xaml page)
        // and display selected page within the frame (Right side of the application)
        // This sender object it is a selectedItem within a ListBox control.
        // It converts the ListBox' selectedItem to scenario object. It is then passes this selected
        // scenario object to ScenarioFrame.Navigate() method, which is then selects the corresponding
        // scenario from s (Scenario) object that contains all the scenarios in Configuration.cs class
        private void ScenarioControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ListBox scenarioListBox = sender as ListBox;
            Scenario s = scenarioListBox.SelectedItem as Scenario; // first  element in the ListBox
            if (s != null)
            {
                ScenarioFrame.Navigate(s.ClassType);
                //Reset the Main Page logo


                //Update Image on every scenario switch
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new Uri("ms-appx:///Assets/User.jpg");
                bitmapImage.UriSource = uri;
                img.Source = bitmapImage;
                imgStatus.Source = bitmapImage;

                //reset status label text on each Scenario Switch
                lblBottomStatusLabel.Text = "";


                if (Window.Current.Bounds.Width < 640)
                {
                    SplitViewControl.IsPaneOpen = false;
                }
            }
        }


        //Get scenarios from the Configuration Class
        public List<Scenario> Scenarios
        {
            //returns Configuration scenarios List<> object
            get { return this.scenarios; }
        }

        //Toggle On/Off The Left upper Menu (Toggle Switch)
        private void ToggleShowHideMenu_Toggled(object sender, RoutedEventArgs e)
        {
            if (!SplitViewControl.IsPaneOpen)
            {
                //If Pane is NOT open, Open the Pane
                SplitViewControl.IsPaneOpen = true;
            }
            else
            {
                //Otherwise Keep Pane Closed
                SplitViewControl.IsPaneOpen = false;
            }
        }


        //public properties for lblBottomStatusLabel
        //You will be able to get to these properties from a different
        //Page of our application
        //Each page have to implement this code to Get the MainPage Object
        //MainPage mainPage = (Window.Current.Content as Frame).Content as MainPage;
        public string tbMainPageLowerTextBlockText
        {
            get { return lblBottomStatusLabel.Text; }
            set { lblBottomStatusLabel.Text = value; }
        }

        //Properties for imgStatus Image control
        public ImageSource imgStatusURI
        { get { return imgStatus.Source; }
          set { imgStatus.Source = value; }
        }
    }
}
