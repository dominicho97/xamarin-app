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
    public partial class CodaDocumentsPage : ContentPage
    {


        public CodaDocument MyDocument { get; set; }

        //geselecteerde document meegeven
        public CodaDocumentsPage(Models.CodaDocument selected)
        {
            InitializeComponent();

            //bijhouden


            MyDocument = selected;
        }






        //selecteren van CodaPage
        private void lvwCodaPages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwCodaPages.SelectedItem != null)
            {
                CodaPage codaPageSelected = (CodaPage)lvwCodaPages.SelectedItem;
                Navigation.PushAsync(new CodaDetailsPage(
                MyDocument, codaPageSelected));

                //deselecteren
                lvwCodaPages.SelectedItem = null;


            }
        }
    }
}