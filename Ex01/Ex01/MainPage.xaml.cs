using Ex01.Models;
using Ex01.Repositories;
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
        }



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
    }
}
