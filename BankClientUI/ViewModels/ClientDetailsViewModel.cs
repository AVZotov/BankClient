using System.ComponentModel.DataAnnotations;

namespace BankClientUI.ViewModels
{
    public partial class ClientDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string secondName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string passport;

        [ObservableProperty]
        private DateTime created;

        [ObservableProperty]
        private string createdBy;

        [ObservableProperty]
        private DateTime? updated;

        [ObservableProperty]
        private string? updatedBy;

        public ClientDetailsViewModel(Client client)
        {
            FirstName = client.GetFirstName();
            SecondName = client.GetSecondName();
            LastName = client.GetLastName();
            Phone = client.GetPhone();
            Passport = client.GetPassport();
            RecordInfo recordInfo = client.GetRecordInfo();
            Created = recordInfo.GetRecordCreationDate();
            CreatedBy = recordInfo.GetRecordCreationPerson();
            Updated = recordInfo.GetRecordUpdatedDate();
            UpdatedBy = recordInfo.GetRecordUpdatedPerson();
        }

        public ClientDetailsViewModel ShallowCopy()
        {
            return (ClientDetailsViewModel)this.MemberwiseClone();
        }

        public Client GetClientModel()
        {
            return new Client(FirstName, SecondName, LastName, Phone, Passport, new RecordInfo(Created, CreatedBy, Updated, UpdatedBy));
        }
    }
}
