using Ex01.Models;
using Ex01.Repositories;
using Ex01.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ex01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TestModels();
            LoadDocuments();

            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            lblAddDocument.GestureRecognizers.Add(tapGesture);
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SingleDocumentPage());
        }



        //ADD document /toevoegen document






        private async Task TestModels()
        {
            //test the GET Documents



            Debug.WriteLine("test models");
            List<CodaDocument> codaDocuments = await CodaRepository.GetDocumentsAsync();
            foreach (CodaDocument d in codaDocuments)
            {
                Debug.WriteLine("dit is een test", d.Name, d.CreatedAt);
            }
        }

        private async Task LoadDocuments()
        {
            lvwDocuments.ItemsSource = await CodaRepository.GetDocumentsAsync();
        }




        private void lvwDocuments_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwDocuments.SelectedItem != null)
            {
                // er is een document geselecteerd
                CodaDocument selected = (CodaDocument)lvwDocuments.SelectedItem;
                // naar een andere pagina
                Navigation.PushAsync(new CodaDocumentsPage(selected));
                //selected document deselecteren
                lvwDocuments.SelectedItem = null;
            }
        }


        private async void btnCloseDocument_Clicked(object sender, EventArgs e)
        {
            CodaDocument codaDocument = (sender as Button).BindingContext as CodaDocument;
            await CodaRepository.DeleteDocumentsAsync(codaDocument.Id);

        }

        //uitvoeren wanneer we naar deze pagina gaan
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadDocuments();
        }


        private void lvwDocuments_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
