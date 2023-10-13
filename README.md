# DataTemplateSelector in Xamarin ComboBox (SfComboBox)

SfComboBox supports DataTemplateSelector, which is used to choose a DataTemplate based on data object.

**[XAML]**

```
<ContentPage.BindingContext>
        <local:MobileDetailViewModel/>
    </ContentPage.BindingContext>
    <ContentPage.Resources>
        <ResourceDictionary>
            <DataTemplate x:Key="default">
                <ViewCell>
                    <Grid Padding="5">
                        <Label Text="{Binding Mobile}" TextColor="Green"/>
                    </Grid>
                </ViewCell>
            </DataTemplate>
            <DataTemplate x:Key="specific">
                <ViewCell>
                    <Grid  Padding="5">
                        <Label Text="{Binding Mobile}" BackgroundColor="LightGray" TextColor="Red"/>
                    </Grid>
                </ViewCell>
            </DataTemplate>
        </ResourceDictionary>
    </ContentPage.Resources>
    <StackLayout VerticalOptions="Start" HorizontalOptions="Start" Padding="30">
        <comboBox:SfComboBox DataSource="{Binding MobileCollection}" DisplayMemberPath="Mobile">
            <comboBox:SfComboBox.ItemTemplate>
                <local:DataTemplateSelectorViewModel DefaultTemplate="{StaticResource default}" SpecificDataTemplate="{StaticResource specific}" />
            </comboBox:SfComboBox.ItemTemplate>
        </comboBox:SfComboBox>
    </StackLayout>
```
## Create and Initialize Business Models
Define a simple model class MobileDetail with fields IsAvailableInStock, Mobile and populate mobile detail in ViewModel.

**[C#]**

```
public class MobileDetailViewModel
    {
        public ObservableCollection<MobileDetail> MobileCollection { get; set; }
        public MobileDetailViewModel()
        {
            this.MobileCollection = new ObservableCollection<MobileDetail>()
            {
                new MobileDetail () { Mobile="Samasung S8", IsAvailableInStock=false },
                new MobileDetail () { Mobile="Samasung S9", IsAvailableInStock=true },
                new MobileDetail () { Mobile="Samsung S10", IsAvailableInStock=true },
                new MobileDetail () { Mobile="Samsung S10 plus", IsAvailableInStock=true },
                new MobileDetail () { Mobile="iPhone 7", IsAvailableInStock=true },
                new MobileDetail () { Mobile="iPhone 8", IsAvailableInStock=true },
                new MobileDetail () { Mobile="iPhone X", IsAvailableInStock=false },
                new MobileDetail () { Mobile="iPhone XR", IsAvailableInStock=false },
                new MobileDetail () { Mobile="iPhone XS", IsAvailableInStock=true },
            };
        }
    }

    public class MobileDetail
    {
        public string Mobile { get; set; }

        public bool IsAvailableInStock { get; set; }
    }
```
## OnSelectTemplate
The OnSelectTemplate is an overridden method to return a particular DataTemplate. The following code sample demonstrates how to use the OnSelectTemplate method.

**[C#]**

```
public class DataTemplateSelectorViewModel : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SpecificDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as MobileDetail;
            if (message.IsAvailableInStock == null)
                return null;
            return message.IsAvailableInStock == false ? SpecificDataTemplate : DefaultTemplate;
        }

    }
```

## How to run this application?

To run this application, you need to first clone the datatemplate-selector-sfcombobox repository and then open it in Visual Studio 2022. Now, simply build and run your project to view the output.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise by using or viewing the samples. The samples are for demonstrative purposes, and if you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage that is related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion’s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion’s samples.