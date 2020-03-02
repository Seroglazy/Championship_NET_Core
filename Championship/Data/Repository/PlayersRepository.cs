using Championship.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Championship.Data.Repository
{
    public class PlayersRepository : IPlayers
    {
        private readonly AppDBContent appDBContent;
        Microsoft.Extensions.Hosting.IHostingEnvironment _appEnvironment;
        public PlayersRepository(AppDBContent appDBContent, Microsoft.Extensions.Hosting.IHostingEnvironment appEnvironment)
        {
            this.appDBContent = appDBContent;
            _appEnvironment = appEnvironment;
        }
        
        public IEnumerable<Players> AllPlayers => appDBContent.Players;

        public Players GetPlayerById(int id) => appDBContent.Players.FirstOrDefault(p => p.Id == id);
        public Players GetPlayerByName(string name) => appDBContent.Players.FirstOrDefault(p => p.Profile == name);
        public void UpdateRating(int newRating, string name)
        {
            appDBContent.Players.FirstOrDefault(p => p.Profile == name).Rating = newRating;
            appDBContent.SaveChanges();
        }
        public void AddPlayer(Players newPlayer)
        {
            appDBContent.Players.Add(newPlayer);
            appDBContent.SaveChanges();
        }

        public void ProfilePic(IFormFile uploadedFile, int LoggedId)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/wwwroot/img/" + LoggedId + ".png";
                // сохраняем файл в папку Files в каталоге wwwroot

                using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create))
                {
                    //fileStream.Dispose();
                    if (File.Exists(path))
                        { File.Delete(path); };
                    uploadedFile.CopyTo(fileStream);
                }

                //// путь к папке Files
                //string path = "/img/" + uploadedFile.FileName;
                //// сохраняем файл в папку Files в каталоге wwwroot
                //using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create))
                //{
                //    uploadedFile.CopyToAsync(fileStream);
                //}
                //FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                //_context.Files.Add(file);
                //_context.SaveChanges();
            }
        }
    }
}
