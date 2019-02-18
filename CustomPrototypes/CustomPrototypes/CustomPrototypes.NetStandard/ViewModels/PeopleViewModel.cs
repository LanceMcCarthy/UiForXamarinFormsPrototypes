using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class PeopleViewModel : ViewModelBase
    {
        private readonly SampleDataService dataService;

        public PeopleViewModel()
        {
            dataService = new SampleDataService();

            People = new ObservableCollection<Person>(dataService.GeneratePeopleData(true));
        }

        public ObservableCollection<Person> People { get; set; }
    }
}