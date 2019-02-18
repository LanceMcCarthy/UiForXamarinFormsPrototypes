using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;
using Telerik.XamarinForms.Input.AutoComplete;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class PeopleViewModel : ViewModelBase
    {
        private Person _selectedPerson;
        private string _selectedText;

        public PeopleViewModel()
        {
            SuggestionSelectedCommand = new Command(OnSuggestedSelected);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>(new SampleDataService().GeneratePeopleData(true));

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public string SelectedText
        {
            get => _selectedText;
            set => SetProperty(ref _selectedText, value);
        }

        public Command SuggestionSelectedCommand { get; set; }

        private void OnSuggestedSelected(object obj)
        {
            if (obj is SuggestionItemSelectedEventArgs e)
            {
                this.SelectedPerson = e.DataItem as Person;
            }
        }
    }
}