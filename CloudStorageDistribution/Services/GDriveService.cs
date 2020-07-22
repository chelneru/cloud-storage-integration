using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CloudStorageDistribution.Services
{
    public class GDriveService : IService
    {
        static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };
        static readonly string ApplicationName = "Drive API .NET Quickstart";
        static DriveService driveService;

        public GDriveService()
        {
            UserCredential credential;

            using (var stream =
               new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
               // Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        public IList<Google.Apis.Drive.v3.Data.File> ListAllFiles()
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = driveService.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name, mimeType, kind)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            if (files != null && files.Count > 0)
            {
                return files;
            }
            else
            {
                return new List<Google.Apis.Drive.v3.Data.File>();
            }

        }
        public int Return0()
        {
            return 0;
        }

    }
}

