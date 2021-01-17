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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DmitryMironovAgasha
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example5 : Page
    {
        public Example5()
        {
            this.InitializeComponent();
        }

        //Global variables [G]
        public double G_FirstNum, G_SecondNum, G_ThirdNum, G_FourthNum;
        public bool G_isFirstParsed, G_isSecondParsed, G_isThirdParsed, G_isFourthParsed;
        string G_UserInput;
        int G_ctr = 1;

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Bing textbox to Global input variable
            G_UserInput = txtNumber.Text;


            switch (G_ctr)
            {
                case 1:
                    FirstNumberCollectSubmit(G_UserInput);
                    break;
                case 2:
                    SecondNumberCollectSubmit(G_UserInput);
                    break;
                case 3:
                    ThirdNumberCollectSubmit(G_UserInput);
                    break;
                case 4:
                    FourthNumberCollectSubmit(G_UserInput);
                    //Change the Text of the button
                    //At this step collaps the textBox only if everything is parsed
                    if (G_isFourthParsed)
                    {
                        btnSubmit.Content = "Calculate";
                        txtNumber.Visibility = Visibility.Collapsed;
                        lblStatus.Text = "Press Calculate";

                    }

                    break;
                //Step 5 is the calculation time
                //If everything is parsed so far do the calculations
                case 5:
                    if (G_isFirstParsed && G_isSecondParsed && G_isThirdParsed && G_isFourthParsed)
                    {
                        //Add Clear Button
                        btnClear.Visibility = Visibility.Visible;
                        //Hide Submit Bnutton
                        btnSubmit.Visibility = Visibility.Collapsed;
                        lblStatus.Text = "Press Clear to Start\n from the beginning";

                        //When we have all the values collected
                        //let's put them into Array and perform a simple sort
                        List<double> MyUnsortedList = new List<double>();
                        MyUnsortedList.Add(G_FirstNum);
                        MyUnsortedList.Add(G_SecondNum);
                        MyUnsortedList.Add(G_ThirdNum);
                        MyUnsortedList.Add(G_FourthNum);

                        //Next step is to sort based on users selection
                        if (rbAscending.IsChecked == true)
                        {
                            string sortedStr;
                            //Do Sort => Ascending
                            MyUnsortedList.Sort();

                            //Get the values from List by joining the List values into a single string
                            //Each value will be joined with a single [" "] space
                            sortedStr = string.Join(" ", MyUnsortedList.ToArray());
                           // sortedStr= MyUnsortedList.ToString();
                            lblStatus.Text = $"Sorted Ascendind:\n{sortedStr}";
                           
                        }
                        if (rbDescending.IsChecked == true)
                        {
                            string sortedStr;
                            //Do Descending Reverse()
                            //But first do a regular sort
                            MyUnsortedList.Sort();
                            //Only now do reverse
                            MyUnsortedList.Reverse();
                           
                            sortedStr = string.Join(" ", MyUnsortedList.ToArray());
                            lblStatus.Text = $"Sorted Descending:\n{sortedStr}";
                        }
                        if (rbRegular.IsChecked == true)
                        {
                            //Now sorting here.....
                            string sortedStr;
                            //Present the numbers in a regular order
                            sortedStr = string.Join(" ", MyUnsortedList.ToArray());
                            lblStatus.Text = $"No Sorting!\nDisplayed in Entered order:\n{sortedStr}";

                        }

                    }
                    else
                    {
                        lblStatus.Text = "Unpredictable Error has Occurred\n Try entering Only Numeric values";
                    }
                    break;

            } //end switch

        } //End of Submit




        //Custom methods
        //Each method deals with evry turn based on the Global counter.
        //Each Method validates user input on each sibgle turn

        //First Num
        private void FirstNumberCollectSubmit(string _input)
        {
            //Do validation first
            if (G_isFirstParsed = double.TryParse(_input, out G_FirstNum) && G_FirstNum > 0)
            {
                //Parsed okay continue logic
                //Parsed number was assigned to a global FirstNum variable
                //Inform the user what happened in the first turn
                lbl_FirstNumber.Text = "First is: " + G_FirstNum.ToString();

                //Ask for another number
                lblStatus.Text = "Add Second number to proceed";

                //Update Counter when everything is finished
                G_ctr++;
                txtNumber.Text = "";
                UpdateMainPageStatusSuccess();
            }
            else
            {
                //Error
                //Cannot be parsed
                lblStatus.Text = "Error! Use Only Numeric Positive \n Values !\nTry Again";
                UpdateMainPageStatusDeny();
            }

        }
        //Second Num
        private void SecondNumberCollectSubmit(string _input)
        {
            //Do validation first
            if (G_isSecondParsed = double.TryParse(_input, out G_SecondNum) && G_SecondNum > 0)
            {
                //Parsed okay continue logic
                //Parsed number was assigned to a global Second variable
                //Inform the user what happened in the Second turn
                lbl_SecondNumber.Text = "Second is: " + G_SecondNum.ToString();

                //Ask for another number
                lblStatus.Text = "Add Third number to proceed";

                //Update Counter when everything is finished
                G_ctr++;
                txtNumber.Text = "";
                UpdateMainPageStatusSuccess();
            }
            else
            {
                //Error
                //Cannot be parsed
                lblStatus.Text = "Error! Use Only Numeric Values greater than Zero!\nTry Again";
                UpdateMainPageStatusDeny();
            }
        }
        //Third Num
        private void ThirdNumberCollectSubmit(string _input)
        {
            //Do validation first
            if (G_isThirdParsed = double.TryParse(_input, out G_ThirdNum) && G_ThirdNum > 0)
            {
                //Parsed okay continue logic
                //Parsed number was assigned to a global Third variable
                //Inform the user what happened in the Third turn
                lbl_ThirdNumber.Text = "Third is: " + G_ThirdNum.ToString();

                //Ask for another number
                lblStatus.Text = "Add Fourth number to proceed";

                //Update Counter when everything is finished
                G_ctr++;
                txtNumber.Text = "";
                UpdateMainPageStatusSuccess();
            }
            else
            {
                //Error
                //Cannot be parsed
                lblStatus.Text = "Error! Use Only Numeric Values greater than Zero!\nTry Again";
                UpdateMainPageStatusDeny();
            }
        }

        //Fourth Num
        private void FourthNumberCollectSubmit(string _input)
        {
            //Do validation first
            if (G_isFourthParsed = double.TryParse(_input, out G_FourthNum) && G_FourthNum > 0)
            {
                //Parsed okay continue logic
                //Parsed number was assigned to a global Third variable
                //Inform the user what happened in the Fourth turn
                lbl_FourthNumber.Text = "Fourth is: " + G_FourthNum.ToString();

                //Ask for another number
                lblStatus.Text = "Press a Submit  button to Calculate Min/Max";

                //Update Counter when everything is finished
                G_ctr++;
                txtNumber.Text = "";
                UpdateMainPageStatusSuccess();
            }
            else
            {
                //Error
                //Cannot be parsed
                lblStatus.Text = "Error! Use Only Numeric Values greater than Zero!\nTry Again";
                UpdateMainPageStatusDeny();
            }
        }


        //clear all values
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //enable Button box an submit button
            btnSubmit.Visibility = Visibility.Visible;
            btnSubmit.Content = "Submit";
            //Enable textBox
            txtNumber.Visibility = Visibility.Visible;
            //disable ClearButton
            btnClear.Visibility = Visibility.Collapsed;

            //clear unwanted values
            lblStatus.Text = "Enter first number";
            lbl_FirstNumber.Text = "1";
            lbl_SecondNumber.Text = "2";
            lbl_ThirdNumber.Text = "3";
            lbl_FourthNumber.Text = "4";
            //clear globals
            G_ctr = 1;



        }


        //Calculate
        //Methods which calculates the min and the max values
        double FindTheSmallestNum(double _firstNum, double _secondNum, double _thirdNum, double _fourthNum)
        {
            List<double> MyNumbersList = new List<double>();
            MyNumbersList.Add(_firstNum);
            MyNumbersList.Add(_secondNum);
            MyNumbersList.Add(_thirdNum);
            MyNumbersList.Add(_fourthNum);
            double SmallestSoFar = MyNumbersList.First(); //Adding first element of list to compare
                                                          //Do the same as with (greatest num) but this time reverse the logic
            foreach (var item in MyNumbersList)
            {
                if (item < SmallestSoFar)
                {
                    SmallestSoFar = item;
                }
            }
            return SmallestSoFar;
        }
        double FindTheGreatestNum(double _firstNum, double _secondNum, double _thirdNum, double _fourthNum)
        {

            List<double> MyNumbersList = new List<double>();
            MyNumbersList.Add(_firstNum);
            MyNumbersList.Add(_secondNum);
            MyNumbersList.Add(_thirdNum);
            MyNumbersList.Add(_fourthNum);
            double GreatestSoFar = MyNumbersList.First();

            foreach (var item in MyNumbersList)
            {
                if (item > GreatestSoFar)
                {
                    GreatestSoFar = item;
                }
            }
            return GreatestSoFar;
        }



        //Helper methods to display status on the MainPage
        //through the entire Application
        private void UpdateMainPageStatusSuccess()
        {
            //Update MainPage Status label
            MainPage mainPageControl = (Window.Current.Content as Frame).Content as MainPage;
            mainPageControl.tbMainPageLowerTextBlockText = "Success";
            MainPage mainPageControl2 = (Window.Current.Content as Frame).Content as MainPage;

            //Update Image
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/Success.png");
            bitmapImage.UriSource = uri;
            img.Source = bitmapImage;
            mainPageControl2.imgStatusURI = bitmapImage;

        }

        private void UpdateMainPageStatusDeny()
        {
            //Update MainPage Status label
            MainPage mainPageControl = (Window.Current.Content as Frame).Content as MainPage;
            mainPageControl.tbMainPageLowerTextBlockText = "Deny";
            MainPage mainPageControl2 = (Window.Current.Content as Frame).Content as MainPage;

            //Update Image
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/Deny.png");
            bitmapImage.UriSource = uri;
            img.Source = bitmapImage;
            mainPageControl2.imgStatusURI = bitmapImage;

        }
    }
}
