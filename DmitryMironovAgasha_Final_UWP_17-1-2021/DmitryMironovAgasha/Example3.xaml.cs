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
    public sealed partial class Example3 : Page
    {
        public Example3()
        {
            this.InitializeComponent();
        }

      

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string UserInput = txtNumber.Text;
            //check InputRange
            if (IsINputInRange(UserInput))
            {
                //Range valid
                //test if can be parsed to Int
                int inputParsedIneger;
                bool IsIntParsed = int.TryParse(UserInput, out inputParsedIneger);
                if (IsIntParsed && inputParsedIneger > 0)
                {
                    //If is int, Now parse int to char
                    if (IsParseIntegerToChar(inputParsedIneger))
                    {
                        //Success
                        //First digit(tens) is indeed bigger than second(Units)
                        lblStatus.Text = "Success! First (Tens) digit is indeed greater than the Units digit.";
                        UpdateMainPageStatusSuccess();
                    }
                    else
                    {
                        //Error
                        //Second (units) digits is Bigger than Tens
                        lblStatus.Text = "Error! Units' digit is Greater than Tens' digit.\nOnly numbers with a Tens' value greater than units' one are allowed\nExample: 65;81;54";
                        txtNumber.Text = "";
                        UpdateMainPageStatusDeny();
                    }
                }
                else
                {
                    //Cannot be parsed top int
                    lblStatus.Text = "Error! Input has to be a numeric Positive value! \n Try 52 , 60 , 43 , 87";
                    txtNumber.Text = "";
                    UpdateMainPageStatusDeny();
                }
            }
            else
            {
                // Not in Range
                lblStatus.Text = "Error!\n values must be greater than zero, and less than 3 digits";
                txtNumber.Text = "";
                UpdateMainPageStatusDeny();
            }
        }

        //Custom methods
        bool IsINputInRange(string _input)
        {
            bool IsInRange;
            string UsersInput = _input;
            int Length = UsersInput.Length;

            if (Length < 3 && Length > 0)
            {
                IsInRange = true;
                //whithin range
            }
            else
            {
                //the numbers is out of range
                IsInRange = false;
            }
            return IsInRange;
        }

        //Having Fun method :-)
        bool IsParseIntegerToChar(int _input)
        {
            bool TensBiggerThanUnits;
            string str = _input.ToString();
            char[] charArray = str.ToCharArray(); //Parse input to 2 chars
            int[] myIntArray = new int[charArray.Length]; //holds integers
            for (int i = 0; i < charArray.Length; i++)
            {
                //How to Convert each char to int?
                //1.Try converting to string first
                //2.Then Parse() to int within one line
                myIntArray[i] = int.Parse(charArray[i].ToString());

            }
            //Check if the first index is bigger than second index
            if (myIntArray[0] > myIntArray[1])
            {
                //Tens is biger	
                TensBiggerThanUnits = true;
            }
            else
            {
                //units is bigger
                TensBiggerThanUnits = false;
            }
            return TensBiggerThanUnits;
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
