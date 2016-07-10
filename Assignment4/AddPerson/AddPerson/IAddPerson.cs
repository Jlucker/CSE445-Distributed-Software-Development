using System.ServiceModel;


namespace AddPerson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAddPerson
    {

        [OperationContract]
        void AddNewPerson(Person person);

        [OperationContract]
        void RemovePerson(Person person);

        [OperationContract]
        bool UserIdCheck(string userId);

        [OperationContract]
        bool PersonNameCheck(string firstName, string lastName);

        [OperationContract]
        Persons GetPersons();

    }
}
