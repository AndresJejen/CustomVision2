using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Intefaz
{
    public partial class FCustomVision : Form
    {
        static string prediccion = "";
        public FCustomVision()
        {
            InitializeComponent();
            
        }

        private void BtnPathImg_Click(object sender, EventArgs e)
        {

            string imagen = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                try
                {

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imagen = openFileDialog.FileName;
                        TxtResultado.Text = "";
                        TxtResultado.Text = imagen + "\n analizando";
                        MakePredictionRequest(imagen).Wait();
                        TxtResultado.Text += prediccion;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                }
            }
        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        static async Task MakePredictionRequest(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid subscription key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "30bb428a529948a483cae7cd9e020c54");

            // Prediction URL - replace this example URL with your valid prediction URL.
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/17c04784-53f3-4fd7-aada-9779aa7902c2/image?iterationId=deb4d9b5-cdd4-4e2f-83cc-d5ec033e7243";

            HttpResponseMessage response;
            try
            {
                // Request body. Try this sample with a locally stored image.
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(url, content);
                    var result = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(result);

                    int prediccionnes = ((JArray)json["predictions"]).Count;

                    for (int i = 0; i < prediccionnes; i++)
                    {
                        if ((double)json["predictions"][i]["probability"] > 0.4)
                        {
                            prediccion += "La predicción N° " + i+"\n";
                            prediccion += "Probabilidad: " + (string)json["predictions"][i]["probability"]+"\n";
                            prediccion += "Predicción: " + (string)json["predictions"][i]["tagName"]+"\n";
                            prediccion += "Left: " + (string)json["predictions"][i]["boundingBox"]["left"] + "\n";
                            prediccion += "Top: " + (string)json["predictions"][i]["boundingBox"]["top"] + "\n";
                            prediccion += "Width: " + (string)json["predictions"][i]["boundingBox"]["width"] + "\n";
                            prediccion += "height: " + (string)json["predictions"][i]["boundingBox"]["height"]+"\n \n";
                        }
                    }
                    prediccion += "Listo\n";

                }
            }
            catch (Exception error)
            {
                prediccion = "";
                prediccion = error.Message; 
            }
        }
    }
}
