﻿using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    public class Profiles :Profile
    {
        public static List<Produits> FromObjectToProduits(List<Object> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Produits> produits  = JsonConvert.DeserializeObject<List<Produits>>(listeSerialize);
            return produits;
        }
        public static List<Categories> FromObjectToCategories(List<Object> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Categories> categs = JsonConvert.DeserializeObject<List<Categories>>(listeSerialize);
            return categs;
        }

    }
}
