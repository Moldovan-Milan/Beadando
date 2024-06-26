﻿using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MoldovanMilanBeadando.Repository
{
    internal class ImageRepository
    {
        private Context context;

        public ImageRepository(Context context)
        {
            this.context = context;
        }

        public List<Images> GetAllImages()
        {
            return context.Images.ToList();
        }

        public Images GetByName(string name)
        {
            return context.Images.Where(p => p.Caption == name).ToList().First();
        }

        public void AddImage(byte[] imageByte, string caption)
        {
            context.Images.Add(new Images
            {
                Caption = caption,
                IMG = imageByte
            });
            MessageBox.Show(imageByte.Length.ToString());
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
