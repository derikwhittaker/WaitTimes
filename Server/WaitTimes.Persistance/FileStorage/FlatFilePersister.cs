using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaitTimes.Models.Api;
using WaitTimes.Models.Dto;
using WaitTimes.Persistance.Raven;

namespace WaitTimes.Persistance.FileStorage
{
    public class FlatFilePersister : IWaitTimesRepository
    {
        private const string RootFolderPath = @"d:\Dev.Personal\WaitTimes\Data\{0}";
        public Task Save(CurrentTimeResult currentTimeResult)
        {
            var finalFolderPath = string.Format(RootFolderPath, currentTimeResult.ParkName);
            var fileName = CreateFileName(currentTimeResult.ParkName);
            var fullPath = Path.Combine(finalFolderPath, fileName);

            if (!Directory.Exists(finalFolderPath))
            {
                Directory.CreateDirectory(finalFolderPath);
            }

            var currentTimesJson = JsonConvert.SerializeObject(currentTimeResult);
            
            File.WriteAllText(fullPath, currentTimesJson);

            WriteMessageToConsole(fullPath);

            return Task.FromResult(0);
        }

        public Task<List<CurrentTimeDto>> Save(List<CurrentTimeDto> remoteHostCurrentTimes)
        {
            throw new NotImplementedException();
        }

        public CurrentTimeDto Fetch(string id)
        {
            throw new NotImplementedException();
        }

        private void WriteMessageToConsole(string fullPath)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"The file {fullPath} was processed at {DateTime.Now}");
            Console.ForegroundColor = currentColor;
        }

        private string CreateFileName(string source)
        {
            return $"{DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss")}.{source}.v2.json";
            //return $"{DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss")}.{source}.json";
        }
    }
}
