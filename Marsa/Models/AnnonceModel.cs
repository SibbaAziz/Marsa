using Marsa.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marsa.Models
{
    public class AnnonceModel : Annonce
    {
        public AnnonceModel()
        {

        }
        public AnnonceModel(Annonce annonce)
        {
            Id = annonce.Id;
            this.PhoneNumber = annonce.PhoneNumber;
            this.Photos = annonce.Photos;
            this.Category = annonce.Category;
            this.City = annonce.City;
            this.Description = annonce.Description;
            this.Email = annonce.Email;
            this.Address = annonce.Address;
            this.Price = annonce.Price;
            this.Pseudo = annonce.Pseudo;
            this.Title = annonce.Title;
        }

        public string[] GetPhotos()
        {
            return Photos.Split('&').Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }
    }
}