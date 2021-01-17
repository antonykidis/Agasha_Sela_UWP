using System;
using System.Collections.Generic;
using System.Drawing;
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
   
    public sealed partial class Example2 : Page
    {
        public Example2()
        {
            this.InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            double UserInput;
            bool IsParsed = Double.TryParse(txtNumber.Text, out UserInput);

            if (IsParsed && UserInput > 0)
            {
                //Parsed Ok
                // If Okay, check if it's divided by 4 without reminder
                if (IsDivisibleBy4(UserInput))
                {
                    lblStatus.Text = $"Success! Number {UserInput} can be divided by 4.";
                    //Success
                    UpdateMainPageStatusSuccess();
                }
                else
                {
                    //Deny. Number has reminder after 
                    //dividing by 4. Show Status Error.
                    lblStatus.Text = $"Error! Number {UserInput}  Cannot be divided By 4 without reminder";
                    txtNumber.Text = "";
                    UpdateMainPageStatusDeny();
                }
               
            }
            else
            {
                //Cannot be parsed
                //Notify User.
                //Update status label, and image
                lblStatus.Text = "Error! Only Numeric values greater than Zero are allowed";
                txtNumber.Text = "";
                UpdateMainPageStatusDeny();
            }
        }


        //custom method
        private bool IsDivisibleBy4(double _input)
        {
            bool IsDivisible;
            if (_input % 4 == 0)
            {
                //If number can be devided by 4
                //without remainder, Notify user
                //The number can be divided by 4 without reminder
                IsDivisible = true;
            }
            else
            {
                IsDivisible = false;
            }

            return IsDivisible;
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



    } //end of MainPage   
}
