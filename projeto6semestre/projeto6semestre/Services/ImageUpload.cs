using Azure.Storage.Blobs;
using System.Text.RegularExpressions;

namespace projeto6semestre.Services
{
    public class ImageUpload
    {

        public string Upload64Image(string Image64, string container) 
        {
            var Nome = Guid.NewGuid().ToString() + ".jpg";
            //Gerar um nome Aleatorio

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(Image64, "");
            //remove a primeira parte da imagem que é desnecessaria 

            
            byte[] imageBytes = Convert.FromBase64String(data);
            //transforma a imagem em um array de bytes

            
            var blobClient = new BlobClient("CONECTION STRING DO STORAGE", container, Nome);
            // Define o Storage no qual a imagem será armazenada

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
