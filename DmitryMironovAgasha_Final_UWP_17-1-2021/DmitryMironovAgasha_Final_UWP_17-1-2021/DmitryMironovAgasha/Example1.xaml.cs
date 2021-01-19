using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

    public sealed partial class Example1 : Page
    {
      
        public Example1()
        {
            this.InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //validate string first
            bool IsValidated = ValidateInputString(txtName.Text);

            if (IsValidated)
            {   //If everything is okay up until now
                //Simply LowerCase The letter
                string validatedStr = txtName.Text.ToLower();
                lblStatus.Text = "Success!\n You've entered  a correct a value: [ " + validatedStr +" ]\n We were smart enough to LowerCase your value \n :-)";
                //update MainPage Status Label, and image
                txtName.Text = "";
                UpdateMainPageStatusSuccess();
            }
            else
            {
                //Is Not validated
                //status label is populeted from
                //ValidateInputString() method

                UpdateMainPageStatusDeny();
            }
        }

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

        private bool ValidateInputString(string _input)
        {
            //List of brohibited symbols
            List<string> invalidChars = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "(", ")","*", "%", "-" };
            // Check for length
            if (_input.Length > 1)
            {
                lblStatus.Text = "String to long! Only a Single character is allowed!";
                return false;
            }

            else
            {
                if (_input.Length < 1)
                {
                    lblStatus.Text = "Error Can't work with empty text!";
                    return false;
                }
                else
                {

                    //Iterate Trough Brohibited chars and check if one of them matches your input
                    //if yes report Error
                    foreach (string InvalidItem in invalidChars)
                    {
                        //tests only empty string
                        if (_input == "")
                        {
                            lblStatus.Text = "Cannot be empty! enter a single letter:";
                            return false;

                        }
                        if (_input.Contains(InvalidItem))
                        {
                            lblStatus.Text = "Only Letters is allowed!\n You've entered :" + "[ " + InvalidItem + " ]";
                            return false;
                        }

                    }
                    //If everything is Okay and user indeed entered a Valid letter (NOT a Symbol)
                    //check whether it's English or not!?
                    //Using Regular expression that returns bool value
                    //This expression checks whether the Users inpt is indeed english a-to z
                    bool IsInglish = Regex.IsMatch(_input, "^[a-zA-Z0-9. -_?]*$");

                    if (IsInglish)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            } //end else


        }//End method
    }
}
