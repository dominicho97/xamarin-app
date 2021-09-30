using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ex01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();


            //Gestures to  frames for navigation

            //Navigation to documents

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            frmMainPage.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}