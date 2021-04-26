using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SfComboBox_DataTemplateSelector
{
    public class DataTemplateSelectorViewModel : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SpecificDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as MobileDetail;
            if (message.IsAvaiableInStock == null)
                return null;
            return message.IsAvaiableInStock == false ? SpecificDataTemplate : DefaultTemplate;
        }

    }
}