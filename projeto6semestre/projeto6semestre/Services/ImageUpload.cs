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

            
            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=demoprojeto;AccountKey=1OyReAlnk4jEgV8TYnjusUfi91nkdfu+NIb/mu8/RpWmzv+5rxVqLCW4aDi0678NvyGboYgHEd0d+AStVwEppw==;EndpointSuffix=core.windows.net", container, Nome);
            // Define o Storage no qual a imagem será armazenada

            // Envia a imagem para o Storage
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
