using Ex01.Models;
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
    public partial class CodaDetailsPage : ContentPage
    {

        //info bijhoudern

        public CodaDocument MyDocument { get; set; }

        public CodaPage MyPage { get; set; }


        public CodaDetailsPage(CodaDocument codaDocument, CodaPage codaPage)
        {
            InitializeComponent();
        }
    }
}