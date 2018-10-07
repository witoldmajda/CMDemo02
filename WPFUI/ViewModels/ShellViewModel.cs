using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    //public class ShellViewModel : Screen  dziedziczenie po Screen jest dobre do jednego formularza
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Witek";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Witek", LastName = "Majda", Address = "Boczna 6" });
            People.Add(new PersonModel { FirstName = "Agnieszka", LastName = "Majda", Address = "Boczna 6" });
            People.Add(new PersonModel { FirstName = "Marcelina", LastName = "Majda", Address = "Boczna 6" });
            People.Add(new PersonModel { FirstName = "Weronika", LastName = "Majda", Address = "Boczna 6" });
            People.Add(new PersonModel { FirstName = "Józef", LastName = "Sałatka", Address = "Snopowa 13" });
            People.Add(new PersonModel { FirstName = "Janusz", LastName = "Kapusta", Address = "Zgierska 11" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }        

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }            
        }        
        
        public BindableCollection<PersonModel> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;

            }
        }        

        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstname, string lastname) => !String.IsNullOrWhiteSpace(firstname) || !String.IsNullOrWhiteSpace(lastname);
        //{
        //    return !String.IsNullOrWhiteSpace(firstname) || !String.IsNullOrWhiteSpace(lastname);
        //}

        public void ClearText(string firstname, string lastname) //przesyłamy first i lastname tylko po to aby można było przesłać to samo do metody CanClearText
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
