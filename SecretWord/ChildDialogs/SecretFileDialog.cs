using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SecretWord.ChildDialogs
{
    class SecretFileDialog : IFileDialog
    {
        public string Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "Secret document (*.rtfx)|*.rtfx";
            if (ofd.ShowDialog() == true)
                return ofd.FileName;
            return "";
        }

        public string Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.Filter = "Secret document (*.rtfx)|*.rtfx";
            if (sfd.ShowDialog() == true)
                return sfd.FileName;
            return "";
        }
    }
}
