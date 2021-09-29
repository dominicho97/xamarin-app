using Ex01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.Repositories
{
    public class CodaRepository
    {

        //define base URL
        private const String _BASEURL = "https://coda.io/apis/v1";
        private const String _Token = "f69b44ef-0585-4ce0-88ac-33dc3e81829d";




        //prepare HttpClient
        private static async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            //BEARER TOKEN 
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "f69b44ef-0585-4ce0-88ac-33dc3e81829d");

            return client;

        }




        //API documentation of this request: https://coda.io/developers/apis/v1#operation/listDocs

        //Paste this in POSTMAN : https://coda.io/apis/v1/docs


        //GET list of Documents
        public static async Task<List<CodaDocument>> GetDocumentsAsync()
        {
            using (HttpClient client = await GetClient())
            {

                //https://coda.io/apis/v1/docs

                String url = _BASEURL + "/docs";
                string json = await client.GetStringAsync(url);

                try
                {


                    //json convert to list
                    if (json != null)
                    {
                        //json --> List Documents
                        var documents = JsonConvert.DeserializeObject<CodaDocument>(json);
                        return documents.CodaDocuments;

                    }
                    else

                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


        }


        //DELETE   Document


        public async static Task DeleteDocumentsAsync(string id)
        {
            using (HttpClient client = await GetClient())
            {
                //voeg een niewe CodaDocument toe aan de documentId als parameter
                try
                {
                    string url = _BASEURL + $"/docs/" + id;

                    var response = client.DeleteAsync(url).Result;

                    //controle: is het gelukt?
                    if (response.IsSuccessStatusCode == false)
                    {

                        throw new Exception("Delete did not succeed");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }



        //2: GET list of Pages from 1 Document
        public static async Task<List<CodaPage>> GetPagesAsync(String documentId)
        {
            using (HttpClient client = await GetClient())
            {
                //https://coda.io/apis/v1/docs/{docId}/pages

                String url = _BASEURL + $"/docs/{documentId}/pages";
                string json = await client.GetStringAsync(url);

                try
                {

                    //json convert to list
                    if (json != null)
                    {
                        //json --> List Pages
                        var pages = JsonConvert.DeserializeObject<CodaPage>(json);
                        return pages.CodaPages;

                    }
                    else

                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }

    }
}
