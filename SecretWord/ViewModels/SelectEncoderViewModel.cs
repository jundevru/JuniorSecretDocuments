using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretWord.ViewModels
{
    class SelectEncoderViewModel : DependencyObject
    {


        public int EncodeKey
        {
            get { return (int)GetValue(EncodeKeyProperty); }
            set { SetValue(EncodeKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EncodeKey.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EncodeKeyProperty =
            DependencyProperty.Register("EncodeKey", typeof(int), typeof(SelectEncoderViewModel), new PropertyMetadata(0));



        public IList<Models.Encoder> Encoders
        {
            get { return (IList<Models.Encoder>)GetValue(EncodersProperty); }
            set { SetValue(EncodersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Encoders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EncodersProperty =
            DependencyProperty.Register("Encoders", typeof(IList<Models.Encoder>), typeof(SelectEncoderViewModel), new PropertyMetadata(null));



        public Models.Encoder SelectedEncoder
        {
            get { return (Models.Encoder)GetValue(SelectedEncoderProperty); }
            set { SetValue(SelectedEncoderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedEncoder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedEncoderProperty =
            DependencyProperty.Register("SelectedEncoder", typeof(Models.Encoder), typeof(SelectEncoderViewModel), new PropertyMetadata(null));




        public SelectEncoderViewModel()
        {
            
            Encoders = Models.Encoder.LoadEncoders(System.Environment.CurrentDirectory.TrimEnd("\\"[0]) + "\\encoders");
            EncodeKey = Encoders.Count;
        }


    }
}
