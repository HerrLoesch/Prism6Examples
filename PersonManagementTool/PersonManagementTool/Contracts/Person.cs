namespace PersonManagementTool.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using PersonManagementTool.Annotations;

    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

        private DateTime birthDate;

        private string error;

        private string firstName;

        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value == this.firstName)
                {
                    return;
                }
                this.firstName = value;
                this.CheckForErrors();
                this.OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == this.lastName)
                {
                    return;
                }
                this.lastName = value;
                this.CheckForErrors();
                this.OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                if (value.Equals(this.birthDate))
                {
                    return;
                }
                this.birthDate = value;
                this.CheckForErrors();
                this.OnPropertyChanged();
            }
        }

        [Key]
        public int Id { get; set; }

        private ObservableCollection<KeyValuePair<int, int>> numbers = new ObservableCollection<KeyValuePair<int, int>>();

        public ObservableCollection<KeyValuePair<int, int>> Numbers
        {
            get
            {
                return this.numbers;
            }
            set
            {
                this.numbers = value;
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>
        /// The error message for the property. The default is an empty string ("").
        /// </returns>
        /// <param name="columnName">The name of the property whose error message to get. </param>
        public string this[string columnName]
        {
            get
            {
                string resultText = null;
                this.errors.TryGetValue(columnName, out resultText);

                return resultText;
            }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>
        /// An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        public string Error
        {
            get
            {
                return this.error;
            }
            private set
            {
                this.error = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CheckForErrors()
        {
            // Kids, don't try this at home. It's just for presentation purpose and I know it's ugly as hell...
            this.ResetErrors();

            if (string.IsNullOrEmpty(this.FirstName) || string.IsNullOrWhiteSpace(this.FirstName))
            {
                this.Error = this.errors["FirstName"] = "Bitte geben Sie einen Vornamen ein.";
            }

            if (string.IsNullOrEmpty(this.LastName) || string.IsNullOrWhiteSpace(this.LastName))
            {
                this.Error = this.errors["LastName"] = "Bitte geben Sie einen Nachnamen ein.";
            }

            if (this.BirthDate.Year <= 1850)
            {
                this.Error = this.errors["BirthDate"] = "Bitte geben Sie ein Gebursdatum ein.";
            }
        }

        private void ResetErrors()
        {
            var keys = this.errors.Keys.ToList();
            foreach (var key in keys)
            {
                this.errors[key] = null;
            }

            this.Error = null;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ValidateInput()
        {
            this.CheckForErrors();
        }
    }
}